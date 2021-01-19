using Rca.Physical.Units;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Rca.Physical.Units
{
    public static class UnitsExtension
    {
        /// <summary>
        /// Returns the unit symbol.
        /// </summary>
        /// <param name="unit">Unit from which the symbol is to be returned.</param>
        /// <returns>Unit symbol</returns>
        public static string ToSymbol(this PhysicalUnits unit)
        {
            //TODO: check unit.GetAttributes()
            MemberInfo[] memberInfo = unit.GetType().GetMember(unit.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(SymbolAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return ((SymbolAttribute)attrs[0]).UnitSymbolString;
            }

            return unit.ToString();     //default is enum name
        }

        /// <summary>
        /// Returns the physical dimension.
        /// </summary>
        /// <param name="unit">Unit from which the physical dimension is to be returned.</param>
        /// <returns>Physical dimension</returns>
        public static PhysicalDimensions GetDimension(this PhysicalUnits unit)
        {
            var attributes = unit.GetAttributes();

            DimensionAttribute attr = null;

            for (int i = 0; i < attributes.Length; i++)
            {
                if (attributes[i].GetType() == typeof(DimensionAttribute))
                {
                    attr = (DimensionAttribute)attributes[i];
                    break;
                }
            }

            if (attr == null)
                return PhysicalDimensions.None;
            else
                return attr.Dimension;
        }

        /// <summary>
        /// Returns the base factor to calculate the SI base unit value.
        /// It is still valid mx+n (m: BaseFactor, n: BaseOffset, x: source value)
        /// </summary>
        /// <param name="unit">Unit from which the base factor is to be returned.</param>
        /// <returns>Base factor</returns>
        public static double GetBaseFactor(this PhysicalUnits unit)
        {
            var attributes = unit.GetAttributes();

            ScalingAttribute attr = null;

            for (int i = 0; i < attributes.Length; i++)
            {
                if (attributes[i].GetType() == typeof(ScalingAttribute))
                {
                    attr = (ScalingAttribute)attributes[i];
                    break;
                }
            }

            if (attr == null)
                return 1;
            else
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
            var attributes = unit.GetAttributes();

            ScalingAttribute attr = null;

            for (int i = 0; i < attributes.Length; i++)
            {
                if (attributes[i].GetType() == typeof(ScalingAttribute))
                {
                    attr = (ScalingAttribute)attributes[i];
                    break;
                }
            }

            if (attr == null)
                return 0;
            else
                return attr.BaseOffset;
        }



        private static Object[] GetAttributes(this PhysicalUnits unit)
        {
            var fi = unit.GetType().GetField(unit.ToString());
            var attributes = fi.GetCustomAttributes(false);

            return attributes;
        }
    }
}
