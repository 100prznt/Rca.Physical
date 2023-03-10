using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rca.Physical.Exceptions;

namespace Rca.Physical.Helpers
{
    public class PhyMath
    {
        /// <summary>
        /// <inheritdoc cref="Calculator.Power(PhysicalValue, int)"/>
        /// </summary>
        /// <param name="x">Base (a <see cref="PhysicalValue"/> to be raised to a power)</param>
        /// <param name="y">Exponent (a number that specifies a power)</param>
        /// <returns>The <see cref="PhysicalValue"/> <paramref name="x"/> raised to the power <paramref name="y"/>.</returns>
        /// <exception cref="InvalidPhysicalCalculationOperationException">No derivation function available for the input values.</exception>
        /// <exception cref="ArgumentException">The exponent must be 1 or larger.</exception>
        public static PhysicalValue Pow(PhysicalValue x, int y) => Calculator.Power(x, y);

        /// <summary>
        /// Returns the absolute value of a <see cref="PhysicalValue"/>
        /// </summary>
        public static PhysicalValue Abs(PhysicalValue value)
        {
            value.Value = Math.Abs(value.Value);
            return value;
        }
    }
}
