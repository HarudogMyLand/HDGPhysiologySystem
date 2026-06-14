using System;
using Physiology.Organs;

namespace Physiology.Organs.OrganImplementation.Brain;

/// <summary>
/// Brainstem: Medulla, Pons, Midbrain, Reticular Formation.
/// Pure state container. Tick() updates vital signals and may trigger death.
/// All trauma effects applied directly by DamageHandler.
/// </summary>
public class Brainstem
{
    // Subregion integrity (0 = destroyed, 1 = fully healthy)
    public double MedullaHealth { get; set; } = 1.0;          // Cardiac, respiratory, vasomotor centers
    public double PonsHealth { get; set; } = 1.0;             // Respiratory regulation, sleep, cranial nerves
    public double MidbrainHealth { get; set; } = 1.0;         // Visual/auditory reflexes, motor control
    public double ReticularFormationHealth { get; set; } = 1.0; // Arousal, consciousness, pain modulation

    // Derived overall health (critical: medulla + reticular formation weighted higher)
    public double OverallHealth => (MedullaHealth * 0.4 + ReticularFormationHealth * 0.3 + PonsHealth * 0.15 + MidbrainHealth * 0.15);
    public OrganPathology Pathology { get; set; }

    public Brainstem()
    {
        Pathology = OrganPathology.None;
    }


    /// <summary>
    /// Called by Brain.Tick() every frame.
    /// Reads current integrity and writes vital signals to BrainSignalBoard.
    /// If critical structures fall below threshold, triggers immediate death.
    /// </summary>
    public void Tick(double deltaTime, BrainSignalBoard signalBoard)
    {
        double health = OverallHealth;
        double medullaHealth = MedullaHealth;
        double reticularHealth = ReticularFormationHealth;

        // === Vital Signals (from Medulla) ===
        // Respiratory drive: medulla's dorsal and ventral respiratory groups
        signalBoard.RespiratoryDrive = medullaHealth;
        
        // If medulla damaged, breathing stops
        if (medullaHealth < Macro.OrganDestroyedThreshold)
        {
            signalBoard.RespiratoryDrive = 0;
        }

        // Cardiac center: heart rate and contractility modulation
        signalBoard.CardiacCenterFunction = medullaHealth; 
        
        // Blood pressure regulation
        signalBoard.VasomotorCenterFunction = medullaHealth;  

        // Baroreceptor reflex (blood pressure stabilization)
        signalBoard.BaroreceptorReflexGain = medullaHealth;

        // === Arousal & Consciousness (from Reticular Formation) ===
        signalBoard.ReticularActivatingSystem = reticularHealth;
        
        // If reticular formation severely damaged, unconsciousness/coma
        if (reticularHealth < Macro.OrganDestroyedThreshold)
            signalBoard.IsConscious = false;

        // Store brainstem reticular activity for Cerebrum consciousness check
        signalBoard.BrainstemReticularFormationActive =
            reticularHealth > (Macro.OrganDestroyedThreshold + Random.Shared.NextDouble() * 0.1);

        // === Reflexes ===
        // Pupillary light reflex (midbrain)
        signalBoard.PupillaryLightReflex = MidbrainHealth;
        // Corneal reflex (pons/midbrain)
        signalBoard.CornealReflex = Math.Min(PonsHealth, MidbrainHealth);
        // Gag reflex (medulla)
        signalBoard.GagReflex = medullaHealth;
        // Cough reflex (medulla)
        signalBoard.CoughReflex = medullaHealth;

        // === Cranial Nerve Functions (simplified) ===
        // Maybe one day you will have to simulate brain nerves? just think about it
        signalBoard.FacialMotorFunction = PonsHealth;         // CN VII
        signalBoard.EyeMovementControl = MidbrainHealth;      // CN III, IV, VI
        signalBoard.SwallowingFunction = Math.Min(MedullaHealth, PonsHealth);
        signalBoard.VocalCordControl = PonsHealth;

        // === Pain Modulation (periaqueductal gray in midbrain) ===
        signalBoard.DescendingPainInhibition = MidbrainHealth;

        // === Sleep-Wake Regulation ===
        signalBoard.SleepWakeCycleIntegrity = Math.Min(PonsHealth, ReticularFormationHealth);

        // === Autonomic Outputs ===
        // Sympathetic outflow from medulla and pons
        signalBoard.SympatheticOutflowStrength = medullaHealth;
        signalBoard.ParasympatheticOutflowStrength = medullaHealth * 0.8;

        // === Overall Brainstem Function ===
        signalBoard.BrainstemFunction = health;

        // === Critical Damage Check: Immediate Death ===
        // If medulla completely destroyed OR reticular formation destroyed AND medulla < threshold
        if (medullaHealth <= Macro.OrganDeathThreshold || 
            (reticularHealth <= Macro.OrganDeathThreshold && 
             medullaHealth < Macro.OrganDestroyedThreshold))
        {
            signalBoard.IsConscious = false;
            signalBoard.RespiratoryDrive = 0;
            signalBoard.CardiacCenterFunction = 0;
            // Trigger death signal via Brain's own death event (not signal board)
            // We assume Brain class listens to this condition or we directly invoke
            // For now, set a flag that Brain.Tick() can read
            signalBoard.BrainstemCriticalFailure = true;
        }
        else
        {
            signalBoard.BrainstemCriticalFailure = false;
        }

        // === Neuroinflammation (if severe damage) ===
        double damageFactor = 1.0 - health;
        if (damageFactor > 0.6)
        {
            signalBoard.NeuroinflammationMarker = 
                Math.Min(1.0, signalBoard.NeuroinflammationMarker + 0.02 * deltaTime);
        }
    }
    
    private void UpdatePathology(double health, double damageFactor, BrainSignalBoard signalBoard)
    {
        // Clear reversible flags
        var reversibleFlags = OrganPathology.Inflammation | OrganPathology.Edema;
        Pathology &= ~reversibleFlags;

        // Inflammation: from global neuroinflammation or severe local damage
        bool hasNeuroinflammation = signalBoard.NeuroinflammationMarker > 0.05;
        bool severeDamage = damageFactor > 0.3;
        if (hasNeuroinflammation || severeDamage)
            Pathology |= OrganPathology.Inflammation;

        // Edema: from elevated intracranial pressure (brainstem herniation risk)
        if (signalBoard.IntracranialPressureDelta > 10.0)
            Pathology |= OrganPathology.Edema;

        // TODO: still adding cerebral blood flow
        // Ischemia: critically low cerebral blood flow or basilar artery insufficiency
        // if (signalBoard.CerebralBloodFlow < 0.25 || signalBoard.BasilarArteryFlow < 0.2)
            // Pathology |= OrganPathology.Ischemia;

        // TODO: adding brain stem hemorrhage volume
        // Hemorrhage: brainstem hemorrhage (e.g., from hypertension or trauma)
        // Could be set from external damage, but here we check signal board flag
        // if (signalBoard.BrainstemHemorrhageVolume > 5.0)
        //     Pathology |= OrganPathology.Hemorrhage;

        // Necrosis: irreversible destruction (health below 20%)
        if (!Pathology.HasFlag(OrganPathology.Necrosis) && health < 0.2)
            Pathology |= OrganPathology.Necrosis;

        // Atrophy: chronic damage
        if (!Pathology.HasFlag(OrganPathology.Atrophy) && health < 0.6 && damageFactor > 0.4)
            Pathology |= OrganPathology.Atrophy;
    }
}