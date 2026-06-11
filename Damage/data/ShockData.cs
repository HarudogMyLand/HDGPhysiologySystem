using System;

namespace Physiology.Damage.data
{
    /// <summary>
    /// Data specific to shock (blast overpressure / concussive) trauma.
    /// </summary>
    public readonly record struct ShockData : IDamageData
    {
        /// <summary>
        /// Peak overpressure in Pascals (Pa). Primary damage determinant for blast wave.
        /// </summary>
        public double PeakOverpressurePa { get; init; }

        /// <summary>
        /// Duration of the positive pressure phase (milliseconds).
        /// </summary>
        public double PositivePhaseDurationMs { get; init; }

        /// <summary>
        /// Impulse (Pa·s) – integral of pressure over time. Correlates with organ rupture risk.
        /// </summary>
        public double Impulse { get; init; }

        /// <summary>
        /// Distance from explosion epicenter (meters). Used to calculate pressure decay.
        /// </summary>
        public double DistanceFromEpicenter { get; init; }

        /// <summary>
        /// Whether the subject is in an enclosed space (increases reflected pressure).
        /// </summary>
        public bool IsEnclosedSpace { get; init; }

        /// <summary>
        /// Presence of penetrating fragments (secondary blast injury). Often combined with PierceData.
        /// </summary>
        public bool HasFragments { get; init; }

        /// <summary>
        /// Level of whole-body translation (m/s²). Causes blunt inertial injuries.
        /// </summary>
        public double AccelerationG { get; init; }

        /// <summary>
        /// Direction of blast wave relative to body (0° = frontal, 90° = lateral, etc.)
        /// </summary>
        public double AngleOfAttackDeg { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShockData"/> struct.
        /// </summary>
        public ShockData(
            double peakOverpressurePa,
            double positivePhaseDurationMs,
            double impulse,
            double distanceFromEpicenter,
            bool isEnclosedSpace,
            bool hasFragments,
            double accelerationG,
            double angleOfAttackDeg)
        {
            PeakOverpressurePa = peakOverpressurePa;
            PositivePhaseDurationMs = positivePhaseDurationMs;
            Impulse = impulse;
            DistanceFromEpicenter = distanceFromEpicenter;
            IsEnclosedSpace = isEnclosedSpace;
            HasFragments = hasFragments;
            AccelerationG = accelerationG;
            AngleOfAttackDeg = angleOfAttackDeg;
        }
    }
}