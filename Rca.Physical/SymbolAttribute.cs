using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class SymbolAttribute : Attribute
    {
        /// <summary>
        /// Symbol as string
        /// </summary>
        public string SymbolString { get; set; }

        /// <summary>
        /// Info about the symbol
        /// </summary>
        /// <param name="symbolString">Symbol as string</param>
        public SymbolAttribute(string symbolString)
        {
            SymbolString = symbolString;
        }
    }
}
