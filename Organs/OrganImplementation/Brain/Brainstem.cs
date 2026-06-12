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
    public double Medulla { get; set; } = 1.0;          // Cardiac, respiratory, vasomotor centers
    public double Pons { get; set; } = 1.0;             // Respiratory regulation, sleep, cranial nerves
    public double Midbrain { get; set; } = 1.0;         // Visual/auditory reflexes, motor control
    public double ReticularFormation { get; set; } = 1.0; // Arousal, consciousness, pain modulation

    // Derived overall health (critical: medulla + reticular formation weighted higher)
    public double OverallHealth => (Medulla * 0.4 + ReticularFormation * 0.3 + Pons * 0.15 + Midbrain * 0.15);
    public OrganPathology Pathology { get; set; } = new OrganPathology();

    public Brainstem()
    {
        Pathology = OrganPathology.None;
    }

    /// <summary>
    /// Called by Brain.Tick() every frame.
    /// Reads current integrities and writes vital signals to BrainSignalBoard.
    /// If critical structures fall below threshold, triggers immediate death.
    /// </summary>
    public void Tick(double deltaTime, BrainSignalBoard signalBoard)
    {
        double health = OverallHealth;
        double medullaHealth = Medulla;
        double reticularHealth = ReticularFormation;

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
        signalBoard.PupillaryLightReflex = Midbrain;
        // Corneal reflex (pons/midbrain)
        signalBoard.CornealReflex = Math.Min(Pons, Midbrain);
        // Gag reflex (medulla)
        signalBoard.GagReflex = medullaHealth;
        // Cough reflex (medulla)
        signalBoard.CoughReflex = medullaHealth;

        // === Cranial Nerve Functions (simplified) ===
        // Maybe one day you will have to simulate brain nerves? just think about it
        signalBoard.FacialMotorFunction = Pons;         // CN VII
        signalBoard.EyeMovementControl = Midbrain;      // CN III, IV, VI
        signalBoard.SwallowingFunction = Math.Min(Medulla, Pons);
        signalBoard.VocalCordControl = Pons;

        // === Pain Modulation (periaqueductal gray in midbrain) ===
        signalBoard.DescendingPainInhibition = Midbrain;

        // === Sleep-Wake Regulation ===
        signalBoard.SleepWakeCycleIntegrity = Math.Min(Pons, ReticularFormation);

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
}