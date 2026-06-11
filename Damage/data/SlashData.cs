using System;

namespace Physiology.Damage.data
{
    /// <summary>
    /// Data specific to slashing (cutting) trauma.
    /// </summary>
    public readonly record struct SlashData : IDamageData
    {
        /// <summary>
        /// Edge sharpness factor (0 = dull, 1 = razor sharp). Affects cutting efficiency.
        /// </summary>
        public double EdgeSharpness { get; init; }

        /// <summary>
        /// Blade length that contacts tissue (meters). Longer contact may cut more structures.
        /// </summary>
        public double ContactLength { get; init; }

        /// <summary>
        /// Depth of cut into tissue (meters). Determines vascular/nerve damage.
        /// </summary>
        public double CutDepth { get; init; }

        /// <summary>
        /// Relative velocity between blade and tissue (meters per second).
        /// </summary>
        public double SlashVelocity { get; init; }

        /// <summary>
        /// Angle of attack relative to skin surface (degrees). 90° = perpendicular chop, shallow angle = slice.
        /// </summary>
        public double AttackAngleDeg { get; init; }

        /// <summary>
        /// Whether the blade is serrated (increases tearing vs clean cut).
        /// </summary>
        public bool IsSerrated { get; init; }

        /// <summary>
        /// Mass of the blade (kg). Heavier blades impart more kinetic energy.
        /// </summary>
        public double BladeMass { get; init; }

        /// <summary>
        /// Calculated kinetic energy (J). Optional derived field.
        /// </summary>
        public double KineticEnergy => 0.5 * BladeMass * SlashVelocity * SlashVelocity;

        /// <summary>
        /// Initializes a new instance of the <see cref="SlashData"/> struct.
        /// </summary>
        public SlashData(
            double edgeSharpness,
            double contactLength,
            double cutDepth,
            double slashVelocity,
            double attackAngleDeg,
            bool isSerrated,
            double bladeMass)
        {
            EdgeSharpness = edgeSharpness;
            ContactLength = contactLength;
            CutDepth = cutDepth;
            SlashVelocity = slashVelocity;
            AttackAngleDeg = attackAngleDeg;
            IsSerrated = isSerrated;
            BladeMass = bladeMass;
        }
    }
}