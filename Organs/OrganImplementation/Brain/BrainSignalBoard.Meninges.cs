namespace Physiology.Organs.OrganImplementation.Brain
{
    public partial class BrainSignalBoard
    {
        // ============================================================
        // IMMUNE & INFLAMMATORY SIGNALS (cytokines, meninges)
        // ============================================================

        /// <summary>Interleukin-1 (IL-1) level (0-1). Induces fever and sickness behavior.</summary>
        public double Interleukin1 { get; internal set; } = 0.0;

        /// <summary>Interleukin-6 (IL-6) level (0-1). Pro-inflammatory.</summary>
        public double Interleukin6 { get; internal set; } = 0.0;

        /// <summary>Tumor necrosis factor alpha (TNF-α) level (0-1).</summary>
        public double TumorNecrosisFactorAlpha { get; internal set; } = 0.0;

        /// <summary>Neuroinflammation marker (0 = none, 1 = severe).</summary>
        public double NeuroinflammationMarker { get; internal set; } = 0.0;

        /// <summary>Microglia activation level (0 = resting, 1 = fully activated).</summary>
        public double MicrogliaActivation { get; internal set; } = 0.0;

        /// <summary>Meningeal inflammation (0-1).</summary>
        public double MeningealInflammation { get; internal set; }

        /// <summary>Active subarachnoid hemorrhage marker.</summary>
        public bool HasSubarachnoidHemorrhage { get; internal set; }

        /// <summary>Intracranial pressure increase above normal (mmHg).</summary>
        public double IntracranialPressureDelta { get; internal set; }

        // ------------------------------------------------------------
        // Partial method implementation for immune/meninges reset
        // ------------------------------------------------------------
        partial void ResetImmune()
        {
            Interleukin1 = 0.0;
            Interleukin6 = 0.0;
            TumorNecrosisFactorAlpha = 0.0;
            NeuroinflammationMarker = 0.0;
            MicrogliaActivation = 0.0;
            MeningealInflammation = 0.0;
            HasSubarachnoidHemorrhage = false;
            IntracranialPressureDelta = 0.0;
        }
    }
}