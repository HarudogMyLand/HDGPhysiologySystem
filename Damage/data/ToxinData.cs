using System;
using Physiology.Organs;

namespace Physiology.Damage.data
{
    // A data package of a poison, the data of a poison should be encoded in 
    // json or dataset, and initialized and cached in package once created.

    /// <summary>
    /// Information when a poison damage happens
    /// </summary>
    public readonly record struct ToxinData : IDamageData
    {
        /// <summary>
        /// Name of the toxin substance
        /// </summary>
        public string ToxinName { get; init; }

        /// <summary>
        /// Description of the toxin
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// Which organs the poison affects
        /// </summary>
        public OrganNames PrimaryTarget { get; init; }

        /// <summary>
        /// Duration of effect (seconds)
        /// </summary>
        public double Duration { get; init; }

        /// <summary>
        /// Toxicity level (arbitrary scale, or could be mg/kg)
        /// </summary>
        public double Toxicity { get; init; }

        /// <summary>
        /// Route of exposure
        /// </summary>
        public ExposureRoute Route { get; init; }

        /// <summary>
        /// Least death amount 50%
        /// </summary>
        public double LD50 { get; init; }

        /// <summary>
        /// Latency period before symptoms appear (seconds)
        /// </summary>
        public double Latency { get; init; }

        /// <summary>
        /// Whether the toxin accumulates in the body
        /// </summary>
        public bool IsCumulative { get; init; }

        /// <summary>
        /// Antidote name or treatment
        /// </summary>
        public string Antidote { get; init; }

        /// <summary>
        /// Half life if metabolizable (seconds)
        /// </summary>
        public double HalfLife { get; init; }

        /// <summary>
        /// Whether the toxin is metabolizable
        /// </summary>
        public bool IsMetabolizable { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToxinData"/> struct.
        /// </summary>
        public ToxinData(
            string toxinName,
            string description,
            OrganNames primaryTarget,
            double duration,
            double toxicity,
            ExposureRoute route,
            double ld50,
            double latency,
            bool isCumulative,
            string antidote,
            double halfLife,
            bool isMetabolizable)
        {
            ToxinName = toxinName;
            Description = description;
            PrimaryTarget = primaryTarget;
            Duration = duration;
            Toxicity = toxicity;
            Route = route;
            LD50 = ld50;
            Latency = latency;
            IsCumulative = isCumulative;
            Antidote = antidote;
            HalfLife = halfLife;
            IsMetabolizable = isMetabolizable;
        }
    }
}