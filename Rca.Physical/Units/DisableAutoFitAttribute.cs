using System;
using System.Collections.Generic;
using System.Text;

namespace Rca.Physical.Units
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DisableAutoFitAttribute : Attribute
    {
        /// <summary>
        /// This unit is not used for the the auto fit function
        /// </summary>
        public bool AutoFitIsDisabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimension"></param>
        public DisableAutoFitAttribute(bool disableAutoFit = true)
        {
            AutoFitIsDisabled = disableAutoFit;
        }
    }
}
