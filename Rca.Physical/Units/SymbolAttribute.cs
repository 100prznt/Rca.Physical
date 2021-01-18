using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical.Units
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    public class SymbolAttribute : Attribute
    {
        /// <summary>
        /// Unit symbol as string
        /// </summary>
        public string UnitSymbolString { get; set; }

        /// <summary>
        /// Info about the unit symbol
        /// </summary>
        /// <param name="unitSymbolString">Unit symbol as string</param>
        public SymbolAttribute(string unitSymbolString)
        {
            UnitSymbolString = unitSymbolString;
        }
    }
}
