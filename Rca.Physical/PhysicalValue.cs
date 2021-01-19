using Rca.Physical.Units;
using System;

namespace Rca.Physical
{
    public class PhysicalValue : IEquatable<PhysicalValue>
    {
        public double Value { get; set; }

        public PhysicalUnits Unit { get; set; }

        public PhysicalDimensions Dimension => Unit.GetDimension();


        /// <summary>
        /// Empty constructor
        /// </summary>
        public PhysicalValue()
        {

        }


        public PhysicalValue(double value, PhysicalUnits unit)
        {
            Value = value;
            Unit = unit;
        }



        /// <summary>
        /// Get the plain base value in the SI base unit.
        /// </summary>
        /// <returns>The plain base value in the SI base unit</returns>
        public double GetBaseValue()
        {
            return Unit.GetBaseFactor() * Value + Unit.GetBaseOffset();
        }



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





        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            return Equals((PhysicalValue)obj);
        }

        public override int GetHashCode()
        {
            unchecked //allow int overflow
            {
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

        public bool Equals(PhysicalValue other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Value == other.Value && Unit == other.Unit;
        }
    }
}
