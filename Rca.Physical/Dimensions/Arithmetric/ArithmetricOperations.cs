using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Dimensions.Arithmetric
{
    public enum ArithmetricOperations
    {
        [Symbol("+")]
        Addition = 1,
        [Symbol("-")]
        Subtraction,
        [Symbol("*")]
        Multiplication,
        [Symbol("/")]
        Division,
        [Symbol("^")]
        Exponentiation = 100
    }
}
