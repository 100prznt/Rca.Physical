using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Dimensions.Arithmetric
{
    /// <summary>
    /// Defines a derivation by multiplication
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ProductOfAttribute : Attribute, IDerivationFunction
    {
        /// <summary>
        /// Dimension of the first value, that represent a factor
        /// </summary>
        public PhysicalDimensions DimensionValue1 { get; }

        /// <summary>
        /// Dimension of the second value, that represent a factor
        /// </summary>
        public PhysicalDimensions DimensionValue2 { get; }

        public ArithmetricOperations ArithmetricFunction => ArithmetricOperations.Multiplication;

        public ProductOfAttribute(PhysicalDimensions dimensionFactor1, PhysicalDimensions dimensionFactor2)
        {
            DimensionValue1 = dimensionFactor1;
            DimensionValue2 = dimensionFactor2;
        }
    }
}
