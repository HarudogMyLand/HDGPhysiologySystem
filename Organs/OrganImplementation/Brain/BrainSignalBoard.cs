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
        // ============================================================
        // 1. BRAINSTEM – Vital signs, reflexes, arousal, autonomic outflow
        // ============================================================
        /// <summary>Consciousness state: true = conscious, false = unconscious/coma.</summary>
        public bool IsConscious { get; internal set; } = true;

        /// <summary>Reticular activating system integrity (0 = failed, 1 = normal).</summary>
        public double ReticularActivatingSystem { get; internal set; } = 1.0;

        /// <summary>Brainstem reticular formation active (consciousness support).</summary>
        public bool BrainstemReticularFormationActive { get; internal set; } = true;

        /// <summary>Respiratory drive (0 = stopped, 1 = normal, >1 = hyperventilation).</summary>
        public double RespiratoryDrive { get; internal set; } = 1.0;

        /// <summary>Cardiac center function (0 = failed, 1 = normal).</summary>
        public double CardiacCenterFunction { get; internal set; } = 1.0;

        /// <summary>Vasomotor center function (blood pressure regulation).</summary>
        public double VasomotorCenterFunction { get; internal set; } = 1.0;

        /// <summary>Baroreceptor reflex gain (0 = absent, 1 = normal).</summary>
        public double BaroreceptorReflexGain { get; internal set; } = 1.0;

        /// <summary>Sympathetic outflow strength (0 = none, 1 = maximal).</summary>
        public double SympatheticOutflowStrength { get; internal set; } = 0.5;

        /// <summary>Parasympathetic outflow strength (0 = none, 1 = maximal).</summary>
        public double ParasympatheticOutflowStrength { get; internal set; } = 0.5;

        /// <summary>Pupillary light reflex (0 = absent, 1 = normal).</summary>
        public double PupillaryLightReflex { get; internal set; } = 1.0;

        /// <summary>Corneal reflex (0 = absent, 1 = normal).</summary>
        public double CornealReflex { get; internal set; } = 1.0;

        /// <summary>Gag reflex (0 = absent, 1 = normal).</summary>
        public double GagReflex { get; internal set; } = 1.0;

        /// <summary>Cough reflex (0 = absent, 1 = normal).</summary>
        public double CoughReflex { get; internal set; } = 1.0;

        /// <summary>Facial motor function (0 = complete palsy, 1 = normal).</summary>
        public double FacialMotorFunction { get; internal set; } = 1.0;

        /// <summary>Eye movement control (0 = none, 1 = full).</summary>
        public double EyeMovementControl { get; internal set; } = 1.0;

        /// <summary>Swallowing function (0 = absent, 1 = normal).</summary>
        public double SwallowingFunction { get; internal set; } = 1.0;

        /// <summary>Vocal cord control (0 = none, 1 = normal).</summary>
        public double VocalCordControl { get; internal set; } = 1.0;

        /// <summary>Descending pain inhibition (0 = none, 1 = full).</summary>
        public double DescendingPainInhibition { get; internal set; } = 1.0;

        /// <summary>Sleep-wake cycle integrity (0 = disrupted, 1 = normal).</summary>
        public double SleepWakeCycleIntegrity { get; internal set; } = 1.0;

        /// <summary>Overall brainstem function (0 = dead, 1 = healthy).</summary>
        public double BrainstemFunction { get; internal set; } = 1.0;

        /// <summary>Catastrophic brainstem failure flag.</summary>
        public bool BrainstemCriticalFailure { get; internal set; }

        // ============================================================
        // 2. CEREBELLUM – Coordination, balance, motor learning
        // ============================================================
        /// <summary>Cerebellar motor coordination (0 = none, 1 = perfect).</summary>
        public double CerebellarMotorCoordination { get; internal set; } = 1.0;

        /// <summary>Balance capability (0 = unable, 1 = normal).</summary>
        public double BalanceCapability { get; internal set; } = 1.0;

        /// <summary>Postural instability present.</summary>
        public bool PosturalInstability { get; internal set; }

        /// <summary>Fine motor control (0 = none, 1 = normal).</summary>
        public double FineMotorControl { get; internal set; } = 1.0;

        /// <summary>Muscle tone (0 = flaccid, 1 = normal).</summary>
        public double MuscleTone { get; internal set; } = 1.0;

        /// <summary>Gait ataxia present.</summary>
        public bool GaitAtaxia { get; internal set; }

        /// <summary>Limb ataxia present.</summary>
        public bool LimbAtaxia { get; internal set; }

        /// <summary>Nystagmus (involuntary eye movement) present.</summary>
        public bool Nystagmus { get; internal set; }

        /// <summary>Cerebellar motor readiness (0 = impaired, 1 = normal).</summary>
        public double CerebellarMotorReadiness { get; internal set; } = 1.0;

        /// <summary>Intention tremor present.</summary>
        public bool IntentionTremor { get; internal set; }

        /// <summary>Reflex gain multiplier (0 = areflexia, 1 = normal).</summary>
        public double ReflexGainMultiplier { get; internal set; } = 1.0;

        /// <summary>Cerebellum function composite (0-1).</summary>
        public double CerebellumFunction { get; internal set; } = 1.0;

        // ============================================================
        // 3. DIENCEPHALON (Thalamus, Hypothalamus, Subthalamus, Epithalamus)
        //    – Homeostasis, hormones, circadian, autonomic integration
        // ============================================================
        /// <summary>Thalamic sensory relay fidelity (0 = blocked, 1 = normal).</summary>
        public double ThalamicSensoryRelay { get; internal set; } = 1.0;

        /// <summary>Subthalamic motor regulation (0 = absent, 1 = normal).</summary>
        public double SubthalamicMotorRegulation { get; internal set; } = 1.0;

        /// <summary>Melatonin production (0 = none, 1 = normal).</summary>
        public double MelatoninProduction { get; internal set; } = 1.0;

        /// <summary>Stress input from periphery (0 = none, 1 = maximal).</summary>
        public double StressInputFactor { get; internal set; } = 0.5;

        /// <summary>Corticotropin releasing hormone (CRH) level (0-1).</summary>
        public double CorticotropinReleasingHormone { get; internal set; }

        /// <summary>Thyrotropin releasing hormone (TRH) level (0-1).</summary>
        public double ThyrotropinReleasingHormone { get; internal set; }

        /// <summary>Gonadotropin releasing hormone (GnRH) level (0-1).</summary>
        public double GonadotropinReleasingHormone { get; internal set; }

        /// <summary>Antidiuretic hormone (ADH) production capacity (0 = none, 1 = normal).</summary>
        public double AntidiureticHormoneProduction { get; internal set; } = 1.0;

        /// <summary>Body hydration factor (0 = severe dehydration, 1 = euhydration).</summary>
        public double BodyHydrationFactor { get; internal set; } = 1.0;

        /// <summary>Oxytocin production level (0-1).</summary>
        public double OxytocinProduction { get; internal set; }

        /// <summary>Growth hormone releasing hormone (GHRH) level (0-1).</summary>
        public double GrowthHormoneReleasingHormone { get; internal set; }

        /// <summary>Sympathetic tone (0 = none, 1 = maximal).</summary>
        public double SympatheticTone { get; internal set; } = 0.5;

        /// <summary>Parasympathetic tone (0 = none, 1 = maximal).</summary>
        public double ParasympatheticTone { get; internal set; } = 0.5;

        /// <summary>Thermoregulation capability (0 = failed, 1 = normal).</summary>
        public double ThermoregulationCapability { get; internal set; } = 1.0;

        /// <summary>Body temperature regulation failure flag.</summary>
        public bool BodyTemperatureRegulationFailure { get; internal set; }

        /// <summary>Hunger regulation (0 = absent, 1 = normal).</summary>
        public double HungerRegulation { get; internal set; } = 1.0;

        /// <summary>Thirst regulation (0 = absent, 1 = normal).</summary>
        public double ThirstRegulation { get; internal set; } = 1.0;

        /// <summary>Circadian rhythm integrity (0 = disrupted, 1 = normal).</summary>
        public double CircadianRhythmIntegrity { get; internal set; } = 1.0;

        /// <summary>Fever response capability (0 = absent, 1 = normal).</summary>
        public double FeverResponseCapability { get; internal set; } = 1.0;

        /// <summary>Overall diencephalon function (0-1).</summary>
        public double DiencephalonFunction { get; internal set; } = 1.0;

        // ============================================================
        // 4. LIMBIC SYSTEM – Emotion, memory, fear, reward, stress modulation
        // ============================================================
        /// <summary>Amygdala function (0 = ablated, 1 = normal).</summary>
        public double AmygdalaFunction { get; internal set; } = 1.0;

        /// <summary>Fear response amplitude (0 = none, 1 = normal).</summary>
        public double FearResponseAmplitude { get; internal set; } = 1.0;

        /// <summary>Aggression inhibition (0 = disinhibited, 1 = normal).</summary>
        public double AggressionInhibition { get; internal set; } = 1.0;

        /// <summary>Disorganized aggression flag.</summary>
        public bool DisorganizedAggression { get; internal set; }

        /// <summary>Emotional regulation (0 = labile, 1 = stable).</summary>
        public double EmotionalRegulation { get; internal set; } = 1.0;

        /// <summary>Emotional instability flag.</summary>
        public bool EmotionalInstability { get; internal set; }

        /// <summary>Pain affect modulator (0 = no emotional pain, 1 = normal).</summary>
        public double PainAffectModulator { get; internal set; } = 1.0;

        /// <summary>Memory formation capability (0 = none, 1 = normal).</summary>
        public double MemoryFormationCapability { get; internal set; } = 1.0;

        /// <summary>Anterograde amnesia present.</summary>
        public bool AnterogradeAmnesia { get; internal set; }

        /// <summary>Mammillary body memory relay (0 = failed, 1 = normal).</summary>
        public double MammillaryMemoryRelay { get; internal set; } = 1.0;

        /// <summary>Retrograde amnesia present.</summary>
        public bool RetrogradeAmnesia { get; internal set; }

        /// <summary>Spatial memory (0 = absent, 1 = normal).</summary>
        public double SpatialMemory { get; internal set; } = 1.0;

        /// <summary>Reward sensitivity (0 = insensitive, 1 = normal).</summary>
        public double RewardSensitivity { get; internal set; } = 1.0;

        /// <summary>Motivation drive (0 = apathy, 1 = normal).</summary>
        public double MotivationDrive { get; internal set; } = 1.0;

        /// <summary>Anhedonia flag (inability to feel pleasure).</summary>
        public bool Anhedonia { get; internal set; }

        /// <summary>Pleasure response (0 = none, 1 = normal).</summary>
        public double PleasureResponse { get; internal set; } = 1.0;

        /// <summary>Stress response amplifier (1 = normal, >1 = hyper-reactive).</summary>
        public double StressResponseAmplifier { get; internal set; } = 1.0;

        /// <summary>Cingulate stress modulation (0 = failed, 1 = normal).</summary>
        public double CingulateStressModulation { get; internal set; } = 1.0;

        /// <summary>Overall limbic system function (0-1).</summary>
        public double LimbicSystemFunction { get; internal set; } = 1.0;

        /// <summary>Hippocampal inflammation factor (0 = none, 1 = severe).</summary>
        public double HippocampalInflammationFactor { get; internal set; }

        // ============================================================
        // 5. HIGHER CORTICAL / SENSORY & MOTOR OUTPUT
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

        // ============================================================
        // 6. HORMONAL OUTPUTS (from hypothalamus / pituitary axis)
        // ============================================================
        /// <summary>Antidiuretic hormone (ADH) level (0-1). Regulates water retention.</summary>
        public double AntidiureticHormone { get; internal set; } = 0.0;

        /// <summary>Stress hormone (cortisol) releasing factor (0-1).</summary>
        public double StressHormoneLevel { get; internal set; } = 0.0;

        // ============================================================
        // 7. IMMUNE & INFLAMMATORY SIGNALS (cytokines, meninges)
        // ============================================================
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

        /// <summary>Meningeal inflammation (0-1).</summary>
        public double MeningealInflammation { get; internal set; }

        /// <summary>Active subarachnoid hemorrhage marker.</summary>
        public bool HasSubarachnoidHemorrhage { get; internal set; }

        /// <summary>Intracranial pressure increase above normal (mmHg).</summary>
        public double IntracranialPressureDelta { get; internal set; }

        // ============================================================
        // 8. COMPOSITE / DERIVED – Overall brain health
        // ============================================================
        /// <summary>Overall brain function (0 = dead, 1 = fully healthy). Derived from other signals.</summary>
        public double OverallFunction { get; internal set; } = 1.0;

        // ============================================================
        // RESET METHOD – Restores all signals to healthy defaults
        // ============================================================
        /// <summary>Resets all signals to default (healthy) values.</summary>
        internal void ResetToHealthy()
        {
            // Brainstem
            IsConscious = true;
            ReticularActivatingSystem = 1.0;
            BrainstemReticularFormationActive = true;
            RespiratoryDrive = 1.0;
            CardiacCenterFunction = 1.0;
            VasomotorCenterFunction = 1.0;
            BaroreceptorReflexGain = 1.0;
            SympatheticOutflowStrength = 0.5;
            ParasympatheticOutflowStrength = 0.5;
            PupillaryLightReflex = 1.0;
            CornealReflex = 1.0;
            GagReflex = 1.0;
            CoughReflex = 1.0;
            FacialMotorFunction = 1.0;
            EyeMovementControl = 1.0;
            SwallowingFunction = 1.0;
            VocalCordControl = 1.0;
            DescendingPainInhibition = 1.0;
            SleepWakeCycleIntegrity = 1.0;
            BrainstemFunction = 1.0;
            BrainstemCriticalFailure = false;

            // Cerebellum
            CerebellarMotorCoordination = 1.0;
            BalanceCapability = 1.0;
            PosturalInstability = false;
            FineMotorControl = 1.0;
            MuscleTone = 1.0;
            GaitAtaxia = false;
            LimbAtaxia = false;
            Nystagmus = false;
            CerebellarMotorReadiness = 1.0;
            IntentionTremor = false;
            ReflexGainMultiplier = 1.0;
            CerebellumFunction = 1.0;

            // Diencephalon
            ThalamicSensoryRelay = 1.0;
            SubthalamicMotorRegulation = 1.0;
            MelatoninProduction = 1.0;
            StressInputFactor = 0.5;
            CorticotropinReleasingHormone = 0.0;
            ThyrotropinReleasingHormone = 0.0;
            GonadotropinReleasingHormone = 0.0;
            AntidiureticHormoneProduction = 1.0;
            BodyHydrationFactor = 1.0;
            OxytocinProduction = 0.0;
            GrowthHormoneReleasingHormone = 0.0;
            SympatheticTone = 0.5;
            ParasympatheticTone = 0.5;
            ThermoregulationCapability = 1.0;
            BodyTemperatureRegulationFailure = false;
            HungerRegulation = 1.0;
            ThirstRegulation = 1.0;
            CircadianRhythmIntegrity = 1.0;
            FeverResponseCapability = 1.0;
            DiencephalonFunction = 1.0;

            // Limbic system
            AmygdalaFunction = 1.0;
            FearResponseAmplitude = 1.0;
            AggressionInhibition = 1.0;
            DisorganizedAggression = false;
            EmotionalRegulation = 1.0;
            EmotionalInstability = false;
            PainAffectModulator = 1.0;
            MemoryFormationCapability = 1.0;
            AnterogradeAmnesia = false;
            MammillaryMemoryRelay = 1.0;
            RetrogradeAmnesia = false;
            SpatialMemory = 1.0;
            RewardSensitivity = 1.0;
            MotivationDrive = 1.0;
            Anhedonia = false;
            PleasureResponse = 1.0;
            StressResponseAmplifier = 1.0;
            CingulateStressModulation = 1.0;
            LimbicSystemFunction = 1.0;
            HippocampalInflammationFactor = 0.0;

            // Higher cortical / sensory
            MotorCoordination = 1.0;
            PainSignal = 0.0;
            HasPainInput = false;
            PainInputStrength = 0.0;
            CognitiveFunction = 1.0;
            HasVision = true;
            HasHearing = true;
            CanSpeak = true;

            // Hormonal outputs
            AntidiureticHormone = 0.0;
            StressHormoneLevel = 0.0;

            // Immune / inflammatory
            Interleukin1 = 0.0;
            Interleukin6 = 0.0;
            TumorNecrosisFactorAlpha = 0.0;
            NeuroinflammationMarker = 0.0;
            MicrogliaActivation = 0.0;
            MeningealInflammation = 0.0;
            HasSubarachnoidHemorrhage = false;
            IntracranialPressureDelta = 0.0;

            // Composite
            OverallFunction = 1.0;
        }
    }
}