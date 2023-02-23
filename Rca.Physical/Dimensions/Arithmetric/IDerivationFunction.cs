using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Dimensions.Arithmetric
{
    /// <summary>
    /// Interface which defines the physical dimensions from which another dimension can be derived.
    /// </summary>
    public interface IDerivationFunction
    {
        ArithmetricOperations ArithmetricFunction { get; }

        PhysicalDimensions DimensionValue1 { get; }

        PhysicalDimensions DimensionValue2 { get; }
    }
}
