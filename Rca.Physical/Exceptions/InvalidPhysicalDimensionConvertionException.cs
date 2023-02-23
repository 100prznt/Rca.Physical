using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Exceptions
{
    public class InvalidPhysicalDimensionConvertionException : Exception
    {
        public PhysicalDimensions SourceDimension { get; set; }

        public PhysicalDimensions TargetDimension { get; set; }

        public InvalidPhysicalDimensionConvertionException(PhysicalDimensions sourceDimension, PhysicalDimensions targetDimension)
            : base("Convert " + sourceDimension.ToString() + " to " + targetDimension.ToString() + " is not possible.")
        {

        }

        public InvalidPhysicalDimensionConvertionException() : base()
        {

        }

        public InvalidPhysicalDimensionConvertionException(string massage) : base(massage)
        {

        }

        public InvalidPhysicalDimensionConvertionException(string massage, Exception innerException) : base(massage, innerException)
        {

        }
    }
}
