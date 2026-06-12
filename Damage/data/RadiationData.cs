using System;

namespace Physiology.Damage.data
{
    /// <summary>
    /// Data specific to ionizing radiation injury.
    /// </summary>
    public readonly record struct RadiationData : IDamageData
    {
        /// <summary>
        /// Absorbed dose in Gray (Gy). Direct measure of energy deposited per kilogram of tissue.
        /// </summary>
        public double AbsorbedDoseGy { get; init; }

        /// <summary>
        /// Equivalent dose in Sievert (Sv). Includes radiation type weighting factor.
        /// </summary>
        public double EquivalentDoseSv { get; init; }

        /// <summary>
        /// Dose rate (Gy per second). Acute high rate vs chronic low rate have different effects.
        /// </summary>
        public double DoseRate { get; init; }

        /// <summary>
        /// Radiation type: Gamma, Neutron, Beta, Alpha.
        /// </summary>
        public RadiationType Type { get; init; }

        /// <summary>
        /// Whether exposure is whole-body or partial (e.g., localized hand exposure).
        /// </summary>
        public bool IsWholeBody { get; init; }

        /// <summary>
        /// Body region affected if partial exposure (e.g., "RightArm", "Head").
        /// </summary>
        public string AffectedRegion { get; init; }

        /// <summary>
        /// Time after exposure in hours (for tracking ARS progression).
        /// </summary>
        public double TimeSinceExposureHours { get; init; }

        /// <summary>
        /// Contamination present on skin or inhaled/ingested (prolongs exposure).
        /// </summary>
        public bool HasInternalContamination { get; init; }

        /// <summary>
        /// Whether protective measures (e.g., KI pills, shielding) are active.
        /// </summary>
        public bool HasProtection { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RadiationData"/> struct.
        /// </summary>
        public RadiationData(
            double absorbedDoseGy,
            double equivalentDoseSv,
            double doseRate,
            RadiationType type,
            bool isWholeBody,
            string affectedRegion,
            double timeSinceExposureHours,
            bool hasInternalContamination,
            bool hasProtection)
        {
            AbsorbedDoseGy = absorbedDoseGy;
            EquivalentDoseSv = equivalentDoseSv;
            DoseRate = doseRate;
            Type = type;
            IsWholeBody = isWholeBody;
            AffectedRegion = affectedRegion;
            TimeSinceExposureHours = timeSinceExposureHours;
            HasInternalContamination = hasInternalContamination;
            HasProtection = hasProtection;
        }
    }

    /// <summary>
    /// Types of ionizing radiation.
    /// </summary>
    public enum RadiationType
    {
        Alpha,      // Helium nucleus, low penetration, high ionizing if ingested/inhaled
        Beta,       // Electron, moderate penetration
        Gamma,      // High-energy photon, high penetration
        Neutron,    // Neutron particle, very damaging, requires special shielding
        XRay        // Similar to gamma but from medical devices
    }
}