using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ScaleSpecificSymbolAttribute : Attribute
    {
        /// <summary>
        /// Symbol as string
        /// </summary>
        public string SymbolString { get; set; }

        /// <summary>
        /// Specific scale for the symbol
        /// </summary>
        public ScaleOfMeasurements Scale { get; set; }

        /// <summary>
        /// Info about the scale specific symbol
        /// </summary>
        /// <param name="symbolString">Symbol as string</param>
        public ScaleSpecificSymbolAttribute(ScaleOfMeasurements scale, string symbolString)
        {
            Scale = scale;
            SymbolString = symbolString;
        }
    }
}
