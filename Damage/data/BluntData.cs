using System;

namespace Physiology.Damage.data
{
    /// <summary>
    /// Data specific to blunt force trauma.
    /// </summary>
    public readonly record struct BluntData : IDamageData
    {
        /// <summary>
        /// Impact force in Newtons (N). Determines tissue compression and fracture risk.
        /// </summary>
        public double ImpactForce { get; init; }

        /// <summary>
        /// Contact area in square meters (m²). Smaller area increases pressure.
        /// </summary>
        public double ContactArea { get; init; }

        /// <summary>
        /// Duration of impact in milliseconds (ms). Longer duration may spread energy.
        /// </summary>
        public double ImpactDurationMs { get; init; }

        /// <summary>
        /// Whether the impact is concentrated (e.g., hammer) vs diffuse (e.g., fall on flat surface).
        /// </summary>
        public bool IsConcentrated { get; init; }

        /// <summary>
        /// Blunt object material hardness (e.g., 0=soft rubber, 1=hard steel).
        /// </summary>
        public double Hardness { get; init; }

        /// <summary>
        /// Depth of underlying bone/structure from skin surface in meters.
        /// </summary>
        public double BoneDepthM { get; init; }

        /// <summary>
        /// Calculated pressure in Pascals (Pa). Optional derived field.
        /// </summary>
        public double PressurePa => ImpactForce / ContactArea;

        /// <summary>
        /// Initializes a new instance of the <see cref="BluntData"/> struct.
        /// </summary>
        public BluntData(
            double impactForce,
            double contactArea,
            double impactDurationMs,
            bool isConcentrated,
            double hardness,
            double boneDepthM)
        {
            ImpactForce = impactForce;
            ContactArea = contactArea;
            ImpactDurationMs = impactDurationMs;
            IsConcentrated = isConcentrated;
            Hardness = hardness;
            BoneDepthM = boneDepthM;
        }
    }
}
