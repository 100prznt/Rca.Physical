using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class PhysicalValueTests
    {
        [TestMethod]
        public void AdditionCelsiusCelsius()
        {
            var a = new PhysicalValue(23.25, PhysicalUnits.Celsius);
            var b = new PhysicalValue(56.78, PhysicalUnits.Celsius);

            var result = a + b;

            Assert.AreEqual(new PhysicalValue(80.03, PhysicalUnits.Celsius), result);
        }

        [TestMethod]
        public void AdditionCelsiusKelvin()
        {
            var a = new PhysicalValue(23.25, PhysicalUnits.Celsius);
            var b = new PhysicalValue(303.94, PhysicalUnits.Kelvin);

            var result = a + b;

            Assert.AreEqual(new PhysicalValue(54.04, PhysicalUnits.Celsius), result);
        }

        [TestMethod]
        public void AdditionKelvinCelsius()
        {
            var a = new PhysicalValue(298.26, PhysicalUnits.Kelvin);
            var b = new PhysicalValue(36.41, PhysicalUnits.Celsius);

            var result = a + b;

            Assert.AreEqual(new PhysicalValue(54.04, PhysicalUnits.Kelvin), result);
        }
    }
}
