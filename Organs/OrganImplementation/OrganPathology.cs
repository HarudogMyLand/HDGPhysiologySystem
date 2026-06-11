namespace Physiology.Organs.OrganImplementation;

[Flags]
public enum OrganPathology
{
    None                = 0,
    Infection           = 1 << 0,
    Inflammation        = 1 << 1,
    Ischemia            = 1 << 2,
    Hemorrhage          = 1 << 3,
    Edema               = 1 << 4,
    Fibrosis            = 1 << 5,
    Atrophy             = 1 << 6,
    Hypertrophy         = 1 << 7,
    Calcification       = 1 << 8,
    Necrosis            = 1 << 9, 
    Abscess             = 1 << 10,
    TumorBenign         = 1 << 11,
    TumorMalignant      = 1 << 12,
    Cirrhosis           = 1 << 13, 
    TransplantRejection = 1 << 14
}