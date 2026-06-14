namespace Physiology.Organs
{
    public record Macro
    {
        public const double OrganDamageThreshold = 0.8;          // Less than this, is damaged
        public const double OrganBrokenThreshold = 0.5;          // Less than this, is broken
        public const double OrganDestroyedThreshold = 0.2;       // Less than this, is destroyed
        public const double OrganDeathThreshold = 0.05;          // Less than this, id dead, completely
        
        
    }
}
