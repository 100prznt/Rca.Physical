using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical.Units
{
    /// <summary>
    /// Takes over scaling information to calculate back to the SI base unit, where mx+n applies.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ScalingAttribute : Attribute
    {
        /// <summary>
        /// Factor by which the value must be multiplied to calculate the SI base unit value.
        /// It is still valid mx+n (m: BaseFactor, n: BaseOffset, x: source value)
        /// </summary>
        public double BaseFactor { get; set; } = 1;

        /// <summary>
        /// Offset which must be added to calculate the SI base unit value.
        /// It is still valid mx+n (m: BaseFactor, n: BaseOffset, x: source value)
        /// </summary>
        public double BaseOffset { get; set; }

        /// <summary>
        /// Default scaling of a measured value
        /// </summary>
        public ScaleOfMeasurements DefaultScaling { get; set; }

        /// <summary>
        /// Disable direct scaling
        /// For units with dependecies of other dimensions (e.g. m WS; depending on the temperature)
        /// </summary>
        public bool IsNotDirectScalable { get; set; }

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

        /// <summary>
        /// Scaling information to calculate back to the SI base unit and use arithmetric functions
        /// </summary>
        /// <param name="defaultScaling">Default scaling of a measured value</param>
        /// <param name="baseFactor">Factor by which the value must be multiplied to calculate the SI base unit value.</param>
        /// <param name="baseOffset">Offset which must be added to calculate the SI base unit value.</param>
        public ScalingAttribute(ScaleOfMeasurements defaultScaling, double baseFactor, double baseOffset = 0 )
        {
            DefaultScaling = defaultScaling;
            BaseFactor = baseFactor;
            BaseOffset = baseOffset;
        }

        /// <summary>
        /// Scaling information for arithmetric functions
        /// </summary>
        /// <param name="defaultScaling">Default scaling of a measured value</param>
        public ScalingAttribute(ScaleOfMeasurements defaultScaling)
        {
            DefaultScaling = defaultScaling;
        }

        /// <summary>
        /// Empty constructor for scaling information
        /// This constructer allow direct access to the proporties
        /// </summary>
        public ScalingAttribute()
        {
        }
    }
}
