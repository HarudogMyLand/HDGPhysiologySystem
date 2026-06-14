using Physiology.Damage;
using System;
namespace Physiology.Organs.OrganImplementation.Brain;

/// <summary>
/// Cerebrum controls consciousness, emotion, etc.
/// 
/// - Frontal lobe: reasoning, planning, movement, speech, emotion.
/// - Parietal lobe: touch, spatial sense, coordination, math.
/// - Temporal lobe: hearing, language understanding, memory, emotion.
/// - Occipital lobe: vision (color, shape, motion, depth).
/// </summary>

public class Cerebrum
{
    // Lobe integrity (0 = destroyed, 1 = fully healthy)
    public double FrontalLobe { get; set; } = 1.0;
    public double ParietalLobe { get; set; } = 1.0;
    public double TemporalLobe { get; set; } = 1.0;
    public double OccipitalLobe { get; set; } = 1.0;

    // Additional subregions if needed
    public double MotorCortex { get; set; } = 1.0;
    public double SomatosensoryCortex { get; set; } = 1.0;
    
    public double OverallHealth =>  (FrontalLobe + ParietalLobe + TemporalLobe + OccipitalLobe) / 4;
    public OrganPathology  Pathology { get; set; } = new OrganPathology();

    /// <summary>
    /// Called by Brain.Tick() every frame.
    /// Reads current lobe integrities and writes signals to BrainSignalBoard.
    /// </summary>
    public void Tick(double deltaTime, BrainSignalBoard signalBoard)
    {
        // Overall cerebrum health (average of lobes)
        double cerebrumHealth = (FrontalLobe + ParietalLobe + TemporalLobe + OccipitalLobe) / 4.0;

        // === Neural signals ===
        // Consciousness requires frontal + parietal + thalamic integration (simplified)
        signalBoard.IsConscious = (cerebrumHealth > 0.3 && signalBoard.BrainstemReticularFormationActive);

        // Motor coordination depends on frontal/motor cortex + cerebellum (cerebellum signal separate)
        double motorContribution = (FrontalLobe * 0.6 + MotorCortex * 0.4);
        signalBoard.MotorCoordination = Math.Clamp(motorContribution * signalBoard.CerebellumFunction, 0, 1);

        // Pain perception requires parietal and temporal lobes
        signalBoard.PainSignal = signalBoard.HasPainInput ? 
            Math.Min(1.0, (ParietalLobe + TemporalLobe) / 2.0 * signalBoard.PainInputStrength) : 0;

        // Cognitive function (decision-making, memory) - primarily frontal + temporal
        signalBoard.CognitiveFunction = (FrontalLobe + TemporalLobe) / 2.0;

        // Vision loss if occipital lobe damaged
        signalBoard.HasVision = OccipitalLobe > 0.2;

        // Hearing loss if temporal lobe damaged (primary auditory cortex)
        signalBoard.HasHearing = TemporalLobe > 0.2;

        // Speech (Broca's area - left frontal, Wernicke's - temporal)
        signalBoard.CanSpeak = (FrontalLobe > 0.3 && TemporalLobe > 0.3);

        // === Hormonal signals (cerebrum influences via hypothalamus, but here we just reflect damage) ===
        // Severe frontal damage reduces stress regulation
        if (FrontalLobe < Macro.OrganDestroyedThreshold)
            signalBoard.StressHormoneLevel = Math.Min(1.0, signalBoard.StressHormoneLevel + 0.01 * deltaTime);
        
        // Temporal lobe damage can cause inappropriate ADH release (simplified)
        if (TemporalLobe < Macro.OrganBrokenThreshold)
            signalBoard.AntidiureticHormone = Math.Min(1.0, signalBoard.AntidiureticHormone + 0.005 * deltaTime);

        // === Immune signals ===
        // Severe brain damage triggers neuroinflammation via microglia
        double damageFactor = 1.0 - cerebrumHealth;
        signalBoard.NeuroinflammationMarker = Math.Min(1.0, damageFactor * 0.8);
        signalBoard.MicrogliaActivation = Math.Min(1.0, damageFactor * 0.9);

        // Cytokines rise with tissue necrosis
        if (damageFactor > 0.5)
        {
            signalBoard.Interleukin1 = Math.Min(1.0, signalBoard.Interleukin1 + 0.05 * deltaTime);
            signalBoard.Interleukin6 = Math.Min(1.0, signalBoard.Interleukin6 + 0.03 * deltaTime);
        }

        // Overall brain function (composite, may be used by death system)
        signalBoard.OverallFunction = cerebrumHealth * 0.7 + 
                                      (signalBoard.IsConscious ? 0.3 : 0);
    }
    
    private void UpdatePathology(double health, double damageFactor, BrainSignalBoard signalBoard)
{
    // Clear reversible flags (inflammation, edema)
    var reversibleFlags = OrganPathology.Inflammation | OrganPathology.Edema;
    Pathology &= ~reversibleFlags;

    // Inflammation: from global neuroinflammation or severe local damage
    bool hasNeuroinflammation = signalBoard.NeuroinflammationMarker > 0.05;
    bool severeDamage = damageFactor > 0.3;
    if (hasNeuroinflammation || severeDamage)
        Pathology |= OrganPathology.Inflammation;

    // Edema: caused by increased intracranial pressure (cerebral edema)
    if (signalBoard.IntracranialPressureDelta > 10.0)
        Pathology |= OrganPathology.Edema;

    // Ischemia: cerebral blood flow too low or local vascular stenosis
    // if (signalBoard.CerebralBloodFlow < 0.25 || signalBoard.MiddleCerebralArteryFlow < 0.2)
        // Pathology |= OrganPathology.Ischemia;

    // Hemorrhage: intracerebral hemorrhage (e.g., hypertension, trauma)
    // if (signalBoard.CerebralHemorrhageVolume > 10.0)
        // Pathology |= OrganPathology.Hemorrhage;

    // Atrophy: chronic damage or neurodegenerative changes (irreversible)
    // if (!Pathology.HasFlag(OrganPathology.Atrophy) && health < 0.6 && damageFactor > 0.4)
    //     Pathology |= OrganPathology.Atrophy;

    // Necrosis: large area infarction or severe trauma (irreversible)
    // if (!Pathology.HasFlag(OrganPathology.Necrosis) && health < 0.2)
    //     Pathology |= OrganPathology.Necrosis;

    // Fibrosis: glial scar formation after chronic inflammation (irreversible)
    // if (!Pathology.HasFlag(OrganPathology.Fibrosis) && health < 0.5 && signalBoard.NeuroinflammationMarker > 0.15)
    //     Pathology |= OrganPathology.Fibrosis;

    // Calcification: seen in certain infections, metabolic diseases, or tumors (irreversible)
    // if (!Pathology.HasFlag(OrganPathology.Calcification) && signalBoard.CalcificationRiskFactor > 0.8)
    //     Pathology |= OrganPathology.Calcification;

    // Benign/malignant tumor: set directly by external DamageHandler, only example condition here
    // Usually not set automatically by UpdatePathology, but directly modified by damage logic
}

}