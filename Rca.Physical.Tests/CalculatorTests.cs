using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void InitCalculatorTest()
        {
            Calculator.TryMultiply(new PhysicalValue(12, PhysicalUnits.Volt), new PhysicalValue(1, PhysicalUnits.Celsius), out var result);
        }
    }
}
