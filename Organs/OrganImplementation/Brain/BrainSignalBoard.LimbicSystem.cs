namespace Physiology.Organs.OrganImplementation.Brain
{
    public partial class BrainSignalBoard
    {
        // ============================================================
        // LIMBIC SYSTEM – Emotion, memory, fear, reward, stress modulation
        // ============================================================

        /// <summary>Amygdala function (0 = ablated, 1 = normal).</summary>
        public double AmygdalaFunction { get; internal set; } = 1.0;

        /// <summary>Fear response amplitude (0 = none, 1 = normal).</summary>
        public double FearResponseAmplitude { get; internal set; } = 1.0;

        /// <summary>Aggression inhibition (0 = disinhibited, 1 = normal).</summary>
        public double AggressionInhibition { get; internal set; } = 1.0;

        /// <summary>Disorganized aggression flag.</summary>
        public bool DisorganizedAggression { get; internal set; }

        /// <summary>Emotional regulation (0 = labile, 1 = stable).</summary>
        public double EmotionalRegulation { get; internal set; } = 1.0;

        /// <summary>Emotional instability flag.</summary>
        public bool EmotionalInstability { get; internal set; }

        /// <summary>Pain affect modulator (0 = no emotional pain, 1 = normal).</summary>
        public double PainAffectModulator { get; internal set; } = 1.0;

        /// <summary>Memory formation capability (0 = none, 1 = normal).</summary>
        public double MemoryFormationCapability { get; internal set; } = 1.0;

        /// <summary>Anterograde amnesia present.</summary>
        public bool AnterogradeAmnesia { get; internal set; }

        /// <summary>Mammillary body memory relay (0 = failed, 1 = normal).</summary>
        public double MammillaryMemoryRelay { get; internal set; } = 1.0;

        /// <summary>Retrograde amnesia present.</summary>
        public bool RetrogradeAmnesia { get; internal set; }

        /// <summary>Spatial memory (0 = absent, 1 = normal).</summary>
        public double SpatialMemory { get; internal set; } = 1.0;

        /// <summary>Reward sensitivity (0 = insensitive, 1 = normal).</summary>
        public double RewardSensitivity { get; internal set; } = 1.0;

        /// <summary>Motivation drive (0 = apathy, 1 = normal).</summary>
        public double MotivationDrive { get; internal set; } = 1.0;

        /// <summary>Anhedonia flag (inability to feel pleasure).</summary>
        public bool Anhedonia { get; internal set; }

        /// <summary>Pleasure response (0 = none, 1 = normal).</summary>
        public double PleasureResponse { get; internal set; } = 1.0;

        /// <summary>Stress response amplifier (1 = normal, >1 = hyper-reactive).</summary>
        public double StressResponseAmplifier { get; internal set; } = 1.0;

        /// <summary>Cingulate stress modulation (0 = failed, 1 = normal).</summary>
        public double CingulateStressModulation { get; internal set; } = 1.0;

        /// <summary>Overall limbic system function (0-1).</summary>
        public double LimbicSystemFunction { get; internal set; } = 1.0;

        /// <summary>Hippocampal inflammation factor (0 = none, 1 = severe).</summary>
        public double HippocampalInflammationFactor { get; internal set; }

        // ------------------------------------------------------------
        // Partial method implementation for limbic system reset
        // ------------------------------------------------------------
        partial void ResetLimbic()
        {
            AmygdalaFunction = 1.0;
            FearResponseAmplitude = 1.0;
            AggressionInhibition = 1.0;
            DisorganizedAggression = false;
            EmotionalRegulation = 1.0;
            EmotionalInstability = false;
            PainAffectModulator = 1.0;
            MemoryFormationCapability = 1.0;
            AnterogradeAmnesia = false;
            MammillaryMemoryRelay = 1.0;
            RetrogradeAmnesia = false;
            SpatialMemory = 1.0;
            RewardSensitivity = 1.0;
            MotivationDrive = 1.0;
            Anhedonia = false;
            PleasureResponse = 1.0;
            StressResponseAmplifier = 1.0;
            CingulateStressModulation = 1.0;
            LimbicSystemFunction = 1.0;
            HippocampalInflammationFactor = 0.0;
        }
    }
}