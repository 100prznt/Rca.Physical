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
            Attribute[] attributes = unit.GetAttributes();

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

        private static Attribute[] GetAttributes(this PhysicalUnits unit)
        {
            var fi = unit.GetType().GetField(unit.ToString());
            Attribute[] attributes = (Attribute[])fi.GetCustomAttributes(false);

            return attributes;
        }
    }
}
