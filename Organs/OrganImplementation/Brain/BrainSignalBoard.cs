using System;

namespace Physiology.Organs.OrganImplementation.Brain
{
    /// <summary>
    /// Central signal board for the brain.
    /// Updated internally by the Brain class each tick.
    /// Read by the Homeostasis System to affect other organs.
    /// </summary>
    public partial class BrainSignalBoard
    {
        // ============================================================
        // COMPOSITE / DERIVED – Overall brain health
        // ============================================================
        /// <summary>Overall brain function (0 = dead, 1 = fully healthy). Derived from other signals.</summary>
        public double OverallFunction { get; internal set; } = 1.0;

        // ============================================================
        // RESET LIFECYCLE – partial method declarations
        // ============================================================

        partial void ResetBrainstem();
        partial void ResetCerebellum();
        partial void ResetDiencephalon();
        partial void ResetLimbic();
        partial void ResetCortical();
        partial void ResetImmune();

        /// <summary>Resets all signals to default (healthy) values.</summary>
        internal void ResetToHealthy()
        {
            ResetBrainstem();
            ResetCerebellum();
            ResetDiencephalon();
            ResetLimbic();
            ResetCortical();
            ResetImmune();

            OverallFunction = 1.0;
        }
    }
}