using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Exceptions
{
    public class InvalidPhysicalUnitConvertionException : Exception
    {
        public PhysicalDimensions SourceDimension { get; set; }

        public PhysicalDimensions TargetDimension { get; set; }

        public InvalidPhysicalUnitConvertionException(PhysicalUnits sourceUnit, PhysicalUnits targetUnit)
            : base("Convert " + sourceUnit.ToString() + " to " + targetUnit.ToString() + " is not possible.")
        {

        }

        public InvalidPhysicalUnitConvertionException(PhysicalUnits sourceUnit, PhysicalUnits targetUnit, string detailedMessage)
            : base("Convert " + sourceUnit.ToString() + " to " + targetUnit.ToString() + " is not possible.\nDetailed message: " + detailedMessage)
        {

        }

        public InvalidPhysicalUnitConvertionException() : base()
        {

        }

        public InvalidPhysicalUnitConvertionException(string massage) : base(massage)
        {

        }

        public InvalidPhysicalUnitConvertionException(string massage, Exception innerException) : base(massage, innerException)
        {

        }
    }
}
