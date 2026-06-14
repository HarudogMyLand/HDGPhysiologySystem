# Brain

Brain is the main regulator in creature's regulation system. Brain contains following organ parts:
- Brain stem
- Cerebellum
- Cerebrum
- Diencephalon
- Limbic System
- Meninges

## BrainSignalBoard – Modular Brain Signal Interface

The `BrainSignalBoard` is a central data container for brain state signals in a physiological simulation. It is updated internally by the `Brain` class each tick and read by the **Homeostasis System** to affect other organs. External organs never call this board directly.

The class is split into **partial modules**, each representing a functional brain region or system. All properties are `public` with `internal set`, meaning they are readable by any system but writable only by the `Brain` class (or internal logic).

### Modules Overview

| Module | Responsibility |
|--------|----------------|
| **Brainstem** | Vital signs, consciousness, reflexes, autonomic outflow (sympathetic/parasympathetic), respiratory & cardiac control. |
| **Cerebellum** | Motor coordination, balance, muscle tone, gait, fine motor control, and motor learning. |
| **Diencephalon** | Thalamus, hypothalamus, hormonal regulation (CRH, TRH, ADH, oxytocin, etc.), circadian rhythm, thermoregulation, hunger/thirst. |
| **Limbic System** | Emotion, fear, aggression, memory (hippocampus, mammillary body), reward, motivation, stress modulation. |
| **Cerebrum (Cortical)** | Higher sensory & motor output, cognition, pain perception, vision, hearing, speech. |
| **Meninges / Neuroimmune** | Cytokines (IL-1, IL-6, TNF-α), neuroinflammation, microglia activation, intracranial pressure, subarachnoid hemorrhage. |
| **Composite (Main)** | Overall brain function derived from all modules. |

### Public Signals

The table below lists every public property exposed by `BrainSignalBoard`, grouped by module.  
All values range **0–1** unless noted otherwise (booleans or special ranges).

| Module | Property | Type | 中文说明 |
|--------|----------|------|----------|
| **Brainstem** | `IsConscious` | `bool` | 意识状态（true=清醒） |
| | `ReticularActivatingSystem` | `double` | 网状激活系统完整性 |
| | `BrainstemReticularFormationActive` | `bool` | 脑干网状结构活跃性 |
| | `RespiratoryDrive` | `double` | 呼吸驱动（0=停止，>1=过度通气） |
| | `CardiacCenterFunction` | `double` | 心脏中枢功能 |
| | `VasomotorCenterFunction` | `double` | 血管运动中枢功能 |
| | `BaroreceptorReflexGain` | `double` | 压力感受器反射增益 |
| | `SympatheticOutflowStrength` | `double` | 交感神经传出强度 |
| | `ParasympatheticOutflowStrength` | `double` | 副交感神经传出强度 |
| | `PupillaryLightReflex` | `double` | 瞳孔对光反射 |
| | `CornealReflex` | `double` | 角膜反射 |
| | `GagReflex` | `double` | 咽反射 |
| | `CoughReflex` | `double` | 咳嗽反射 |
| | `FacialMotorFunction` | `double` | 面神经运动功能 |
| | `EyeMovementControl` | `double` | 眼球运动控制 |
| | `SwallowingFunction` | `double` | 吞咽功能 |
| | `VocalCordControl` | `double` | 声带控制 |
| | `DescendingPainInhibition` | `double` | 下行疼痛抑制 |
| | `SleepWakeCycleIntegrity` | `double` | 睡眠-觉醒周期完整性 |
| | `BrainstemFunction` | `double` | 脑干综合功能 |
| | `BrainstemCriticalFailure` | `bool` | 脑干灾难性衰竭标志 |
| **Cerebellum** | `CerebellarMotorCoordination` | `double` | 小脑运动协调 |
| | `BalanceCapability` | `double` | 平衡能力 |
| | `PosturalInstability` | `bool` | 姿势不稳 |
| | `FineMotorControl` | `double` | 精细运动控制 |
| | `MuscleTone` | `double` | 肌张力 |
| | `GaitAtaxia` | `bool` | 步态共济失调 |
| | `LimbAtaxia` | `bool` | 肢体共济失调 |
| | `Nystagmus` | `bool` | 眼球震颤 |
| | `CerebellarMotorReadiness` | `double` | 小脑运动准备状态 |
| | `IntentionTremor` | `bool` | 意向性震颤 |
| | `ReflexGainMultiplier` | `double` | 反射增益乘数 |
| | `CerebellumFunction` | `double` | 小脑综合功能 |
| **Diencephalon** | `ThalamicSensoryRelay` | `double` | 丘脑感觉中继保真度 |
| | `SubthalamicMotorRegulation` | `double` | 丘脑底核运动调节 |
| | `MelatoninProduction` | `double` | 褪黑素生成 |
| | `StressInputFactor` | `double` | 外周压力输入因子 |
| | `CorticotropinReleasingHormone` | `double` | 促肾上腺皮质激素释放激素 (CRH) |
| | `ThyrotropinReleasingHormone` | `double` | 促甲状腺激素释放激素 (TRH) |
| | `GonadotropinReleasingHormone` | `double` | 促性腺激素释放激素 (GnRH) |
| | `AntidiureticHormoneProduction` | `double` | 抗利尿激素生成能力 |
| | `BodyHydrationFactor` | `double` | 身体水合因子 |
| | `OxytocinProduction` | `double` | 催产素生成 |
| | `GrowthHormoneReleasingHormone` | `double` | 生长激素释放激素 (GHRH) |
| | `SympatheticTone` | `double` | 交感张力 |
| | `ParasympatheticTone` | `double` | 副交感张力 |
| | `ThermoregulationCapability` | `double` | 体温调节能力 |
| | `BodyTemperatureRegulationFailure` | `bool` | 体温调节衰竭 |
| | `HungerRegulation` | `double` | 饥饿调节 |
| | `ThirstRegulation` | `double` | 渴觉调节 |
| | `CircadianRhythmIntegrity` | `double` | 昼夜节律完整性 |
| | `FeverResponseCapability` | `double` | 发热反应能力 |
| | `DiencephalonFunction` | `double` | 间脑综合功能 |
| | `AntidiureticHormone` | `double` | 抗利尿激素水平 (ADH) |
| | `StressHormoneLevel` | `double` | 压力激素水平（皮质醇释放因子） |
| **Limbic System** | `AmygdalaFunction` | `double` | 杏仁核功能 |
| | `FearResponseAmplitude` | `double` | 恐惧反应幅度 |
| | `AggressionInhibition` | `double` | 攻击性抑制 |
| | `DisorganizedAggression` | `bool` | 失序攻击行为 |
| | `EmotionalRegulation` | `double` | 情绪调节能力 |
| | `EmotionalInstability` | `bool` | 情绪不稳 |
| | `PainAffectModulator` | `double` | 疼痛情感调节 |
| | `MemoryFormationCapability` | `double` | 记忆形成能力 |
| | `AnterogradeAmnesia` | `bool` | 顺行性遗忘 |
| | `MammillaryMemoryRelay` | `double` | 乳头体记忆中继 |
| | `RetrogradeAmnesia` | `bool` | 逆行性遗忘 |
| | `SpatialMemory` | `double` | 空间记忆 |
| | `RewardSensitivity` | `double` | 奖赏敏感性 |
| | `MotivationDrive` | `double` | 动机驱力 |
| | `Anhedonia` | `bool` | 快感缺失 |
| | `PleasureResponse` | `double` | 愉悦反应 |
| | `StressResponseAmplifier` | `double` | 压力反应放大器 |
| | `CingulateStressModulation` | `double` | 扣带回压力调节 |
| | `LimbicSystemFunction` | `double` | 边缘系统综合功能 |
| | `HippocampalInflammationFactor` | `double` | 海马炎症因子 |
| **Cerebrum** | `MotorCoordination` | `double` | 运动协调值 |
| | `PainSignal` | `double` | 感知疼痛水平 |
| | `HasPainInput` | `bool` | 存在疼痛输入 |
| | `PainInputStrength` | `double` | 疼痛输入强度 |
| | `CognitiveFunction` | `double` | 认知功能（0=深昏迷） |
| | `HasVision` | `bool` | 视觉功能 |
| | `HasHearing` | `bool` | 听觉功能 |
| | `CanSpeak` | `bool` | 语言能力 |
| **Meninges / Neuroimmune** | `Interleukin1` | `double` | 白介素-1 (IL-1) |
| | `Interleukin6` | `double` | 白介素-6 (IL-6) |
| | `TumorNecrosisFactorAlpha` | `double` | 肿瘤坏死因子α (TNF-α) |
| | `NeuroinflammationMarker` | `double` | 神经炎症标志物 |
| | `MicrogliaActivation` | `double` | 小胶质细胞激活水平 |
| | `MeningealInflammation` | `double` | 脑膜炎症 |
| | `HasSubarachnoidHemorrhage` | `bool` | 活动性蛛网膜下腔出血 |
| | `IntracranialPressureDelta` | `double` | 颅内压升高值 (mmHg) |
| **Composite** | `OverallFunction` | `double` | 整体脑功能（0=死亡，1=完全健康） |

## Reset Behavior

Calling `ResetToHealthy()` restores **all** signals to their default healthy values. 
This is done via partial method calls distributed across each module file, ensuring maintainability.

## Usage Notes

- All properties are **read-only** from outside the `Physiology.Organs` namespace ,due to `internal set`.
- The board is **not** intended to be modified by homeostasis or other organ systems ,only readable.
- Values are updated each simulation tick by the `Brain` class based on internal pathological models.

---

*This interface is part of a larger physiological simulation framework.*