using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AlternativeSymbolNotationsAttribute : Attribute
    {
        /// <summary>
        /// Alternatively symbol notation strings
        /// </summary>
        public string[] SymbolNotationStrings { get; private set; }

        /// <summary>
        /// Alternatively permissible unit symbol notations
        /// </summary>
        /// <param name="notations">Alternative notation strings</param>
        public AlternativeSymbolNotationsAttribute(params string[] notations)
        {
            SymbolNotationStrings = notations;
        }
    }
}
