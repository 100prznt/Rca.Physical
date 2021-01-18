using Rca.Physical.Units;
using System;

namespace Rca.Physical
{
    public class PhysicalValue
    {
        public double Value { get; set; }

        public PhysicalUnits Unit { get; set; }

        public PhysicalDimensions Dimension => Unit.GetDimension();


        public override string ToString()
        {
            return Value.ToString() + " " + Unit.ToSymbol();
        }

        public string ToString(string format)
        {
            return Value.ToString(format) + " " + Unit.ToSymbol();
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return Value.ToString(formatProvider) + " " + Unit.ToSymbol();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.ToString(format, formatProvider) + " " + Unit.ToSymbol();
        }
    }
}
