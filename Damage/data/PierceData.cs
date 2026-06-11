using System;

namespace Physiology.Damage.data
{
    /// <summary>
    /// Data specific to piercing (penetrating) trauma.
    /// </summary>
    public readonly record struct PierceData : IDamageData
    {
        /// <summary>
        /// Kinetic energy in Joules (J). Primary factor for tissue disruption.
        /// </summary>
        public double KineticEnergy { get; init; }

        /// <summary>
        /// Cross-sectional area of the projectile in square meters (m²). Affects wound cavity size.
        /// </summary>
        public double CrossSectionArea { get; init; }

        /// <summary>
        /// Projectile caliber in millimeters (mm). Alternative to CrossSectionArea.
        /// </summary>
        public double CaliberMm { get; init; }

        /// <summary>
        /// Penetration depth in soft tissue (meters). Could be derived from ballistic models.
        /// </summary>
        public double PenetrationDepthM { get; init; }

        /// <summary>
        /// Whether the projectile tumbles or fragments inside the body (increases damage).
        /// </summary>
        public bool IsTumbling { get; init; }

        /// <summary>
        /// Whether the projectile is armor-piercing (reduced damage loss against hard targets).
        /// </summary>
        public bool IsArmorPiercing { get; init; }

        /// <summary>
        /// Velocity at impact (meters per second).
        /// </summary>
        public double ImpactVelocity { get; init; }

        /// <summary>
        /// Projectile mass in kilograms (kg).
        /// </summary>
        public double ProjectileMass { get; init; }

        /// <summary>
        /// Drag coefficient (0~1) for tissue resistance.
        /// </summary>
        public double DragCoefficient { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PierceData"/> struct.
        /// </summary>
        public PierceData(
            double kineticEnergy,
            double crossSectionArea,
            double caliberMm,
            double penetrationDepthM,
            bool isTumbling,
            bool isArmorPiercing,
            double impactVelocity,
            double projectileMass,
            double dragCoefficient)
        {
            KineticEnergy = kineticEnergy;
            CrossSectionArea = crossSectionArea;
            CaliberMm = caliberMm;
            PenetrationDepthM = penetrationDepthM;
            IsTumbling = isTumbling;
            IsArmorPiercing = isArmorPiercing;
            ImpactVelocity = impactVelocity;
            ProjectileMass = projectileMass;
            DragCoefficient = dragCoefficient;
        }
    }
}