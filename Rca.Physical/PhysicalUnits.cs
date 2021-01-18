using Rca.Physical.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical
{
    public enum PhysicalUnits
    {
        [Dimension(PhysicalDimensions.Pressure)]
        [Symbol("bar")]
        Bar,
        [Dimension(PhysicalDimensions.Pressure)]
        [Scaling(0.00001)]
        [Symbol("Pa")]
        Pascal,
        [Dimension(PhysicalDimensions.Temperature)]
        [Scaling(0, -273.15)]
        [Symbol("°C")]
        Celsius,
        [Dimension(PhysicalDimensions.Temperature)]
        [Symbol("K")]
        Kelvin,
        [Dimension(PhysicalDimensions.Voltage)]
        [Symbol("V")]
        Volt,
        [Dimension(PhysicalDimensions.Time)]
        [Symbol("s")]
        Second,
        [Dimension(PhysicalDimensions.Time)]
        [Symbol("min")]
        Minute,
        [Dimension(PhysicalDimensions.Time)]
        [Symbol("h")]
        Hour,
        [Dimension(PhysicalDimensions.Time)]
        [Symbol("d")]
        Day,
        [Dimension(PhysicalDimensions.Time)]
        [Symbol("a")]
        Year
    }
}
