using Rca.Physical.Exceptions;
using Rca.Physical.Units;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Rca.Physical
{
    /// <summary>
    /// This class provides functionality for converting values to other units.
    /// </summary>
    public class Converter : INotifyPropertyChanged
    {
        /// <summary>
        /// Buffer to hold the unit symbol for the units.
        /// <para/><see langword="key"/>: symbol or notation string; <see langword="value"/>: <see cref="PhysicalUnits"/>
        /// </summary>
        internal static ConcurrentDictionary<string, PhysicalUnits> UnitsSymbolBuffer;
        internal static bool BufferIsInitialized = false;


        #region Members

        private PhysicalValue m_Temperature;
        private PhysicalValue m_Pressure;
        #endregion Members

        #region Properties
        public PhysicalValue Temperature
        {
            get => m_Temperature;
            set => SetField(ref m_Temperature, value);
        }

        public PhysicalValue Pressure
        {
            get => m_Pressure;
            set => SetField(ref m_Pressure, value);
        }

        #endregion Properties

        public Converter()
        {
            if (!BufferIsInitialized)
                InitializeBuffer();
        }

        #region Services

        /// <summary>
        /// Convert a physical value in a new physical value with the given unit
        /// </summary>
        /// <param name="sourceValue">Physical value to convert</param>
        /// <param name="targetUnit">Target physical unit</param>
        /// <returns>The numeric base value in the target unit</returns>
        /// <exception cref="InvalidPhysicalUnitConvertionException">Source or target unit is not direct scalable</exception>
        public PhysicalValue Convert(PhysicalValue sourceValue, PhysicalUnits targetUnit)
        {
            if (!targetUnit.IsDirectScalable() && targetUnit != sourceValue.Unit)
                throw new InvalidPhysicalUnitConvertionException(sourceValue.Unit, targetUnit, "The target unit is not direct scalable.");

            if (sourceValue.Dimension != targetUnit.GetDimension())
                throw new InvalidPhysicalDimensionConvertionException(sourceValue.Dimension, targetUnit.GetDimension());


            if (sourceValue.Unit.IsDirectScalable() && targetUnit.IsDirectScalable())
                return new PhysicalValue((sourceValue.GetBaseValue() - targetUnit.GetBaseOffset()) / targetUnit.GetBaseFactor(), targetUnit, sourceValue.Scaling);
            else
                throw new InvalidPhysicalUnitConvertionException(sourceValue.Unit, targetUnit, "The source unit is not direct scalable.");
        }

        /// <summary>
        /// Converts the string representation of a physical value in a culture-specific format to its <see cref="PhysicalValue"/> equivalent. The numerical part must match the rules of the current culture.
        /// </summary>
        /// <param name="valueString">A string containing a physical value to convert. A space between number and unit is not required.</param>
        /// <returns>Converted value</returns>
        /// <exception cref="FormatException">The given string cannot be converted to a PhysicalValue.</exception>
        public static PhysicalValue ParsePhysicalValue(string valueString) => ParsePhysicalValue(valueString, CultureInfo.CurrentCulture);

        /// <summary>
        /// Converts the string representation of a physical value in a culture-specific format to its <see cref="PhysicalValue"/> equivalent.
        /// </summary>
        /// <param name="valueString">A string containing a physical value to convert. A space between number and unit is not required.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="valueString"/></param>
        /// <returns>Converted value</returns>
        /// <exception cref="FormatException">The given string cannot be converted to a PhysicalValue.</exception>
        public static PhysicalValue ParsePhysicalValue(string valueString, IFormatProvider provider)
        {
            if (TryParsePhysicalValue(valueString, provider, out var value))
                return value;
            else
                throw new FormatException($"The given string {valueString} cannot be converted to a PhysicalValue.");
        }
        /// <summary>
        /// Converts the string representation of a physical value in a culture-specific format to its <see cref="PhysicalValue"/> equivalent. The numerical part must match the rules of the current culture. A return value indicates wehther the convertion succeded or failed.
        /// </summary>
        /// <param name="valueString">A string containing a physical value to convert. A space between number and unit is not required.</param>
        /// <param name="value">Converted value</param>
        /// <returns><see langword="true"/> if <paramref name="valueString"/> was converted successfully; otherwise, <see langword="false"/></returns>
        public static bool TryParsePhysicalValue(string valueString, out PhysicalValue value) => TryParsePhysicalValue(valueString, CultureInfo.CurrentCulture, out value);

        /// <summary>
        /// Converts the string representation of a physical value in a culture-specific format to its <see cref="PhysicalValue"/> equivalent. A return value indicates wehther the convertion succeded or failed.
        /// </summary>
        /// <param name="valueString">A string containing a physical value to convert. A space between number and unit is not required.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="valueString"/></param>
        /// <param name="value">Converted value</param>
        /// <returns><see langword="true"/> if <paramref name="valueString"/> was converted successfully; otherwise, <see langword="false"/></returns>
        public static bool TryParsePhysicalValue(string valueString, IFormatProvider provider, out PhysicalValue value)
        {
            if (!BufferIsInitialized)
                InitializeBuffer();

            var regex = new Regex(@"^(?<value>[\+-]?[\d\.\,]+(?:[Ee][\+-]?\d+)?)\s*(?<unit>.[^\.\,]*)\s*$");

            var m = regex.Match(valueString);

            if (m.Success)
                if (double.TryParse(m.Groups["value"].Value, NumberStyles.Float, provider, out var valueDouble))
                {
                    var unitString = m.Groups["unit"].Value.Trim();

                    if (UnitsSymbolBuffer.TryGetValue(unitString, out var unit))
                    {
                        value = new PhysicalValue(valueDouble, unit);
                        return true;
                    }
                }

            value = null;
            return false;
        }

        #endregion Services

        #region Internal serives
        private static void InitializeBuffer(bool forceInitialization = false)
        {
            if (BufferIsInitialized & !forceInitialization)
                return;

            if (forceInitialization || UnitsSymbolBuffer == null || UnitsSymbolBuffer.IsEmpty)
            {
                UnitsSymbolBuffer = new ConcurrentDictionary<string, PhysicalUnits>();

                foreach (var unit in (PhysicalUnits[])Enum.GetValues(typeof(PhysicalUnits)))
                {
                    UnitsSymbolBuffer.TryAdd(unit.GetSymbol().Trim(), unit);

                    foreach (var notationString in unit.GetAlternativeSymbolNotations())
                        UnitsSymbolBuffer.TryAdd(notationString.Trim(), unit);
                }
                BufferIsInitialized = true;
            }
        }

        #endregion Internal services


        #region InotifyPropertyChanged
        /// <summary>
        /// Notifies a change of a property of the instance
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Trigger the <seealso cref="PropertyChanged"/> event if clients are attached
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
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
