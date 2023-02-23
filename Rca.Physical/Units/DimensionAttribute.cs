using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical.Units
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DimensionAttribute : Attribute
    {
        /// <summary>
        /// Physical dimension/size
        /// </summary>
        public PhysicalDimensions Dimension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimension"></param>
        public DimensionAttribute(PhysicalDimensions dimension)
        {
            Dimension = dimension;
        }
    }
}
