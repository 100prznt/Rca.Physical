using Rca.Physical.Dimensions;
using Rca.Physical.Exceptions;
using Rca.Physical.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Rca.Physical
{
    [DebuggerDisplay("{DefaultFormattedValue, nq}")]
    public class PhysicalValue : IEquatable<PhysicalValue>, INotifyPropertyChanged
    {
        #region Members

        private double m_Value = double.NaN;
        private PhysicalUnits m_Unit = PhysicalUnits.NotDefined;
        private ScaleOfMeasurements m_Scaling = ScaleOfMeasurements.NotDefined;

        #endregion Members

        #region Fields
        private string DefaultFormattedValue => Value.ToString() + GetSymbolSuffix();

        #endregion Fields

        #region Static

        public static PhysicalValue NaN => new();

        #endregion Static

        #region Properties
        /// <summary>
        /// Numeric value
        /// </summary>
        public double Value
        {
            get => m_Value;
            set => SetField(ref m_Value, value);
        }

        /// <summary>
        /// Physical unit of the value
        /// </summary>
        public PhysicalUnits Unit
        {
            get => m_Unit;
            set => SetField(ref m_Unit, value);
        }

        /// <summary>
        /// Based scaling of the value
        /// </summary>
        public ScaleOfMeasurements Scaling
        {
            get => m_Scaling;
            set => SetField(ref m_Scaling, value);
        }

        #region Auto setted properties
        /// <summary>
        /// Physical diminsion of the value
        /// </summary>
        public PhysicalDimensions Dimension => Unit.GetDimension();

        /// <summary>
        /// SI base unit for the value
        /// </summary>
        public PhysicalUnits BaseUnit => Unit.GetDimension().GetBaseUnit();

        #endregion Auto setted properties
        #endregion Properties

        #region Constructors

        /// <summary>
        /// Empty constructor
        /// </summary>
        public PhysicalValue()
        {
            Value = double.NaN;
            Unit = PhysicalUnits.NotDefined;
            Scaling = ScaleOfMeasurements.NotDefined;
        }


        public PhysicalValue(double value, PhysicalUnits unit, ScaleOfMeasurements scaling = ScaleOfMeasurements.NotDefined)
        {
            Value = value;
            Unit = unit;
            Scaling = scaling;
        }

        #endregion Constructors

        #region Services
        /// <summary>
        /// Returns a value that indicates wehther the specified value is not a number.
        /// </summary>
        /// <param name="physicalValue"></param>
        /// <returns><see langword="true"/> if <paramref name="physicalValue"/> contain an Value that evaluates to <see cref="double.NaN"/>; otherwise <see langword="false"/></returns>
        public static bool IsNaN(PhysicalValue physicalValue)
        {
            return double.IsNaN(physicalValue.Value);
        }

        /// <summary>
        /// Finds the best fitting unit for the current value.
        /// </summary>
        /// <returns>Current <see cref="PhysicalValue"/> object with the new unit.</returns>
        public PhysicalValue GetFittedPhysicalValue()
        {
            if (!Unit.IsDirectScalable())
                return this;


            var scaledValues = new Dictionary<PhysicalUnits, double>();
            var dimension = Dimension;

            foreach (var unit in (PhysicalUnits[])Enum.GetValues(typeof(PhysicalUnits)))
                if (unit.GetDimension() == dimension && unit.IsDirectScalable() && unit.IsAutoFitUnit())
                    scaledValues.Add(unit, Math.Abs(ValueAs(unit)));

            var targetUnit = Unit;

            if (scaledValues.Any(x => x.Value >= 1))
                targetUnit = scaledValues.Where(x => x.Value >= 1).OrderBy(x => x.Value).First().Key;
            else
                targetUnit = scaledValues.OrderByDescending(x => x.Value).First().Key;

            var converter = new Converter();

            return converter.Convert(this, targetUnit);
        }

        /// <summary>
        /// Converts the value to the specified unit and returns the numerical value
        /// </summary>
        /// <param name="targetUnit">Specified unit</param>
        /// <returns>Numerical value for the specified unit</returns>
        /// <exception cref="ArithmeticException">Units represent not the same physical dimension</exception>
        /// <exception cref="InvalidPhysicalUnitConvertionException">Source or target unit is not direct scalable</exception>
        public double ValueAs(PhysicalUnits targetUnit)
        {
            if (Unit == targetUnit)
                return Value;

            if (!targetUnit.IsDirectScalable())
                throw new InvalidPhysicalUnitConvertionException(Unit, targetUnit, "The target unit is not direct scalable.");

            if (!Unit.IsDirectScalable())
                throw new InvalidPhysicalUnitConvertionException(Unit, targetUnit, "The source unit is not direct scalable.");

            if (Dimension != targetUnit.GetDimension())
                throw new ArithmeticException("Conversion not possible. Units must be represent the same physical dimension.");

            var targetBaseFactor = targetUnit.GetBaseFactor();
            var targetBaseOffset = targetUnit.GetBaseOffset();

            return (GetBaseValue() - targetBaseOffset) / targetBaseFactor;
        }

        /// <summary>
        /// Get the plain base value in the SI base unit.
        /// </summary>
        /// <returns>The plain base value in the SI base unit</returns>
        /// <exception cref="InvalidPhysicalUnitConvertionException">Source unit is not direct scalable</exception>
        public double GetBaseValue()
        {
            var baseUnit = Dimension.GetBaseUnit();

            if (baseUnit == Unit)
                return Value;
            else if (Unit.IsDirectScalable())
            {
                var baseFactor = Unit.GetBaseFactor();
                var baseOffset = Unit.GetBaseOffset();
                return Value * baseFactor + baseOffset;
            }
            else
                throw new InvalidPhysicalUnitConvertionException(Unit, baseUnit, "The source unit is not direct scalable.");
        }

        /// <summary>
        /// Convert the <see cref="PhysicalValue"/> to the specified <see cref="PhysicalUnits"/>
        /// </summary>
        /// <param name="targetUnit">Target <see cref="PhysicalUnits"/></param>
        /// <returnsConverted <see cref="PhysicalValue"/>></returns>
        public PhysicalValue Convert(PhysicalUnits targetUnit)
        {
            var converter = new Converter();

            return converter.Convert(this, targetUnit);
        }

        /// <summary>
        /// Converts the string representation of a physical value in a culture-specific format to its <see cref="PhysicalValue"/> equivalent. The numerical part must match the rules of the current culture.
        /// </summary>
        /// <param name="valueString">A string containing a physical value to convert. A space between number and unit is not required.</param>
        /// <returns>Converted value</returns>
        /// <exception cref="FormatException">The given string cannot be converted to a PhysicalValue.</exception>
        public static PhysicalValue Parse(string valueString)
        {
            return Converter.ParsePhysicalValue(valueString);
        }

        /// <summary>
        /// Converts the string representation of a physical value in a culture-specific format to its <see cref="PhysicalValue"/> equivalent.
        /// </summary>
        /// <param name="valueString">A string containing a physical value to convert. A space between number and unit is not required.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="valueString"/></param>
        /// <returns>Converted value</returns>
        /// <exception cref="FormatException">The given string cannot be converted to a PhysicalValue.</exception>
        public static PhysicalValue Parse(string valueString, IFormatProvider provider)
        {
            return Converter.ParsePhysicalValue(valueString, provider);
        }

        /// <summary>
        /// Converts the string representation of a physical value in a culture-specific format to its <see cref="PhysicalValue"/> equivalent. The numerical part must match the rules of the current culture. A return value indicates wehther the convertion succeded or failed.
        /// </summary>
        /// <param name="valueString">A string containing a physical value to convert. A space between number and unit is not required.</param>
        /// <param name="value">Converted value</param>
        /// <returns><see langword="true"/> if <paramref name="valueString"/> was converted successfully; otherwise, <see langword="false"/></returns>
        public static bool TryParse(string valueString, out PhysicalValue value)
        {
            return Converter.TryParsePhysicalValue(valueString, out value);
        }

        /// <summary>
        /// Converts the string representation of a physical value in a culture-specific format to its <see cref="PhysicalValue"/> equivalent. A return value indicates wehther the convertion succeded or failed.
        /// </summary>
        /// <param name="valueString">A string containing a physical value to convert. A space between number and unit is not required.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="valueString"/></param>
        /// <param name="value">Converted value</param>
        /// <returns><see langword="true"/> if <paramref name="valueString"/> was converted successfully; otherwise, <see langword="false"/></returns>
        public static bool TryParse(string valueString, IFormatProvider provider, out PhysicalValue value)
        {
            return Converter.TryParsePhysicalValue(valueString, provider, out value);
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified <see cref="PhysicalUnits"/>
        /// </summary>
        /// <param name="targetUnit"></param>
        /// <returns>Formated value with unit</returns>
        public string ToString(PhysicalUnits unit)
        {
            return this.Convert(unit).ToString();
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified <see cref="PhysicalUnits"/> and format.
        /// </summary>
        /// <param name="targetUnit"></param>
        /// <param name="format">Specified format</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(PhysicalUnits unit, string format)
        {
            return this.Convert(unit).ToString(format);
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified <see cref="PhysicalUnits"/> and cultur-specific format information.
        /// </summary>
        /// <param name="targetUnit"></param>
        /// <param name="formatProvider">Cultur-specific format information</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(PhysicalUnits unit, IFormatProvider formatProvider)
        {
            return this.Convert(unit).ToString(formatProvider);
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified <see cref="PhysicalUnits"/>, format and cultur-specific format information.
        /// </summary>
        /// <param name="targetUnit"></param>
        /// <param name="format">Specified format</param>
        /// <param name="formatProvider">Cultur-specific format information</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(PhysicalUnits unit, string format, IFormatProvider formatProvider)
        {
            return this.Convert(unit).ToString(format, formatProvider);
        }

        /// <summary>
        /// Returns the value with unit, formatted as string.
        /// </summary>
        /// <param name="fitUnit">Finds the best fitting unit for the value</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(bool fitUnit)
        {
            if (fitUnit)
                return GetFittedPhysicalValue().ToString();
            else
                return ToString();
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified format.
        /// </summary>
        /// <param name="fitUnit">Finds the best fitting unit for the value</param>
        /// <param name="format">Specified format</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(bool fitUnit, string format)
        {
            if (fitUnit)
                return GetFittedPhysicalValue().ToString(format);
            else
                return ToString(format);
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified cultur-specific format information.
        /// </summary>
        /// <param name="fitUnit">Finds the best fitting unit for the value</param>
        /// <param name="formatProvider">Cultur-specific format information</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(bool fitUnit, IFormatProvider formatProvider)
        {
            if (fitUnit)
                return GetFittedPhysicalValue().ToString(formatProvider);
            else
                return ToString(formatProvider);
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified format and cultur-specific format information.
        /// </summary>
        /// <param name="fitUnit">Finds the best fitting unit for the value</param>
        /// <param name="format">Specified format</param>
        /// <param name="formatProvider">Cultur-specific format information</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(bool fitUnit, string format, IFormatProvider formatProvider)
        {
            if (fitUnit)
                return GetFittedPhysicalValue().ToString(format, formatProvider);
            else
                return ToString(format, formatProvider);
        }

        #region ToString overloading
        /// <summary>
        /// Returns the value with unit, formatted as string.
        /// </summary>
        /// <returns>Formated value with unit</returns>
        public override string ToString()
        {
            return DefaultFormattedValue;
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified format
        /// </summary>
        /// <param name="format">Specified format</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(string format)
        {
            return Value.ToString(format) + GetSymbolSuffix();
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified cultur-specific format information
        /// </summary>
        /// <param name="formatProvider">Cultur-specific format information</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(IFormatProvider formatProvider)
        {
            return Value.ToString(formatProvider) + GetSymbolSuffix();
        }

        /// <summary>
        /// Returns the value with unit, formatted as string using the specified format and cultur-specific format information
        /// </summary>
        /// <param name="format">Specified format</param>
        /// <param name="formatProvider">Cultur-specific format information</param>
        /// <returns>Formated value with unit</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return Value.ToString(format, formatProvider) + GetSymbolSuffix();
        }

        #endregion ToString overloading

        #region IEquatable
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specific object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> is an instance of <seealso cref="PhysicalValue"/> and equals the value, unit and scaling of this instance; otherwise, <see langword="false"/></returns>
        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (!double.IsFinite(this.Value))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != this.GetType())
                return false;

            return Equals((PhysicalValue)obj);
        }

        /// <summary>
        /// Determines whethere the specified <seealso cref="PhysicalValue"/> instances are considered equal.
        /// </summary>
        /// <param name="valueA">The first <seealso cref="PhysicalValue"/> to compare.</param>
        /// <param name="valueB">The second <seealso cref="PhysicalValue"/> to compare.</param>
        /// <returns><see langword="true"/> if the <seealso cref="PhysicalValue"/> are considered equal; otherwise, <see langword="false"/></returns>
        public static bool Equals(PhysicalValue valueA, PhysicalValue valueB)
        {
            if (valueA is null || valueB is null)
                return false;
            else
                return valueA.Equals(valueB);
        }

        /// <summary>
        /// Returns the Hashcode for that instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Unit, Scaling);
        }

        /// <summary>
        /// Returns a value indicating whether this instance and a specific <see cref="PhysicalValue"/> represent the same value, unit and scaling.
        /// </summary>
        /// <param name="other"></param>
        /// <returns><see langword="true"/> if <paramref name="other"/> is equal to this instance; otherwise, <see langword="false"/></returns>
        public bool Equals(PhysicalValue? other)
        {
            if (other is null)
                return false;

            if (!double.IsFinite(this.Value) || !double.IsFinite(other.Value))
                return false;

            if (ReferenceEquals(this, other))
                return true;


            return Value == other.Value
                && Unit == other.Unit
                && Scaling == other.Scaling;
        }

        #endregion IEquatable

        #endregion Services

        #region Internal services
        private string GetSymbolSuffix()
        {
            return string.IsNullOrWhiteSpace(Unit.GetSymbol()) ? "" : " " + Unit.GetSymbol();
        }

        private static bool CheckForNotNull(PhysicalValue a, PhysicalValue b)
        {
            if (a is null || b is null)
                throw new NullReferenceException("Operation not possible. One of the given PhysicalValues is null.");
            else
                return true;
        }

        private static bool CheckForSameDimension(PhysicalValue a, PhysicalValue b)
        {
            if (a.Dimension != b.Dimension)
                throw new ArithmeticException("Operation not possible. The given PhysicalValues must represent the same physical dimension.");
            else
                return true;
        }

        private static bool CheckForSameScaling(PhysicalValue a, PhysicalValue b)
        {
            if (a.Scaling != b.Scaling)
                throw new ArithmeticException("Operation not possible. The given PhysicalValues must represent the same scaling.");
            else
                return true;
        }
        #endregion Internal services

        #region Operator overloading
        public static PhysicalValue operator +(PhysicalValue a) => a;

        public static PhysicalValue operator -(PhysicalValue a) => new PhysicalValue(-a.Value, a.Unit); //TODO: Also check scaling of Unit (absolute/relative)

        public static PhysicalValue operator +(PhysicalValue summand1, PhysicalValue summand2)
        {
            if (summand1.Dimension != summand2.Dimension)
                throw new ArithmeticException("Addition not possible. All summands must represent the same physical dimension.");

            var targetUnit = summand1.Unit;

            if (targetUnit == summand2.Unit && targetUnit != PhysicalUnits.Celsius)
                return new PhysicalValue(summand1.Value + summand2.Value, targetUnit);
            else
            {
                //Special case temperture
                //see also accumulated temperature  [°C] + [°C] = [ATU] (ATU - Accumulated thermal unit)
                //see https://physics.stackexchange.com/questions/132720/how-do-you-add-temperatures 
                if (summand1.Dimension == PhysicalDimensions.ThermodynamicTemperature)
                {
                    if (targetUnit == PhysicalUnits.Celsius && summand2.Unit == PhysicalUnits.Celsius)
                        throw new ArithmeticException("Addition not possible. For temperature values, only one summand may be in the unit degrees celsius, all other summands must be in Kelvin.");

                    if (targetUnit == PhysicalUnits.Celsius || summand2.Unit == PhysicalUnits.Celsius)
                        targetUnit = PhysicalUnits.Celsius;
                }

                var baseResult = summand1.GetBaseValue() + summand2.GetBaseValue();
                var converter = new Converter();

                return converter.Convert(new PhysicalValue(baseResult, summand1.BaseUnit), targetUnit);
            }
        }

        public static PhysicalValue operator -(PhysicalValue minuend, PhysicalValue subtrahend)
        {
            if (minuend.Dimension != subtrahend.Dimension)
                throw new ArithmeticException("Subtraction not possible. Minuent and subtrahend must represent the same physical dimension.");

            var targetUnit = minuend.Unit;

            if (minuend.Unit == subtrahend.Unit && targetUnit != PhysicalUnits.Celsius)
                return new PhysicalValue(minuend.Value - subtrahend.Value, targetUnit);
            else
            {
                //Special case temperture
                if (minuend.Dimension == PhysicalDimensions.ThermodynamicTemperature)
                {
                    if (targetUnit == PhysicalUnits.Kelvin && subtrahend.Unit == PhysicalUnits.Celsius)
                        throw new ArithmeticException("Subtraction not possible for [K] - [°C]");

                    if (targetUnit == PhysicalUnits.Celsius && subtrahend.Unit == PhysicalUnits.Celsius)
                        targetUnit = PhysicalUnits.Kelvin;
                }

                var baseResult = minuend.GetBaseValue() - subtrahend.GetBaseValue();
                var converter = new Converter();

                return converter.Convert(new PhysicalValue(baseResult, minuend.BaseUnit), targetUnit);
            }
        }

        public static PhysicalValue operator *(PhysicalValue factor1, PhysicalValue factor2)
        {
            //var factorDims = new PhysicalDimensions[] { factor1.Dimension, factor2.Dimension };

            //foreach (PhysicalDimensions dim in Enum.GetValues(typeof(PhysicalDimensions)))
            //    if (dim.HasDerivationFunction(out var dim1, out var dim2) && factorDims.Except(new PhysicalDimensions[] { dim1, dim2 }).Count() == 0)
            //        return  new PhysicalValue(factor1.GetBaseValue() * factor2.GetBaseValue(), dim.GetBaseUnit());

            //return null;

            return Calculator.Multiply(factor1, factor2);
        }

        public static PhysicalValue operator /(PhysicalValue dividend, PhysicalValue divisor)
        {
            //var factorDims = new PhysicalDimensions[] { dividend.Dimension, divisor.Dimension };

            //foreach (PhysicalDimensions dim in Enum.GetValues(typeof(PhysicalDimensions)))
            //    if (dim.HasDerivationFunction(out var dim1, out var dim2) && ((IStructuralEquatable)new PhysicalDimensions[] { dim1, dim2 }).Equals(factorDims, StructuralComparisons.StructuralEqualityComparer))
            //        return new PhysicalValue(dividend.GetBaseValue() / divisor.GetBaseValue(), dim.GetBaseUnit());

            //return null;

            return Calculator.Divide(dividend, divisor);
        }

        public static bool operator <(PhysicalValue a, PhysicalValue b)
        {
            CheckForNotNull(a, b);
            CheckForSameDimension(a, b);
            CheckForSameScaling(a, b);

            //TODO: Scaling beachten

            return a.GetBaseValue() < b.GetBaseValue();
        }

        public static bool operator >(PhysicalValue a, PhysicalValue b)
        {
            CheckForNotNull(a, b);
            CheckForSameDimension(a, b);
            CheckForSameScaling(a, b);

            //TODO: Scaling beachten

            return a.GetBaseValue() < b.GetBaseValue();
        }

        public static bool operator ==(PhysicalValue a, PhysicalValue b)
        {
            if (a is null || (object)b != null)
                return false;
            if ((object)a != null || b is null)
                return false;
            else if (a is null && b is null)
                return true;

            CheckForSameDimension(a, b);
            CheckForSameScaling(a, b);

            //TODO: Scaling beachten

            return a.GetBaseValue() == b.GetBaseValue();
            
        }

        public static bool operator !=(PhysicalValue a, PhysicalValue b)
        {
            CheckForSameDimension(a, b);
            CheckForSameScaling(a, b);

            //TODO: Scaling beachten

            return a.GetBaseValue() != b.GetBaseValue();
        }

        #endregion Operator overloading

        #region InotifyPropertyChanged
        /// <summary>
        /// Notifies a change of a property of the instance
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Trigger the <seealso cref="PropertyChanged"/> event if clients are attached
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Applies the value to the corresponding member and triggers the <seealso cref="PropertyChanged"/> event if successful.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">Local member of the property</param>
        /// <param name="value">New value for the property</param>
        /// <param name="propName">Propertyname, can also detect by caller member name</param>
        /// <returns>true if the value applied to the local member; false if value and local member are already equal</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            else
            {
                field = value;
                OnPropertyChanged(propName);
                return true;
            }
        }

        #endregion InotifyPropertyChanged
    }
}
