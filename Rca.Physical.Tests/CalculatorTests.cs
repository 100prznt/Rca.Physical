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

        [TestMethod]
        public void MultiplicationVelocityAndArea()
        {
            Calculator.TryMultiply(new PhysicalValue(1.731, PhysicalUnits.MetrePerSecond), new PhysicalValue(0.0016045998637475229, PhysicalUnits.SquareMetre), out var result);

            Assert.AreEqual(10, result.ValueAs(PhysicalUnits.CubicMetrePerHour), 1E-3);
        }

        

         [TestMethod]
        public void DivisionFlowRateByArea()
        {
            Calculator.TryDivide(new PhysicalValue(5, PhysicalUnits.CubicMetrePerHour), new PhysicalValue(0.0016045998637475229, PhysicalUnits.SquareMetre), out var result);

            Assert.AreEqual(0.866, result.ValueAs(PhysicalUnits.MetrePerSecond), 1E-3);
        }

    }
}
