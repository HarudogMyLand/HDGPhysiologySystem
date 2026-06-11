using System;

namespace Physiology.Organs.OrganImplementation.Brain
{
    /// <summary>
    /// Central signal board for the brain. 
    /// Updated internally by the Brain class each tick.
    /// Read by the Homeostasis System to affect other organs.
    /// No external organ calls this board directly.
    /// </summary>
    public class BrainSignalBoard
    {
        // ========== Neural Signals ==========
        /// <summary>Consciousness state: true = conscious, false = unconscious/coma.</summary>
        public bool IsConscious { get; internal set; } = true;

        /// <summary>Motor coordination value (0 = none, 1 = perfect).</summary>
        public double MotorCoordination { get; internal set; } = 1.0;

        /// <summary>Perceived pain level (0 = no pain, 1 = maximum).</summary>
        public double PainSignal { get; internal set; } = 0.0;

        /// <summary>Respiratory drive (0 = stopped, 1 = normal, >1 = hyperventilation).</summary>
        public double RespiratoryDrive { get; internal set; } = 1.0;

        public bool BrainstemReticularFormationActive { get; internal set; } = true;
        public double CerebellumFunction { get; internal set; } = 1.0;
        public bool HasPainInput { get; internal set; }
        public double PainInputStrength { get; internal set; }
        public double CognitiveFunction { get; internal set; } = 1.0;
        public bool HasVision { get; internal set; } = true;
        public bool HasHearing { get; internal set; } = true;
        public bool CanSpeak { get; internal set; } = true;
        
        // ========== Hormonal Signals ==========
        /// <summary>Antidiuretic hormone (ADH) level (0-1). Regulates water retention.</summary>
        public double AntidiureticHormone { get; internal set; } = 0.0;

        /// <summary>Stress hormone (cortisol) releasing factor (0-1).</summary>
        public double StressHormoneLevel { get; internal set; } = 0.0;

        // ========== Immune Signals ==========
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

        // ========== Composite / Derived ==========
        /// <summary>Overall brain function (0 = dead, 1 = fully healthy). Derived from other signals.</summary>
        public double OverallFunction { get; internal set; } = 1.0;

        // Meninges signals
        /// <summary>Intracranial pressure increase above normal (mmHg).</summary>
        public double IntracranialPressureDelta { get; internal set; }
    
        /// <summary>Inflammation level of meninges (0..1).</summary>
        public double MeningealInflammation { get; internal set; }
    
        /// <summary>Active subarachnoid hemorrhage marker.</summary>
        public bool HasSubarachnoidHemorrhage { get; internal set; }
        
        // Diencephalon specific
        public double ThalamicSensoryRelay { get; internal set; } = 1.0;
        public double SubthalamicMotorRegulation { get; internal set; } = 1.0;
        public double MelatoninProduction { get; internal set; } = 1.0;
        public double StressInputFactor { get; internal set; } = 0.5;   // from periphery
        public double CorticotropinReleasingHormone { get; internal set; }
        public double ThyrotropinReleasingHormone { get; internal set; }
        public double GonadotropinReleasingHormone { get; internal set; }
        public double AntidiureticHormoneProduction { get; internal set; } = 1.0;
        public double BodyHydrationFactor { get; internal set; } = 1.0;
        public double OxytocinProduction { get; internal set; }
        public double GrowthHormoneReleasingHormone { get; internal set; }
        public double SympatheticTone { get; internal set; } = 0.5;
        public double ParasympatheticTone { get; internal set; } = 0.5;
        public double ThermoregulationCapability { get; internal set; } = 1.0;
        public bool BodyTemperatureRegulationFailure { get; internal set; }
        public double HungerRegulation { get; internal set; } = 1.0;
        public double ThirstRegulation { get; internal set; } = 1.0;
        public double CircadianRhythmIntegrity { get; internal set; } = 1.0;
        public double FeverResponseCapability { get; internal set; } = 1.0;
        public double DiencephalonFunction { get; internal set; } = 1.0;
        // Cerebellum specific
        public double CerebellarMotorCoordination { get; internal set; } = 1.0;
        public double BalanceCapability { get; internal set; } = 1.0;
        public bool PosturalInstability { get; internal set; }
        public double FineMotorControl { get; internal set; } = 1.0;
        public double MuscleTone { get; internal set; } = 1.0;
        public bool GaitAtaxia { get; internal set; }
        public bool LimbAtaxia { get; internal set; }
        public bool Nystagmus { get; internal set; }
        public double CerebellarMotorReadiness { get; internal set; } = 1.0;
        public bool IntentionTremor { get; internal set; }
        public double ReflexGainMultiplier { get; internal set; } = 1.0; 
        
        
        // Limbic system specific
        public double AmygdalaFunction { get; internal set; } = 1.0;
        public double FearResponseAmplitude { get; internal set; } = 1.0;
        public double AggressionInhibition { get; internal set; } = 1.0;
        public bool DisorganizedAggression { get; internal set; }
        public double EmotionalRegulation { get; internal set; } = 1.0;
        public bool EmotionalInstability { get; internal set; }
        public double PainAffectModulator { get; internal set; } = 1.0;
        public double MemoryFormationCapability { get; internal set; } = 1.0;
        public bool AnterogradeAmnesia { get; internal set; }
        public double MammillaryMemoryRelay { get; internal set; } = 1.0;
        public bool RetrogradeAmnesia { get; internal set; }
        public double SpatialMemory { get; internal set; } = 1.0;
        public double RewardSensitivity { get; internal set; } = 1.0;
        public double MotivationDrive { get; internal set; } = 1.0;
        public bool Anhedonia { get; internal set; }
        public double PleasureResponse { get; internal set; } = 1.0;
        public double StressResponseAmplifier { get; internal set; } = 1.0;
        public double CingulateStressModulation { get; internal set; } = 1.0;
        public double LimbicSystemFunction { get; internal set; } = 1.0;
        public double HippocampalInflammationFactor { get; internal set; }
        
        // Brainstem specific
        public double CardiacCenterFunction { get; internal set; } = 1.0;
        public double VasomotorCenterFunction { get; internal set; } = 1.0;
        public double BaroreceptorReflexGain { get; internal set; } = 1.0;
        public double ReticularActivatingSystem { get; internal set; } = 1.0;
        public double PupillaryLightReflex { get; internal set; } = 1.0;
        public double CornealReflex { get; internal set; } = 1.0;
        public double GagReflex { get; internal set; } = 1.0;
        public double CoughReflex { get; internal set; } = 1.0;
        public double FacialMotorFunction { get; internal set; } = 1.0;
        public double EyeMovementControl { get; internal set; } = 1.0;
        public double SwallowingFunction { get; internal set; } = 1.0;
        public double VocalCordControl { get; internal set; } = 1.0;
        public double DescendingPainInhibition { get; internal set; } = 1.0;
        public double SleepWakeCycleIntegrity { get; internal set; } = 1.0;
        public double SympatheticOutflowStrength { get; internal set; } = 0.5;
        public double ParasympatheticOutflowStrength { get; internal set; } = 0.5;
        public double BrainstemFunction { get; internal set; } = 1.0;
        public bool BrainstemCriticalFailure { get; internal set; }
        /// <summary>Resets all signals to default (healthy) values.</summary>
        internal void ResetToHealthy()
        {
            IsConscious = true;
            MotorCoordination = 1.0;
            PainSignal = 0.0;
            RespiratoryDrive = 1.0;
            CorticotropinReleasingHormone = 0.0;
            AntidiureticHormone = 0.0;
            StressHormoneLevel = 0.0;
            ThyrotropinReleasingHormone = 0.0;
            Interleukin1 = 0.0;
            Interleukin6 = 0.0;
            TumorNecrosisFactorAlpha = 0.0;
            NeuroinflammationMarker = 0.0;
            MicrogliaActivation = 0.0;
            OverallFunction = 1.0;
        }
    }
}