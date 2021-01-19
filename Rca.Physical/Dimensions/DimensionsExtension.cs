using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Dimensions
{
    public static class DimensionsExtension
    {
        /// <summary>
        /// Returns the base unit.
        /// </summary>
        /// <param name="dimension">Physical dimension from which the unit is to be returned.</param>
        /// <returns>Base unit</returns>
        public static PhysicalUnits GetBaseUnit(this PhysicalDimensions dimension)
        {
            var attributes = dimension.GetAttributes();

            BaseUnitAttribute attr = null;

            for (int i = 0; i < attributes.Length; i++)
            {
                if (attributes[i].GetType() == typeof(BaseUnitAttribute))
                {
                    attr = (BaseUnitAttribute)attributes[i];
                    break;
                }
            }

            if (attr == null)
                return 0;
            else
                return attr.BaseUnit;
        }



        private static Object[] GetAttributes(this PhysicalDimensions unit)
        {
            var fi = unit.GetType().GetField(unit.ToString());
            var attributes = fi.GetCustomAttributes(false);

            return attributes;
        }
    }
}
