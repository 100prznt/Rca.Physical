using Rca.Physical.Dimensions;
using Rca.Physical.Dimensions.Arithmetric;
using Rca.Physical.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical
{
    /// <summary>
    /// This class provides mathematical functions for <seealso cref="PhysicalValue"/>.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Buffer to hold arithmetric function for dimension derivation.
        /// <para/><see langword="key"/>: DimensionValue1; <see langword="value"/>: <see cref="FunctionDescription"/>
        /// </summary>
        internal static ConcurrentDictionary<PhysicalDimensions, FunctionDescription[]> DimensionsFunctionsBuffer;
        internal static bool BufferIsInitialized = false;

        #region Member


        #endregion Member

        #region Properties


        #endregion Properties

        #region Constructor
        /// <summary>
        /// Default constructor for Calcualtor.
        /// The constructor is used to initialize the buffer with all available derivation functions.
        /// </summary>
        public Calculator()
        {
            if (!BufferIsInitialized)
                InitializeBuffer();
        }

        #endregion Constructor

        #region Services

        /// <summary>
        /// Adds multiple <seealso cref="PhysicalValue">PhysicalValues</seealso>.
        /// </summary>
        /// <param name="summands">Summands</param>
        /// <returns>Sum of values</returns>
        /// <exception cref="InvalidPhysicalCalculationOperationException">No derivation function available for the input values.</exception>
        /// <exception cref="ArgumentException">Params array are empty.</exception>
        public static PhysicalValue Add(params PhysicalValue[] summands)
        {
            if (summands == null || summands.Length < 1)
                throw new ArgumentException("Params array are empty! At least one summand must be provided.");

            var sum = summands[0];

            for (int i = 1; i < summands.Length; i++)
                if (!TryAdd(sum, summands[i], out sum))
                    throw new InvalidPhysicalCalculationOperationException(ArithmetricOperations.Addition, sum, summands[i], "No derivation function available.");

            return sum;
        }

        /// <summary>
        /// Adds two <seealso cref="PhysicalValue">PhysicalValues</seealso>.
        /// A return value indicates whether the calculation succeeded or failed. This method works internaly without any exceptions.
        /// </summary>
        /// <param name="summand1">First summand</param>
        /// <param name="summand2">Second summand</param>
        /// <param name="sum">Sum of values</param>
        public static bool TryAdd(PhysicalValue summand1, PhysicalValue summand2, out PhysicalValue sum)
        {
            return TryCalculate(ArithmetricOperations.Addition, summand1, summand2, out sum);
        }

        /// <summary>
        /// Subtracts two <seealso cref="PhysicalValue">PhysicalValues</seealso>.
        /// </summary>
        /// <param name="minuend">Minuend</param>
        /// <param name="subtrahend">Subtrahend</param>
        /// <returns>Difference</returns>
        /// <exception cref="InvalidPhysicalCalculationOperationException">No derivation function available for the input values.</exception>
        public static PhysicalValue Subtract(PhysicalValue minuend, PhysicalValue subtrahend)
        {
            if (TrySubtract(minuend, subtrahend, out var difference))
                return difference;
            else
                throw new InvalidPhysicalCalculationOperationException(ArithmetricOperations.Subtraction, minuend, subtrahend, "No derivation function available.");
        }

        /// <summary>
        /// Subtracts two <seealso cref="PhysicalValue">PhysicalValues</seealso>.
        /// A return value indicates whether the calculation succeeded or failed. This method works internaly without any exceptions.
        /// </summary>
        /// <param name="minuend">Minuend</param>
        /// <param name="subtrahend">Subtrahend</param>
        /// <param name="difference">Difference</param>
        public static bool TrySubtract(PhysicalValue minuend, PhysicalValue subtrahend, out PhysicalValue difference)
        {
            return TryCalculate(ArithmetricOperations.Subtraction, minuend, subtrahend, out difference);
        }

        /// <summary>
        /// Multiply multiple <seealso cref="PhysicalValue">PhysicalValues</seealso>.
        /// </summary>
        /// <param name="factors">Factors</param>
        /// <returns>Product of values</returns>
        /// <exception cref="InvalidPhysicalCalculationOperationException">No derivation function available for the input values.</exception>
        /// <exception cref="ArgumentException">Params array are empty.</exception>
        public static PhysicalValue Multiply(params PhysicalValue[] factors)
        {
            if (factors == null || factors.Length < 1)
                throw new ArgumentException("Params array are empty! At least one factor must be provided.");

            var product = factors[0];

            for (int i = 1; i < factors.Length; i++)
                if (!TryMultiply(product, factors[i], out product))
                    throw new InvalidPhysicalCalculationOperationException(ArithmetricOperations.Multiplication, product, factors[i], "No derivation function available.");

            return product;
        }

        /// <summary>
        /// Multiply multiple <seealso cref="PhysicalValue">PhysicalValues</seealso>.
        /// A return value indicates whether the calculation succeeded or failed. This method works internaly without any exceptions.
        /// </summary>
        /// <param name="factor1">First factor</param>
        /// <param name="factor2">Second factor</param>
        /// <param name="product">Product of values</param>
        public static bool TryMultiply(PhysicalValue factor1, PhysicalValue factor2, out PhysicalValue product)
        {
            return TryCalculate(ArithmetricOperations.Multiplication, factor1, factor2, out product);
        }

        /// <summary>
        /// Divides two <seealso cref="PhysicalValue">PhysicalValues</seealso>.
        /// </summary>
        /// <param name="dividend">Dividend</param>
        /// <param name="divisor">Divisor</param>
        /// <returns>Quotient</returns>
        /// <exception cref="InvalidPhysicalCalculationOperationException">No derivation function available for the input values.</exception>
        public static PhysicalValue Divide(PhysicalValue dividend, PhysicalValue divisor)
        {
            if (TryDivide(dividend, divisor, out var quotient))
                return quotient;
            else
                throw new InvalidPhysicalCalculationOperationException(ArithmetricOperations.Division, dividend, divisor, "No derivation function available.");
        }

        /// <summary>
        /// Divides two <seealso cref="PhysicalValue">PhysicalValues</seealso>.
        /// A return value indicates whether the calculation succeeded or failed. This method works internaly without any exceptions.
        /// </summary>
        /// <param name="dividend">Dividend</param>
        /// <param name="divisor">Divisor</param>
        /// <param name="quotient">Quotient</param>
        public static bool TryDivide(PhysicalValue dividend, PhysicalValue divisor, out PhysicalValue quotient)
        {
            return TryCalculate(ArithmetricOperations.Division, dividend, divisor, out quotient);
        }


        /// <summary>
        /// Returns a specified <see cref="PhysicalValue"/> raised to the specified power.
        /// </summary>
        /// <param name="x">Base (a <see cref="PhysicalValue"/> to be raised to a power)</param>
        /// <param name="y">Exponent (a number that specifies a power)</param>
        /// <returns>The <see cref="PhysicalValue"/> <paramref name="x"/> raised to the power <paramref name="y"/>.</returns>
        /// <exception cref="InvalidPhysicalCalculationOperationException">No derivation function available for the input values.</exception>
        /// <exception cref="ArgumentException">The exponent must be 1 or larger.</exception>
        public static PhysicalValue Power(PhysicalValue x, int y)
        {

            if (TryPower(x, y, out var power))
                return power;
            else
                throw new InvalidPhysicalCalculationOperationException(ArithmetricOperations.Exponentiation, x, new PhysicalValue(y, PhysicalUnits.None), "No derivation function available.");
        }

        /// <summary>
        /// Returns a specified <see cref="PhysicalValue"/> raised to the specified power.
        /// A return value indicates whether the calculation succeeded or failed. This method works internaly without any exceptions.
        /// </summary>
        /// <param name="x">Base (a <see cref="PhysicalValue"/> to be raised to a power)</param>
        /// <param name="y">Exponent (a number that specifies a power)</param>
        /// <param name="power">The <see cref="PhysicalValue"/> <paramref name="x"/> raised to the power <paramref name="y"/>.</param>
        public static bool TryPower(PhysicalValue x, int y, out PhysicalValue power)
        {
            switch (y)
            {
                case 1:
                    power = x;
                    break;
                case 2:
                    return TryMultiply(x, x, out power);
                case 3:
                    if (TryMultiply(x, x, out var interimResult))
                        return TryMultiply(interimResult, x, out power);
                    break;
            }

            power = null;
            return false;
        }

        #endregion Services

        #region Internal services


        internal static bool TryCalculate(ArithmetricOperations operation, PhysicalValue argument1, PhysicalValue argument2, out PhysicalValue result)
        {
            if (TryGetFunction(operation, argument1.Dimension, argument2.Dimension, out var function))
            {
                var value = double.NaN;

#if DEBUG
                var baseValue1 = argument1.GetBaseValue();
                var baseValue2 = argument2.GetBaseValue();
#endif

                switch (operation)
                {
                    case ArithmetricOperations.Addition:
                        value = argument1.GetBaseValue() + argument2.GetBaseValue();
                        break;
                    case ArithmetricOperations.Subtraction:
                        value = argument1.GetBaseValue() - argument2.GetBaseValue();
                        break;
                    case ArithmetricOperations.Multiplication:
                        value = argument1.GetBaseValue() * argument2.GetBaseValue();
                        break;
                    case ArithmetricOperations.Division:
                        value = argument1.GetBaseValue() / argument2.GetBaseValue();
                        break;
                }

                //TODO: Ckeck scaling
                if (argument1.Unit == argument2.Unit && (operation == ArithmetricOperations.Addition || operation == ArithmetricOperations.Subtraction))
                    result = new PhysicalValue(value, function.DimensionResult.GetBaseUnit()).Convert(argument1.Unit);
                else
                    result = new PhysicalValue(value, function.DimensionResult.GetBaseUnit()); //use SI base unit

                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        private static void InitializeBuffer(bool forceInitialization = false)
        {
            if (BufferIsInitialized & !forceInitialization)
                return;
            
            if (forceInitialization || DimensionsFunctionsBuffer == null || DimensionsFunctionsBuffer.IsEmpty)
            {
                DimensionsFunctionsBuffer = new ConcurrentDictionary<PhysicalDimensions, FunctionDescription[]>();

                var dimensions = (PhysicalDimensions[])Enum.GetValues(typeof(PhysicalDimensions));

                foreach (var dim in dimensions)
                {
                    var functions = dim.GetDerivationFunctions();
                    foreach (var function in functions)
                    {
                        AddFunction(function);

                        if (function.DimensionArgument1 != function.DimensionArgument2 && (function.Operation == ArithmetricOperations.Multiplication || function.Operation == ArithmetricOperations.Addition))
                        {
                            var swappedFunction = new FunctionDescription(function.Operation, function.DimensionArgument2, function.DimensionArgument1, function.DimensionResult);
                            AddFunction(swappedFunction);
                        }

                        foreach (var inverseFunction in GetInverseFunctions(function))
                            AddFunction(inverseFunction);
                    }
                }

                BufferIsInitialized = true;
            }
        }

        private static void AddFunction(FunctionDescription function)
        {
            if (DimensionsFunctionsBuffer.TryGetValue(function.DimensionArgument1, out var bufferedFunctions))
            {
                if (!bufferedFunctions.Contains(function))
                {
                    var bufferedFunctionList = bufferedFunctions.ToList();
                    bufferedFunctionList.Add(function);
                    bufferedFunctions = bufferedFunctionList.ToArray();
                }
            }
            else
                bufferedFunctions = new FunctionDescription[] { function };

            DimensionsFunctionsBuffer.AddOrUpdate(function.DimensionArgument1, bufferedFunctions, (k, old) => bufferedFunctions);
        }

        private static bool TryGetFunction(ArithmetricOperations operation, PhysicalDimensions dimensionArgument1, PhysicalDimensions dimensionArgument2, out FunctionDescription function)
        {
            InitializeBuffer();

            var requestedFunction = new FunctionDescription(operation, dimensionArgument1, dimensionArgument2, PhysicalDimensions.NotDefined);

            function = default;

            if (DimensionsFunctionsBuffer.TryGetValue(dimensionArgument1, out var functionDescriptions))
            {
                var selectedFunctions = functionDescriptions.Where(x => x.Equals(requestedFunction)).ToArray();
                if (selectedFunctions.Length == 1)
                {
                    function = selectedFunctions[0];
                    return true;
                }
                else if (selectedFunctions.Length > 1)
                    throw new ApplicationException("Inconsistent derivation functions, multiple entries were found for the following operation:\n"
                        + $"{requestedFunction}");
            }
                
            return false;
            
        }

        private static FunctionDescription[] GetInverseFunctions(FunctionDescription function)
        {
            var inverseFunctions = new List<FunctionDescription>();

            switch (function.Operation)
            {
                case ArithmetricOperations.Addition:
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Subtraction, function.DimensionResult, function.DimensionArgument2, function.DimensionArgument1));
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Subtraction, function.DimensionResult, function.DimensionArgument1, function.DimensionArgument2));
                    break;
                case ArithmetricOperations.Subtraction:
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Addition, function.DimensionResult, function.DimensionArgument2, function.DimensionArgument1));
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Addition, function.DimensionArgument2, function.DimensionResult, function.DimensionArgument1));
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Subtraction, function.DimensionArgument1, function.DimensionResult, function.DimensionArgument2));
                    break;
                case ArithmetricOperations.Multiplication:
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Division, function.DimensionResult, function.DimensionArgument2, function.DimensionArgument1));
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Division, function.DimensionResult, function.DimensionArgument1, function.DimensionArgument2));
                    break;
                case ArithmetricOperations.Division:
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Multiplication, function.DimensionResult, function.DimensionArgument2, function.DimensionArgument1));
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Multiplication, function.DimensionArgument2, function.DimensionResult, function.DimensionArgument1));
                    inverseFunctions.Add(new FunctionDescription(ArithmetricOperations.Division, function.DimensionArgument1, function.DimensionResult, function.DimensionArgument2));
                    break;
            }

            return inverseFunctions.ToArray();
        }

        #endregion Internal services

        #region Events


        #endregion Events
    }
}
