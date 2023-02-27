using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Exceptions
{
    public class PhysicalDimensionMismatchException : Exception
    {
        public PhysicalDimensions ExpectedDimension { get; set; }

        public PhysicalDimensions PassedDimension { get; set; }


        public PhysicalDimensionMismatchException(PhysicalDimensions expectedDimension, PhysicalDimensions passedDimension)
            : base($"Passed dimension of {passedDimension} not match, expected dimension of {expectedDimension}")
        {
            ExpectedDimension = expectedDimension;
            PassedDimension = passedDimension;
        }

        public PhysicalDimensionMismatchException() : base()
        {

        }

        public PhysicalDimensionMismatchException(string massage) : base(massage)
        {

        }

        public PhysicalDimensionMismatchException(string massage, Exception innerException) : base(massage, innerException)
        {

        }
    }
}
