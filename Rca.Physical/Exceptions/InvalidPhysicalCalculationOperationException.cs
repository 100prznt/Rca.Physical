using Rca.Physical.Dimensions.Arithmetric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Exceptions
{
    public class InvalidPhysicalCalculationOperationException : Exception
    {
        public ArithmetricOperations Operation { get; set; }

        public PhysicalValue Argument1 { get; set; }

        public PhysicalValue Argument2 { get; set; }

        public InvalidPhysicalCalculationOperationException(ArithmetricOperations operation, PhysicalValue argument1, PhysicalValue argument2)
            : base(operation.ToString() + " for the following arguments not possible:\n"
                  + "Arg1: " + argument1.ToString()
                  + "Arg2: " + argument2.ToString())
        {

        }

        public InvalidPhysicalCalculationOperationException(ArithmetricOperations operation, PhysicalValue argument1, PhysicalValue argument2, string detailedMessage)
            : base(operation.ToString() + " for the following arguments not possible:\n"
                  + "Arg1: " + argument1.ToString() + "\n"
                  + "Arg2: " + argument2.ToString() + "\n"
                  + "Detailed message: " + detailedMessage)
        {

        }

        public InvalidPhysicalCalculationOperationException() : base()
        {

        }

        public InvalidPhysicalCalculationOperationException(string massage) : base(massage)
        {

        }

        public InvalidPhysicalCalculationOperationException(string massage, Exception innerException) : base(massage, innerException)
        {

        }
    }
}
