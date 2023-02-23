using Rca.Physical.Units;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Rca.Physical.Units
{
    public static class UnitsExtension
    {
        private static ConcurrentDictionary<PhysicalUnits, PhysicalDimensions> UnitsDimensionBuffer = new ConcurrentDictionary<PhysicalUnits, PhysicalDimensions>();
        private static ConcurrentDictionary<PhysicalUnits, string> UnitsSymbolBuffer = new ConcurrentDictionary<PhysicalUnits, string>();
        private static ConcurrentDictionary<PhysicalUnits, ScalingAttribute> UnitsScalingBuffer = new ConcurrentDictionary<PhysicalUnits, ScalingAttribute>();
        private static ConcurrentDictionary<PhysicalUnits, bool> UnitsDisableAutoFitBuffer = new ConcurrentDictionary<PhysicalUnits, bool>();
        private static ConcurrentDictionary<PhysicalUnits, string[]> UnitsAlternativeSymbolNotationsBuffer = new ConcurrentDictionary<PhysicalUnits, string[]>();

        /// <summary>
        /// Returns the unit symbol.
        /// </summary>
        /// <param name="unit">Unit from which the symbol is to be returned.</param>
        /// <returns>Unit symbol</returns>
        public static string GetSymbol(this PhysicalUnits unit)
        {
            if (UnitsSymbolBuffer.ContainsKey(unit))
                return UnitsSymbolBuffer[unit];


            var attr = GetAttribute<SymbolAttribute>(unit);
            var symbolString = attr == null ? unit.ToString() : attr.SymbolString; //default is enum name
            UnitsSymbolBuffer.AddOrUpdate(unit, symbolString, (k, old) => symbolString);

            return symbolString;
        }

        public static string[] GetAlternativeSymbolNotations(this PhysicalUnits unit)
        {
            if (UnitsAlternativeSymbolNotationsBuffer.ContainsKey(unit))
                return UnitsAlternativeSymbolNotationsBuffer[unit];

            var attr = GetAttribute<AlternativeSymbolNotationsAttribute>(unit);
            var notations = attr?.SymbolNotationStrings;
            UnitsAlternativeSymbolNotationsBuffer.AddOrUpdate(unit, notations, (k, old) => notations);

            if (attr == null)
                return new string[0];
            else
                return attr.SymbolNotationStrings;
        }

        /// <summary>
        /// Returns if the unit is used for auto fitting
        /// </summary>
        /// <param name="unit">Unit from which the auto fitting state returned</param>
        /// <returns>Unit is used for auto fitting</returns>
        public static bool IsAutoFitUnit(this PhysicalUnits unit)
        {
            if (UnitsDisableAutoFitBuffer.ContainsKey(unit))
                return UnitsDisableAutoFitBuffer[unit];


            var attr = GetAttribute<DisableAutoFitAttribute>(unit);
            var disableAutoFit = attr != null && attr.AutoFitIsDisabled;
            UnitsDisableAutoFitBuffer.AddOrUpdate(unit, disableAutoFit, (k, old) => disableAutoFit);

            return !disableAutoFit;
        }

        

        /// <summary>
        /// Returns the physical dimension.
        /// </summary>
        /// <param name="unit">Unit from which the physical dimension is to be returned.</param>
        /// <returns>Physical dimension</returns>
        public static PhysicalDimensions GetDimension(this PhysicalUnits unit)
        {
            if (UnitsDimensionBuffer.ContainsKey(unit))
                return UnitsDimensionBuffer[unit];


            var attr = GetAttribute<DimensionAttribute>(unit);
            var dimension = attr == null ? PhysicalDimensions.None : attr.Dimension; //default is None
            UnitsDimensionBuffer.AddOrUpdate(unit, dimension, (k, old) => dimension);

            return dimension;
        }

        /// <summary>
        /// Returns the base factor to calculate the SI base unit value.
        /// It is still valid mx+n (m: BaseFactor, n: BaseOffset, x: source value)
        /// </summary>
        /// <param name="unit">Unit from which the base factor is to be returned.</param>
        /// <returns>Base factor</returns>
        public static double GetBaseFactor(this PhysicalUnits unit)
        {
            if (UnitsScalingBuffer.ContainsKey(unit))
                return UnitsScalingBuffer[unit].BaseFactor;


            var attr = GetAttribute<ScalingAttribute>(unit) ?? new ScalingAttribute(1);
            UnitsScalingBuffer.AddOrUpdate(unit, attr, (k, old) => attr);

            return attr.BaseFactor;
        }

        /// <summary>
        /// Returns the base offset to calculate the SI base unit value.
        /// It is still valid mx+n (m: BaseFactor, n: BaseOffset, x: source value)
        /// </summary>
        /// <param name="unit">Unit from which the base offset is to be returned.</param>
        /// <returns>Base offset</returns>
        public static double GetBaseOffset(this PhysicalUnits unit)
        {
            if (UnitsScalingBuffer.ContainsKey(unit))
                return UnitsScalingBuffer[unit].BaseOffset;


            var attr = GetAttribute<ScalingAttribute>(unit) ?? new ScalingAttribute(1);
            UnitsScalingBuffer.AddOrUpdate(unit, attr, (k, old) => attr);

            return attr.BaseOffset;
        }

        /// <summary>
        /// "Direct Scalable" means the unit are not depends on other dimensions and can direct convert in other units.
        /// e.g. mWS; represent a pressure but depending also on the temperature, so mWS can not direct convert in other units
        /// </summary>
        /// <param name="unit">Physical unit</param>
        /// <returns>The unit is direct scalable</returns>
        public static bool IsDirectScalable(this PhysicalUnits unit)
        {
            if (UnitsScalingBuffer.ContainsKey(unit))
                return !UnitsScalingBuffer[unit].IsNotDirectScalable;


            var attr = GetAttribute<ScalingAttribute>(unit) ?? new ScalingAttribute(1);
            UnitsScalingBuffer.AddOrUpdate(unit, attr, (k, old) => attr);

            return !attr.IsNotDirectScalable;
        }

        internal static T GetAttribute<T>(PhysicalUnits unit) where T : Attribute
        {
            var fi = unit.GetType().GetField(unit.ToString());

            foreach (var attr in fi.GetCustomAttributes(false))
                if (attr is T selectedAttr)
                    return selectedAttr;

            return null;
        }
    }
}
