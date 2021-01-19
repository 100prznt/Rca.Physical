using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Exceptions
{
    public class InvalidDimensionException : Exception
    {
        public PhysicalDimensions SourceDimension { get; set; }

        public PhysicalDimensions TargetDimension { get; set; }

        public InvalidDimensionException(PhysicalDimensions sourceDimension, PhysicalDimensions targetDimension)
            : base("Invalid conversion. Convert " + sourceDimension.ToString() + " to " + targetDimension.ToString() + " is not possible.")
        {

        }

        public InvalidDimensionException() : base()
        {

        }

        public InvalidDimensionException(string massage) : base(massage)
        {

        }

        public InvalidDimensionException(string massage, Exception innerException) : base(massage, innerException)
        {

        }
    }
}
