using Rca.Physical.Dimensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical
{
    public enum PhysicalDimensions
    {
        None,
        [BaseUnit(PhysicalUnits.Kelvin)]
        Temperature,
        [BaseUnit(PhysicalUnits.Pascal)]
        Pressure
    }
}
