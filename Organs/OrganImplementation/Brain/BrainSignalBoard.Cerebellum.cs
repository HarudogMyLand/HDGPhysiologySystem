namespace Physiology.Organs.OrganImplementation.Brain
{
    public partial class BrainSignalBoard
    {
        // ============================================================
        // CEREBELLUM – Coordination, balance, motor learning
        // ============================================================

        /// <summary>Cerebellar motor coordination (0 = none, 1 = perfect).</summary>
        public double CerebellarMotorCoordination { get; internal set; } = 1.0;

        /// <summary>Balance capability (0 = unable, 1 = normal).</summary>
        public double BalanceCapability { get; internal set; } = 1.0;

        /// <summary>Postural instability present.</summary>
        public bool PosturalInstability { get; internal set; }

        /// <summary>Fine motor control (0 = none, 1 = normal).</summary>
        public double FineMotorControl { get; internal set; } = 1.0;

        /// <summary>Muscle tone (0 = flaccid, 1 = normal).</summary>
        public double MuscleTone { get; internal set; } = 1.0;

        /// <summary>Gait ataxia present.</summary>
        public bool GaitAtaxia { get; internal set; }

        /// <summary>Limb ataxia present.</summary>
        public bool LimbAtaxia { get; internal set; }

        /// <summary>Nystagmus (involuntary eye movement) present.</summary>
        public bool Nystagmus { get; internal set; }

        /// <summary>Cerebellar motor readiness (0 = impaired, 1 = normal).</summary>
        public double CerebellarMotorReadiness { get; internal set; } = 1.0;

        /// <summary>Intention tremor present.</summary>
        public bool IntentionTremor { get; internal set; }

        /// <summary>Reflex gain multiplier (0 = areflexia, 1 = normal).</summary>
        public double ReflexGainMultiplier { get; internal set; } = 1.0;

        /// <summary>Cerebellum function composite (0-1).</summary>
        public double CerebellumFunction { get; internal set; } = 1.0;

        // ------------------------------------------------------------
        // Partial method implementation for cerebellum reset
        // ------------------------------------------------------------
        partial void ResetCerebellum()
        {
            CerebellarMotorCoordination = 1.0;
            BalanceCapability = 1.0;
            PosturalInstability = false;
            FineMotorControl = 1.0;
            MuscleTone = 1.0;
            GaitAtaxia = false;
            LimbAtaxia = false;
            Nystagmus = false;
            CerebellarMotorReadiness = 1.0;
            IntentionTremor = false;
            ReflexGainMultiplier = 1.0;
            CerebellumFunction = 1.0;
        }
    }
}