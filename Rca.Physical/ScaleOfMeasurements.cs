using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical
{
    /// <summary>
    /// Level of measurement or scale of measure is a classification that describes the nature of information within the values assigned to the <see cref="PhysicalValue"/>.
    /// See also: https://en.wikipedia.org/wiki/Level_of_measurement
    /// </summary>
    public enum ScaleOfMeasurements
    {
        NotDefined = 0,
        Absolute,
        Relative,
        Difference
    }
}
