using System;

namespace Physiology.Damage.data
{
    /// <summary>
    /// Data specific to burn trauma.
    /// </summary>
    public readonly record struct BurnData : IDamageData
    {
        /// <summary>
        /// Temperature applied to tissue (Celsius).
        /// </summary>
        public double TemperatureC { get; init; }

        /// <summary>
        /// Duration of heat exposure (seconds).
        /// </summary>
        public double ExposureDuration { get; init; }

        /// <summary>
        /// Total thermal energy transferred (Joules). Combined effect of temperature and duration.
        /// </summary>
        public double ThermalEnergy { get; init; }

        /// <summary>
        /// Burn depth classification (Superficial, PartialThickness, FullThickness).
        /// </summary>
        public BurnDepth Depth { get; init; }

        /// <summary>
        /// Percentage of body surface area affected (0-100%). For localized burns this is small.
        /// </summary>
        public double BodySurfaceAreaPercentage { get; init; }

        /// <summary>
        /// Whether the burn is caused by direct flame, hot liquid, steam, or radiant heat.
        /// </summary>
        public BurnSource Source { get; init; }

        /// <summary>
        /// Presence of smoke inhalation injury (affects lungs, blood oxygen).
        /// </summary>
        public bool HasSmokeInhalation { get; init; }

        /// <summary>
        /// Toxicity of burning materials (0 = none, 1 = highly toxic fumes).
        /// </summary>
        public double FumeToxicity { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BurnData"/> struct.
        /// </summary>
        public BurnData(
            double temperatureC,
            double exposureDuration,
            double thermalEnergy,
            BurnDepth depth,
            double bodySurfaceAreaPercentage,
            BurnSource source,
            bool hasSmokeInhalation,
            double fumeToxicity)
        {
            TemperatureC = temperatureC;
            ExposureDuration = exposureDuration;
            ThermalEnergy = thermalEnergy;
            Depth = depth;
            BodySurfaceAreaPercentage = bodySurfaceAreaPercentage;
            Source = source;
            HasSmokeInhalation = hasSmokeInhalation;
            FumeToxicity = fumeToxicity;
        }
    }

    /// <summary>
    /// Burn depth classification.
    /// </summary>
    public enum BurnDepth
    {
        Superficial,      // Epidermis only (1st degree)
        PartialThickness, // Epidermis + dermis (2nd degree)
        FullThickness     // Subcutaneous tissue damage (3rd degree)
    }

    /// <summary>
    /// Source of burn injury.
    /// </summary>
    public enum BurnSource
    {
        Flame,
        Scald,      // Hot liquid/steam
        Contact,    // Hot solid object
        Radiant,    // Heat radiation (e.g., explosion flash)
        Chemical    // Thermal component of chemical burn
    }
}