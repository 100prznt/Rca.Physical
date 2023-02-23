using Rca.Physical.Dimensions.Arithmetric;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Dimensions
{
    public static class DimensionsExtension
    {
        private static ConcurrentDictionary<PhysicalDimensions, PhysicalUnits> DimensionsBaseUnitBuffer = new ConcurrentDictionary<PhysicalDimensions, PhysicalUnits>();
        private static ConcurrentDictionary<PhysicalDimensions, string[]> DimensionsSymbolsBuffer = new ConcurrentDictionary<PhysicalDimensions, string[]>();
        private static ConcurrentDictionary<PhysicalDimensions, FunctionDescription[]> DimensionsDerivationFunctionsBuffer = new ConcurrentDictionary<PhysicalDimensions, FunctionDescription[]>();



        /// <summary>
        /// Returns the base unit.
        /// </summary>
        /// <param name="dimension">Physical dimension from which the unit is to be returned.</param>
        /// <returns>Base unit</returns>
        public static PhysicalUnits GetBaseUnit(this PhysicalDimensions dimension)
        {
            if (DimensionsBaseUnitBuffer.ContainsKey(dimension))
                return DimensionsBaseUnitBuffer[dimension];


            var attr = GetAttribute<BaseUnitAttribute>(dimension);
            var baseUnit = attr == null ? PhysicalUnits.None : attr.BaseUnit; //default is None
            DimensionsBaseUnitBuffer.AddOrUpdate(dimension, baseUnit, (k, old) => baseUnit);

            return baseUnit;
        }

        /// <summary>
        /// Returns the dimension symbol.
        /// </summary>
        /// <param name="dimension">Dimension from which the symbol is to be returned.</param>
        /// <returns>Dimension symbol</returns>
        public static string[] GetSymbols(this PhysicalDimensions dimension)
        {
            if (DimensionsSymbolsBuffer.ContainsKey(dimension))
                return DimensionsSymbolsBuffer[dimension];


            var symbolStrings = GetAttributes<SymbolAttribute>(dimension).Select(x => x.SymbolString).ToArray();
            if (symbolStrings.Length == 0)
                symbolStrings = new string[] { dimension.ToString() };
            DimensionsSymbolsBuffer.AddOrUpdate(dimension, symbolStrings, (k, old) => symbolStrings);

            return symbolStrings;
        }

        [Obsolete("Use -> GetDerivationFunctions()")]
        internal static bool HasDerivationFunction(this PhysicalDimensions dimension, out PhysicalDimensions dimensionValue1, out PhysicalDimensions dimensionValue2)
        {
            dimensionValue1 = PhysicalDimensions.None;
            dimensionValue2 = PhysicalDimensions.None;

            IDerivationFunction[] derivationAttributes = null;

            if (DimensionsDerivationFunctionsBuffer.ContainsKey(dimension))
            {
                //derivationAttributes = DimensionsDerivationFunctionsBuffer[dimension];
            }
            else
            {
                derivationAttributes = GetAttributes<IDerivationFunction>(dimension);
                //DimensionsDerivationFunctionsBuffer.AddOrUpdate(dimension, derivationAttributes, (k, old) => derivationAttributes);
            }

            if (derivationAttributes.Length == 0)
                return false;
            else
            {
                dimensionValue1 = derivationAttributes[0].DimensionValue1;
                dimensionValue2 = derivationAttributes[0].DimensionValue2;

                return true;
            }
        }

        internal static FunctionDescription[] GetDerivationFunctions(this PhysicalDimensions dimension)
        {
            //TODO: Wenn Methode nur vom Calculator genutzt wird wäre eine Bufferung hier nicht nötig, da im Calculator schon gebuffert wird.

            if (DimensionsDerivationFunctionsBuffer.ContainsKey(dimension))
                return DimensionsDerivationFunctionsBuffer[dimension];


            var functionList = new List<FunctionDescription>();

            foreach (var attr in GetAttributes<IDerivationFunction>(dimension))
                functionList.Add(new FunctionDescription(attr.ArithmetricFunction, attr.DimensionValue1, attr.DimensionValue2, dimension));

            var functions = functionList.ToArray();

            DimensionsDerivationFunctionsBuffer.AddOrUpdate(dimension, functions, (k, old) => functions);

            return functions;
        }

        internal static T GetAttribute<T>(PhysicalDimensions dimension) where T : class
        {
            foreach (var attr in GetAttributes(dimension))
                if (attr is T selectedAttr)
                    return selectedAttr;

            return null;
        }

        internal static T[] GetAttributes<T>(PhysicalDimensions dimension) where T : class
        {
            var attributes = new List<T>();

            foreach (var attr in GetAttributes(dimension))
                if (attr is T selectedAttr)
                    attributes.Add(selectedAttr);

            return attributes.ToArray();
        }

        internal static Object[] GetAttributes(PhysicalDimensions dimension)
        {
            var field = dimension.GetType().GetField(dimension.ToString());
            return field.GetCustomAttributes(false);
        }
    }
}
