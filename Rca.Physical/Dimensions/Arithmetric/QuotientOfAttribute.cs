using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Dimensions.Arithmetric
{
    /// <summary>
    /// Defines a derivation by division
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class QuotientOfAttribute : Attribute, IDerivationFunction
    {
        /// <summary>
        /// Dimension of the first value, that represent the dividend
        /// </summary>
        public PhysicalDimensions DimensionValue1 { get; }

        /// <summary>
        /// Dimension of the second value, that represent the divisor
        /// </summary>
        public PhysicalDimensions DimensionValue2 { get; }

        public ArithmetricOperations ArithmetricFunction => ArithmetricOperations.Division;

        public QuotientOfAttribute(PhysicalDimensions dimensionDividend, PhysicalDimensions dimensionDivisor)
        {
            DimensionValue1 = dimensionDividend;
            DimensionValue2 = dimensionDivisor;
        }
    }
}
