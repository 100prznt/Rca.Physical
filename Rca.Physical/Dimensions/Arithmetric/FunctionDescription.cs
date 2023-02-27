using Rca.Physical.Helpers;
using Rca.Physical.Units;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Rca.Physical.Dimensions.Arithmetric
{
    [DebuggerDisplay("{DebuggerDisplayString, nq}")]
    internal struct FunctionDescription : IEquatable<FunctionDescription>
    {
        #region Fields
        private string DebuggerDisplayString => ToString();

        #endregion Fields

        public ArithmetricOperations Operation { get; private set; }
        public PhysicalDimensions DimensionArgument1 { get; private set; }
        public PhysicalDimensions DimensionArgument2 { get; private set; }
        public PhysicalDimensions DimensionResult { get; private set; }

        public FunctionDescription(ArithmetricOperations operation, PhysicalDimensions dimensionArgument1, PhysicalDimensions dimensionArgument2, PhysicalDimensions dimensionResult)
        {
            Operation = operation;
            DimensionArgument1 = dimensionArgument1;
            DimensionArgument2 = dimensionArgument2;
            DimensionResult = dimensionResult;
        }

        public override string ToString()
        {
            var symbolStr = GetOperationSymbol();

            if (DimensionResult == PhysicalDimensions.NotDefined || DimensionResult == PhysicalDimensions.None)
                return $"{DimensionArgument1} {symbolStr} {DimensionArgument2}";
            else
                return $"{DimensionResult} = {DimensionArgument1} {symbolStr} {DimensionArgument2}";
        }

        public string GetFormula()
        {
            var symbolStr = GetOperationSymbol();

            if (DimensionResult == PhysicalDimensions.NotDefined || DimensionResult == PhysicalDimensions.None)
                return $"{DimensionArgument1.GetSymbols()[0]} {symbolStr} {DimensionArgument2.GetSymbols()[0]}";
            else
                return $"{DimensionResult.GetSymbols()[0]} = {DimensionArgument1.GetSymbols()[0]} {symbolStr} {DimensionArgument2.GetSymbols()[0]}";
        }

        public string GetUnitFormula()
        {
            var symbolStr = GetOperationSymbol();

            var symbolArg1Str = DimensionArgument1.GetBaseUnit().GetSymbol();
            var symbolArg2Str = DimensionArgument2.GetBaseUnit().GetSymbol();
            var symbolResultStr = DimensionResult.GetBaseUnit().GetSymbol();

            if (string.IsNullOrWhiteSpace(symbolArg1Str) || string.IsNullOrWhiteSpace(symbolArg2Str) || string.IsNullOrWhiteSpace(symbolResultStr))
                return string.Empty;

            if (DimensionResult == PhysicalDimensions.NotDefined || DimensionResult == PhysicalDimensions.None)
                return $"[{symbolArg1Str}] {symbolStr} [{symbolArg2Str}]";
            else
                return $"[{symbolResultStr}] = [{symbolArg1Str}] {symbolStr} [{symbolArg2Str}]";
        }

        /// <summary>
        /// Returns a value indicating whether this instance and a specific <see cref="FunctionDescription"/> represent the same operation and dimension for argument 1 and 2.
        /// </summary>
        /// <param name="other"></param>
        /// <returns><see langword="true"/> if <paramref name="other"/> is equal to this instance; otherwise, <see langword="false"/></returns>
        public bool Equals(FunctionDescription other)
        {
            var operationEqual = Operation == other.Operation
                    && DimensionArgument1 == other.DimensionArgument1
                    && DimensionArgument2 == other.DimensionArgument2;

            if (other.DimensionResult == PhysicalDimensions.NotDefined)
                return operationEqual;
            else
                return operationEqual && DimensionResult == other.DimensionResult;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specific object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns><see langword="true"/> if <paramref name="obj"/> is an instance of <seealso cref="FunctionDescription"/> and equals the value, unit and scaling of this instance; otherwise, <see langword="false"/></returns>
        public override bool Equals(object? obj)
        {
            return obj is FunctionDescription description && Equals(description);
        }

        /// <summary>
        /// Returns the Hashcode for that instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Operation, DimensionArgument1, DimensionArgument2, DimensionResult);
        }

        private string GetOperationSymbol()
        {
            var fi = typeof(ArithmetricOperations).GetField(Operation.ToString());

            foreach (var attr in fi.GetCustomAttributes(false))
                if (attr is SymbolAttribute symbolAttr)
                    return symbolAttr.SymbolString;

            return Operation.ToString();
        }

#if DEBUG
        public string ToCSharp()
        {
            //var dummy = new FunctionDescription(ArithmetricOperations.Exponentiation, PhysicalDimensions.Costs, PhysicalDimensions.Costs, PhysicalDimensions.Costs);

            return $"new FunctionDescription(ArithmetricOperations.{Operation}, PhysicalDimensions.{DimensionArgument1}, PhysicalDimensions.{DimensionArgument2}, PhysicalDimensions.{DimensionResult})";
        }
#endif
    }
}
