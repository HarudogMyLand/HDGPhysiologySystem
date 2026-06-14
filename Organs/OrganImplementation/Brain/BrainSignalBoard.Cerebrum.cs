namespace Physiology.Organs.OrganImplementation.Brain
{
    public partial class BrainSignalBoard
    {
        // ============================================================
        // HIGHER CORTICAL / SENSORY & MOTOR OUTPUT
        // ============================================================

        /// <summary>Motor coordination value (0 = none, 1 = perfect).</summary>
        public double MotorCoordination { get; internal set; } = 1.0;

        /// <summary>Perceived pain level (0 = no pain, 1 = maximum).</summary>
        public double PainSignal { get; internal set; } = 0.0;

        /// <summary>Pain input presence flag.</summary>
        public bool HasPainInput { get; internal set; }

        /// <summary>Pain input strength (0-1).</summary>
        public double PainInputStrength { get; internal set; }

        /// <summary>Cognitive function (0 = deep coma, 1 = normal).</summary>
        public double CognitiveFunction { get; internal set; } = 1.0;

        /// <summary>Vision functional flag.</summary>
        public bool HasVision { get; internal set; } = true;

        /// <summary>Hearing functional flag.</summary>
        public bool HasHearing { get; internal set; } = true;

        /// <summary>Speech ability flag.</summary>
        public bool CanSpeak { get; internal set; } = true;

        // ------------------------------------------------------------
        // Partial method implementation for cortical reset
        // ------------------------------------------------------------
        partial void ResetCortical()
        {
            MotorCoordination = 1.0;
            PainSignal = 0.0;
            HasPainInput = false;
            PainInputStrength = 0.0;
            CognitiveFunction = 1.0;
            HasVision = true;
            HasHearing = true;
            CanSpeak = true;
        }
    }
}