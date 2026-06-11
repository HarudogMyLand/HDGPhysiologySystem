using System;
using System.Collections.Generic;
using System.Text;

using Physiology.Organs;
using Physiology.Damage;

namespace Physiology.Organs.OrganImplementation.Brain
{
    public class Brain : Organ
    {
        public double BrainIntegrity { get; private set; }      // The integrity of brain
        public double ConsciousnessLevel { get; private set; }  // The consciousness level


        public Brain() : base(OrganNames.Brain, "Brain")
        {
            BrainIntegrity = 1.0;
            ConsciousnessLevel = 1.0;
        }

        public override void OnDamageReceived(DamageInfo damage)
        {
            if (damage.Type == DamageType.Blunt)
                ConsciousnessLevel *= 0.8;
            else
                ConsciousnessLevel = Math.Max(0, ConsciousnessLevel - 0.1);
            
            if (damage.Type == DamageType.Pierce)
                BrainIntegrity *= 0.8;
            
        }

        public override void Tick(double deltaTime)
        {
            
        }
    }
}
