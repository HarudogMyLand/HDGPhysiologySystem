using System;

namespace Physiology.Organs.OrganImplementation.Brain;

/// <summary>
/// Cerebellum: motor coordination, balance, posture, fine movement.
/// Pure state container. Tick() updates BrainSignalBoard based on integrity.
/// All trauma effects applied directly by DamageHandler.
/// </summary>
public class Cerebellum
{
    // Subregion integrity (0 = destroyed, 1 = fully healthy)
    public double Vermis { get; set; } = 1.0;        // Midline: balance, posture, eye movement
    public double Hemispheres { get; set; } = 1.0;   // Lateral: limb coordination, fine motor
    public double FlocculonodularLobe { get; set; } = 1.0; // Vestibulocerebellum: balance, eye tracking

    // Derived overall health
    public double OverallHealth => (Vermis + Hemispheres + FlocculonodularLobe) / 3.0;

    /// <summary>
    /// Called by Brain.Tick() every frame.
    /// Reads current integrities and writes movement-related signals to BrainSignalBoard.
    /// </summary>
    public void Tick(double deltaTime, BrainSignalBoard signalBoard)
    {
        double health = OverallHealth;

        // === Motor Coordination ===
        // Cerebellum integrates with motor cortex and brainstem
        // Damage reduces coordination proportionally
        signalBoard.CerebellarMotorCoordination = health;
        
        // Override MotorCoordination signal (previously from Cerebrum) combining both
        // The final MotorCoordination should be a product of cerebellar health and cerebrum's motor cortex
        // But we let the signal board compute composite; here we provide the cerebellar factor.
        signalBoard.CerebellumFunction = health;

        // === Balance & Posture ===
        // Vermis and flocculonodular lobe are critical for balance
        double balanceHealth = (Vermis + FlocculonodularLobe) / 2.0;
        signalBoard.BalanceCapability = balanceHealth;
        if (balanceHealth < 0.3)
            signalBoard.PosturalInstability = true;
        else
            signalBoard.PosturalInstability = false;

        // === Fine Motor Control ===
        // Hemispheres control fine, skilled movements (e.g., writing, aiming)
        signalBoard.FineMotorControl = Hemispheres;

        // === Muscle Tone ===
        // Cerebellar damage causes hypotonia (floppy limbs) or rigidity depending on lesion
        // Simplified: tone reduces with damage
        signalBoard.MuscleTone = 0.5 + health * 0.5;  // range 0.5 to 1.0

        // === Gait and Limb Ataxia ===
        signalBoard.GaitAtaxia = (1.0 - health) > 0.5;
        signalBoard.LimbAtaxia = (1.0 - Hemispheres) > 0.4;

        // === Eye Movement (Nystagmus) ===
        // Flocculonodular damage causes nystagmus
        signalBoard.Nystagmus = FlocculonodularLobe < 0.4;

        // === Contribution to Overall Motor Function ===
        // Combined with cerebrum's motor cortex (signalBoard.MotorCortexFunction)
        // But we just set a motor readiness factor
        signalBoard.CerebellarMotorReadiness = health;

        // === Damping of Tremor ===
        // Cerebellum normally damps physiological tremor; damage increases tremor
        signalBoard.IntentionTremor = health < 0.6;

        // === Reflex Adaptation ===
        // Cerebellum adjusts reflex gains
        signalBoard.ReflexGainMultiplier = health;

        // === Neuroinflammation (if severe damage) ===
        double damageFactor = 1.0 - health;
        if (damageFactor > 0.6)
        {
            signalBoard.NeuroinflammationMarker = Math.Min(1.0, signalBoard.NeuroinflammationMarker + 0.01 * deltaTime);
        }
    }
}