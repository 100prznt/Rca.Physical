using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Utils
{
    internal static class DoubleExtensions
    {
        /// <summary>
        /// Retuns the bitwise rounded value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Bitwise rounded value</returns>
        /// <remarks>based on: https://stackoverflow.com/a/41852591</remarks>
        internal static double GetBitwiseRoundedValue(this double value)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
                return value;

            var i = BitConverter.DoubleToInt64Bits(value);

            const int numberOfBitsToClear = 7; // define precision
            const long precision = 1L << numberOfBitsToClear;
            const long bitMask = ~(precision - 1L);
            const long offset = precision - 1L;

            var iInv = ~i;

            var fu = i & offset;
            var fu2 = iInv & offset;

            if ((i & offset) != 0)
                return value;

            //truncate i
            i &= bitMask;

            // get max value with: BitConverter.Int64BitsToDouble(i + precision))
            // return min value
            return BitConverter.Int64BitsToDouble(i);
        }
    }
}
