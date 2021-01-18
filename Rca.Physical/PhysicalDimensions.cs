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
        Pressure,
        [BaseUnit(PhysicalUnits.Volt)]
        Voltage,
        [BaseUnit(PhysicalUnits.Seconds)]
        Time
    }
}
