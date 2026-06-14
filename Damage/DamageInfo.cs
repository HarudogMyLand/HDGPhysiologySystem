using System;
using System.Collections.Generic;
using System.Text;

/* This is the Damage Info struct that defines the 
 * information any damage carries.Enum of damages are
 * defined in the DamageType.cs file.
 */
namespace Physiology.Damage
{

    public interface IDamageData { }

    /// <summary>
    /// Damage information package delivered when a damage happens
    /// </summary>
    public struct DamageInfo
    {
        public DamageType Type { get; set; }
        public IDamageData Data { get; set; }
    }

}
