namespace Physiology.Organs.OrganImplementation.Brain
{
    public partial class BrainSignalBoard
    {
        // ============================================================
        // DIENCEPHALON (Thalamus, Hypothalamus, Subthalamus, Epithalamus)
        // – Homeostasis, hormones, circadian, autonomic integration
        // ============================================================

        /// <summary>Thalamic sensory relay fidelity (0 = blocked, 1 = normal).</summary>
        public double ThalamicSensoryRelay { get; internal set; } = 1.0;

        /// <summary>Subthalamic motor regulation (0 = absent, 1 = normal).</summary>
        public double SubthalamicMotorRegulation { get; internal set; } = 1.0;

        /// <summary>Melatonin production (0 = none, 1 = normal).</summary>
        public double MelatoninProduction { get; internal set; } = 1.0;

        /// <summary>Stress input from periphery (0 = none, 1 = maximal).</summary>
        public double StressInputFactor { get; internal set; } = 0.5;

        /// <summary>Corticotropin releasing hormone (CRH) level (0-1).</summary>
        public double CorticotropinReleasingHormone { get; internal set; }

        /// <summary>Thyrotropin releasing hormone (TRH) level (0-1).</summary>
        public double ThyrotropinReleasingHormone { get; internal set; }

        /// <summary>Gonadotropin releasing hormone (GnRH) level (0-1).</summary>
        public double GonadotropinReleasingHormone { get; internal set; }

        /// <summary>Antidiuretic hormone (ADH) production capacity (0 = none, 1 = normal).</summary>
        public double AntidiureticHormoneProduction { get; internal set; } = 1.0;

        /// <summary>Body hydration factor (0 = severe dehydration, 1 = euhydration).</summary>
        public double BodyHydrationFactor { get; internal set; } = 1.0;

        /// <summary>Oxytocin production level (0-1).</summary>
        public double OxytocinProduction { get; internal set; }

        /// <summary>Growth hormone releasing hormone (GHRH) level (0-1).</summary>
        public double GrowthHormoneReleasingHormone { get; internal set; }

        /// <summary>Sympathetic tone (0 = none, 1 = maximal).</summary>
        public double SympatheticTone { get; internal set; } = 0.5;

        /// <summary>Parasympathetic tone (0 = none, 1 = maximal).</summary>
        public double ParasympatheticTone { get; internal set; } = 0.5;

        /// <summary>Thermoregulation capability (0 = failed, 1 = normal).</summary>
        public double ThermoregulationCapability { get; internal set; } = 1.0;

        /// <summary>Body temperature regulation failure flag.</summary>
        public bool BodyTemperatureRegulationFailure { get; internal set; }

        /// <summary>Hunger regulation (0 = absent, 1 = normal).</summary>
        public double HungerRegulation { get; internal set; } = 1.0;

        /// <summary>Thirst regulation (0 = absent, 1 = normal).</summary>
        public double ThirstRegulation { get; internal set; } = 1.0;

        /// <summary>Circadian rhythm integrity (0 = disrupted, 1 = normal).</summary>
        public double CircadianRhythmIntegrity { get; internal set; } = 1.0;

        /// <summary>Fever response capability (0 = absent, 1 = normal).</summary>
        public double FeverResponseCapability { get; internal set; } = 1.0;

        /// <summary>Overall diencephalon function (0-1).</summary>
        public double DiencephalonFunction { get; internal set; } = 1.0;

        // Hormonal outputs (hypothalamus / pituitary axis)
        /// <summary>Antidiuretic hormone (ADH) level (0-1). Regulates water retention.</summary>
        public double AntidiureticHormone { get; internal set; } = 0.0;

        /// <summary>Stress hormone (cortisol) releasing factor (0-1).</summary>
        public double StressHormoneLevel { get; internal set; } = 0.0;

        // ------------------------------------------------------------
        // Partial method implementation for diencephalon reset
        // ------------------------------------------------------------
        partial void ResetDiencephalon()
        {
            ThalamicSensoryRelay = 1.0;
            SubthalamicMotorRegulation = 1.0;
            MelatoninProduction = 1.0;
            StressInputFactor = 0.5;
            CorticotropinReleasingHormone = 0.0;
            ThyrotropinReleasingHormone = 0.0;
            GonadotropinReleasingHormone = 0.0;
            AntidiureticHormoneProduction = 1.0;
            BodyHydrationFactor = 1.0;
            OxytocinProduction = 0.0;
            GrowthHormoneReleasingHormone = 0.0;
            SympatheticTone = 0.5;
            ParasympatheticTone = 0.5;
            ThermoregulationCapability = 1.0;
            BodyTemperatureRegulationFailure = false;
            HungerRegulation = 1.0;
            ThirstRegulation = 1.0;
            CircadianRhythmIntegrity = 1.0;
            FeverResponseCapability = 1.0;
            DiencephalonFunction = 1.0;
            AntidiureticHormone = 0.0;
            StressHormoneLevel = 0.0;
        }
    }
}