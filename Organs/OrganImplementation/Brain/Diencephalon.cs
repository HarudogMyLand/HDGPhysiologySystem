using System;

namespace Physiology.Organs.OrganImplementation.Brain;

/// <summary>
/// Diencephalon: Thalamus, Hypothalamus, Subthalamus, Epithalamus.
/// Tick() updates BrainSignalBoard based on integrity.
/// </summary>
public class Diencephalon
{
    // Subregion integrity (0 = destroyed, 1 = fully healthy)
    public double Thalamus { get; set; } = 1.0;          // Sensory relay, consciousness, motor control
    public double Hypothalamus { get; set; } = 1.0;      // Autonomic, endocrine, homeostasis
    public double Subthalamus { get; set; } = 1.0;       // Motor regulation (part of basal ganglia)
    public double Epithalamus { get; set; } = 1.0;       // Pineal gland (melatonin), circadian rhythm

    public double OverallHealth => (Thalamus + Hypothalamus + Subthalamus + Epithalamus) / 4.0;
    public OrganPathology Pathology { get; set; } = new OrganPathology();
    /// <summary>
    /// Called by Brain.Tick() every frame.
    /// Reads current integrities and writes signals to BrainSignalBoard.
    /// </summary>
    public void Tick(double deltaTime, BrainSignalBoard signalBoard)
    {
        // === Neural Signals ===
        // Thalamic damage disrupts sensory relay to cortex
        signalBoard.ThalamicSensoryRelay = Thalamus;
        // Thalamic reticular nucleus contributes to consciousness/attention
        if (Thalamus < Macro.OrganDestroyedThreshold)
            signalBoard.IsConscious = false;   // Override if thalamus too damaged

        // Subthalamus damage causes movement disorders (hemiballism)
        signalBoard.SubthalamicMotorRegulation = Subthalamus;

        // Epithalamus (pineal) affects melatonin production
        signalBoard.MelatoninProduction = Epithalamus;

        // === Hormonal Signals (primarily from Hypothalamus) ===
        // Hypothalamus releases inhibiting hormones to pituitary
        double hypothalamicHealth = Hypothalamus;
        
        // CRH (Corticotropin-releasing hormone) – stress response
        // If hypothalamus damaged, CRH output drops
        signalBoard.CorticotropinReleasingHormone = hypothalamicHealth * signalBoard.StressInputFactor;
        
        // TRH (Thyrotropin-releasing hormone) – controls thyroid
        signalBoard.ThyrotropinReleasingHormone = hypothalamicHealth * 0.5;  // baseline

        // GnRH (Gonadotropin-releasing hormone) – reproduction (optional)
        signalBoard.GonadotropinReleasingHormone = hypothalamicHealth * 0.3;

        // ADH (Antidiuretic hormone) – produced in hypothalamus, stored in posterior pituitary
        // Damage reduces ADH production -> diabetes insipidus
        signalBoard.AntidiureticHormoneProduction = hypothalamicHealth;
        signalBoard.AntidiureticHormone = signalBoard.AntidiureticHormoneProduction * signalBoard.BodyHydrationFactor;

        // Oxytocin (not critical for trauma but can be included)
        signalBoard.OxytocinProduction = hypothalamicHealth;

        // Growth hormone releasing hormone (GHRH), though this seems redundant
        signalBoard.GrowthHormoneReleasingHormone = hypothalamicHealth;

        // === Autonomic Regulation ===
        // Hypothalamus controls sympathetic/parasympathetic balance
        signalBoard.SympatheticTone = hypothalamicHealth * signalBoard.StressInputFactor;
        signalBoard.ParasympatheticTone = hypothalamicHealth * (1 - signalBoard.StressInputFactor);

        // Thermoregulation: anterior hypothalamus detects heat, posterior prevents heat loss
        // Simplified: if hypothalamus damaged, body temperature regulation fails
        signalBoard.ThermoregulationCapability = hypothalamicHealth;
        if (hypothalamicHealth < Macro.OrganBrokenThreshold)
            signalBoard.BodyTemperatureRegulationFailure = true;

        // Appetite and thirst regulation
        signalBoard.HungerRegulation = hypothalamicHealth;
        signalBoard.ThirstRegulation = hypothalamicHealth;

        // Circadian rhythm (suprachiasmatic nucleus in hypothalamus)
        signalBoard.CircadianRhythmIntegrity = Math.Min(Hypothalamus, Epithalamus);

        // === Immune Signals ===
        // Hypothalamus responds to cytokines (IL-1, IL-6) to induce fever
        // Damage reduces ability to mount fever response
        signalBoard.FeverResponseCapability = hypothalamicHealth;

        // If diencephalon significantly damaged, neuroinflammation spreads
        double avgHealth = (Thalamus + Hypothalamus + Subthalamus + Epithalamus) / 4.0;
        double damageFactor = 1.0 - avgHealth;
        if (damageFactor > 0.5)
        {
            signalBoard.NeuroinflammationMarker = Math.Min(1.0, signalBoard.NeuroinflammationMarker + 0.02 * deltaTime);
        }

        // === Overall contribution to brain function ===
        // Diencephalon critical for homeostasis and sensory integration
        signalBoard.DiencephalonFunction = avgHealth;
        // Overall brain function already computed in Cerebrum, but can influence
        signalBoard.OverallFunction = (signalBoard.OverallFunction + avgHealth) / 2.0;
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

        // Edema: from elevated intracranial pressure
        if (signalBoard.IntracranialPressureDelta > 10.0)
            Pathology |= OrganPathology.Edema;

        // TODO: where is this blood flow?
        // Ischemia: if cerebral blood flow is critically low (example)
        // if (signalBoard.CerebralBloodFlow < 0.25)
        //     Pathology |= OrganPathology.Ischemia;

        // Atrophy: chronic low health or long-term inflammation (irreversible once set)
        if (!Pathology.HasFlag(OrganPathology.Atrophy) && health < 0.6 && 
            (signalBoard.NeuroinflammationMarker > 0.1 || damageFactor > 0.4))
        {
            Pathology |= OrganPathology.Atrophy;
        }

        // Necrosis: extreme damage (irreversible)
        if (!Pathology.HasFlag(OrganPathology.Necrosis) && health < 0.2)
        {
            Pathology |= OrganPathology.Necrosis;
        }

        // TODO: where is calcification?
        // Calcification: chronic endocrine dysfunction (example)
        // if (!Pathology.HasFlag(OrganPathology.Calcification) && Hypothalamus < 0.5 && 
        //     signalBoard.CalcificationRiskFactor > 0.7)
        // {
        //     Pathology |= OrganPathology.Calcification;
        // }
    }

}