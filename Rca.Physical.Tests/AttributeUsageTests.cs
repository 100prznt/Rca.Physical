using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.Physical.Dimensions;
using Rca.Physical.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class AttributeUsageTests
    {
        //[TestMethod]
        public void UniqueDimensionSymbolTests()
        {
            var symbolStrings = new List<string>();

            foreach (PhysicalDimensions dimension in Enum.GetValues(typeof(PhysicalDimensions)))
                symbolStrings.AddRange(dimension.GetSymbols());

            var query = symbolStrings.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => new { Symbol = y.Key, Counter = y.Count() })
              .ToList();


            var testResultMessage = new StringBuilder("Found duplicate dimension symbol names:\n");
            foreach (var item in query)
                testResultMessage.Append(item + "\n");

            Assert.AreEqual(0, query.Count, testResultMessage.ToString());

        }

        [TestMethod]
        public void UniqueUnitSymbolTests()
        {
            var symbolStrings = new List<string>();

            foreach (PhysicalUnits unit in Enum.GetValues(typeof(PhysicalUnits)))
                symbolStrings.Add(unit.GetSymbol());

            var query = symbolStrings.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => new { Symbol = y.Key, Counter = y.Count() })
              .ToList();


            var testResultMessage = new StringBuilder("Found duplicate unit symbol names:\n");
            foreach (var item in query)
                testResultMessage.Append(item + "\n");

            Assert.AreEqual(0, query.Count, testResultMessage.ToString());

        }
    }
}
