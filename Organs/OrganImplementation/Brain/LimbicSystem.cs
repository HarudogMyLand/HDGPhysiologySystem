using System;

namespace Physiology.Organs.OrganImplementation.Brain;

/// <summary>
/// Limbic System: emotion, memory, motivation, stress response.
/// Pure state container. Tick() updates BrainSignalBoard based on integrity.
/// All trauma effects applied directly by DamageHandler.
/// </summary>
public class LimbicSystem
{
    // Key structure integrities (0 = destroyed, 1 = fully healthy)
    public double Hippocampus { get; set; } = 1.0;      // Memory formation, spatial navigation
    public double Amygdala { get; set; } = 1.0;         // Fear, anxiety, aggression
    public double CingulateCortex { get; set; } = 1.0;  // Emotion regulation, pain processing
    public double NucleusAccumbens { get; set; } = 1.0; // Reward, pleasure, addiction
    public double SeptalNuclei { get; set; } = 1.0;     // Pleasure, reinforcement
    public double MammillaryBodies { get; set; } = 1.0; // Memory (part of Papez circuit)

    // Derived overall health
    public double OverallHealth => (Hippocampus + Amygdala + CingulateCortex + NucleusAccumbens + SeptalNuclei + MammillaryBodies) / 6.0;
    
    public OrganPathology Pathology { get; set; } = new OrganPathology();

    /// <summary>
    /// Called by Brain.Tick() every frame.
    /// Reads current integrities and writes emotion/memory signals to BrainSignalBoard.
    /// </summary>
    public void Tick(double deltaTime, BrainSignalBoard signalBoard)
    {
        double health = OverallHealth;

        // === Emotional Signals ===
        signalBoard.AmygdalaFunction = Amygdala;
        signalBoard.FearResponseAmplitude = Amygdala;               // Fear intensity
        signalBoard.AggressionInhibition = Amygdala;                // Higher = better control
        signalBoard.DisorganizedAggression = Amygdala < 0.3;        // Loss of inhibition

        signalBoard.EmotionalRegulation = CingulateCortex;
        signalBoard.EmotionalInstability = CingulateCortex < 0.4;

        double painAffect = (CingulateCortex + Amygdala) / 2.0;
        signalBoard.PainAffectModulator = painAffect;               // Emotional component of pain

        // === Memory Signals ===
        signalBoard.MemoryFormationCapability = Hippocampus;
        signalBoard.AnterogradeAmnesia = Hippocampus < 0.3;

        signalBoard.MammillaryMemoryRelay = MammillaryBodies;
        signalBoard.RetrogradeAmnesia = MammillaryBodies < 0.4;

        signalBoard.SpatialMemory = Hippocampus;

        // === Motivation & Reward ===
        signalBoard.RewardSensitivity = NucleusAccumbens;
        signalBoard.MotivationDrive = NucleusAccumbens;
        signalBoard.Anhedonia = NucleusAccumbens < 0.3;              // Inability to feel pleasure
        signalBoard.PleasureResponse = SeptalNuclei;

        // === Stress Response Modulation ===
        signalBoard.StressResponseAmplifier = Amygdala;
        signalBoard.CingulateStressModulation = CingulateCortex;

        // === Overall contribution ===
        signalBoard.LimbicSystemFunction = health;
        signalBoard.OverallFunction = (signalBoard.OverallFunction + health) / 2.0;

        // === Neuroinflammation from severe damage ===
        double damageFactor = 1.0 - health;
        if (damageFactor > 0.7)
        {
            signalBoard.NeuroinflammationMarker = Math.Min(1.0, signalBoard.NeuroinflammationMarker + 0.015 * deltaTime);
            signalBoard.HippocampalInflammationFactor = damageFactor;
        }
        else
        {
            signalBoard.HippocampalInflammationFactor = 0;
        }
    }
}