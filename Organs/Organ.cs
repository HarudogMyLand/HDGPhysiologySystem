using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Physiology.Damage;

namespace Physiology.Organs
{
    /// <summary>
    /// Represents an organ (or tissue structure) of a human or biological entity.
    /// This class is abstract, requiring concrete organs (e.g., heart, bone, muscle) to inherit and implement their own damage response logic.
    /// </summary>
    /// <remarks>
    /// Each organ has:
    /// - Type (<see cref="OrganNames"/>): indicates which organ, such as Heart, Bone.
    /// - Part (<see cref="Part"/>): precise anatomical location or sub-region, e.g., "left ventricle", "middle of right femur".
    /// - Integrity (<see cref="Integrity"/>): a value from 0 to 100 representing the health of the organ; 100 is fully healthy, 0 is completely non‑functional.
    ///
    /// When the organ takes damage, the <see cref="OnDamageReceived(DamageInfo)"/> method is called.
    /// Derived classes should override this method to modify integrity or trigger other physiological effects based on damage type, damage location, and organ‑specific characteristics.
    ///
    /// Note: This class does not currently implement physiological networks or regulatory mechanisms; it only provides the most basic structural definition.
    /// </remarks>

    public abstract class Organ
    {
        private OrganNames Name { set; get; }   // Type of organ
        private string Part { set; get; }       // Exact part of organ
        private double Integrity { set; get; }   // Integerity of organ

        protected Organ(OrganNames name, string part)
        {
            Part = part ?? throw new ArgumentNullException(nameof(part));
            Name = name;
        }

        public abstract void OnDamageReceived(DamageInfo damageinfo);

        public virtual void Tick(double deltaTime)
        {

        }
    }
}
