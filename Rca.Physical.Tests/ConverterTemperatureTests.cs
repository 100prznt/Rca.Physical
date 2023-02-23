using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterTemperatureTests
    {
        [TestMethod]
        public void ConvertKelvinToCelsius()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(296.65, PhysicalUnits.Kelvin);

            var result = converter.Convert(sourceValue, PhysicalUnits.Celsius);

            Assert.AreEqual(23.5, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Celsius, result.Unit);
        }

        [TestMethod]
        public void ConvertCelsiusToKelvin()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(57.15, PhysicalUnits.Celsius);

            var result = converter.Convert(sourceValue, PhysicalUnits.Kelvin);

            Assert.AreEqual(330.3, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Kelvin, result.Unit);
        }
    }
}
