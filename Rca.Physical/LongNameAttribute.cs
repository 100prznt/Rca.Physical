using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical
{
    [AttributeUsage(AttributeTargets.Field)]
    public class LongNameAttribute : Attribute
    {
        /// <summary>
        /// Long name as string
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Long name of the dimension or unit
        /// </summary>
        /// <param name="name">Name as string</param>
        public LongNameAttribute(string name)
        {
            LongName = name;
        }
    }
}
