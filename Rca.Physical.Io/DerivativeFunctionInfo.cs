using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rca.Physical.Dimensions.Arithmetric;

namespace Rca.Physical.Io
{
    public class DerivativeFunctionInfo
    {
        public static string CsvHeader => "\"Dimension\",\"Formula\",\"Unit Formula\",\"Description\"";

        internal PhysicalDimensions Dimension { get; }

        internal FunctionDescription Function { get; }

        internal DerivativeFunctionInfo(FunctionDescription function)
        {
            Function = function;
            Dimension = function.DimensionResult;
        }

        public string ToCsvLine()
        {
            return $"\"{Dimension}\",\"{Function.GetFormula()}\",\"{Function.GetUnitFormula()}\",\"{Function}\"";
        }
    }
}
