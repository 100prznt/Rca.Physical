using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterSpeedTests
    {
        [TestMethod]
        public void ConvertKilometrePerHourToMetrePerSecond()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(200, PhysicalUnits.KilometrePerHour);

            var result = converter.Convert(sourceValue, PhysicalUnits.MetrePerSecond);

            Assert.AreEqual(55.55555556, result.Value, 1E-8);
            Assert.AreEqual(PhysicalUnits.MetrePerSecond, result.Unit);
        }

        [TestMethod]
        public void ConvertKilometrePerHourToMetrePerHour()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(200, PhysicalUnits.KilometrePerHour);

            var result = converter.Convert(sourceValue, PhysicalUnits.MetrePerHour);

            Assert.AreEqual(124.274139028255, result.Value, 1E-8);
            Assert.AreEqual(PhysicalUnits.MetrePerHour, result.Unit);
        }
    }
}
