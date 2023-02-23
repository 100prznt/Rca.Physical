using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical.Dimensions
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class BaseUnitAttribute : Attribute
    {
        /// <summary>
        /// SI base unit
        /// </summary>
        public PhysicalUnits BaseUnit { get; set; }

        public BaseUnitAttribute(PhysicalUnits baseUnit)
        {
            BaseUnit = baseUnit;
        }
    }
}
