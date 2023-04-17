using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical
{
    //TODO: Add to auto gen code
    public static class PhysicalValueExtensions
    {
        /// <summary>
        /// The dimension of the PhysicalValue is <see cref="PhysicalDimensions.Pressure"/>
        /// </summary>
        /// <returns></returns>
        public static bool IsPressure(this PhysicalValue value)
        {
            return value.Dimension == PhysicalDimensions.Pressure;
        }
    }
}
