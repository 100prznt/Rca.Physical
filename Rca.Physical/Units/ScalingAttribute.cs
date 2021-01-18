using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical.Units
{
    /// <summary>
    /// Takes over scaling information to calculate back to the SI base unit, where mx+n applies.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ScalingAttribute : Attribute
    {
        /// <summary>
        /// Factor by which the value must be multiplied to calculate the SI base unit value.
        /// It is still valid mx+n (m: BaseFactor, n: BaseOffset, x: source value)
        /// </summary>
        public double BaseFactor { get; set; }

        /// <summary>
        /// Offset which must be added to calculate the SI base unit value.
        /// It is still valid mx+n (m: BaseFactor, n: BaseOffset, x: source value)
        /// </summary>
        public double BaseOffset { get; set; }

        /// <summary>
        /// Scaling information to calculate back to the SI base unit
        /// </summary>
        /// <param name="baseFactor">Factor by which the value must be multiplied to calculate the SI base unit value.</param>
        /// <param name="baseOffset">Offset which must be added to calculate the SI base unit value.</param>
        public ScalingAttribute(double baseFactor, double baseOffset = 0)
        {
            BaseFactor = baseFactor;
            BaseOffset = baseOffset;
        }
    }
}
