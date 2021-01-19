using Rca.Physical.Exceptions;
using Rca.Physical.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical
{
    public class Converter
    {
        public PhysicalValue Convert(PhysicalValue sourceValue, PhysicalUnits targetUnit)
        {
            if (sourceValue.Dimension != targetUnit.GetDimension())
                throw new InvalidDimensionException(sourceValue.Dimension, targetUnit.GetDimension());

            double baseValue = sourceValue.GetBaseValue();

            return new PhysicalValue((baseValue - targetUnit.GetBaseOffset()) / targetUnit.GetBaseFactor(), targetUnit);
        }
    }
}
