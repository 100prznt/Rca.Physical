using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterVolumetricFlowTests
    {
        [TestMethod]
        public void ConvertCubicMetrePerHourToLitrePerMinute()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(30, PhysicalUnits.CubicMetrePerHour);

            var result = converter.Convert(sourceValue, PhysicalUnits.LitrePerMinute);

            Assert.AreEqual(500, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.LitrePerMinute, result.Unit);
        }
        [TestMethod]
        public void ConvertCubicMetrePerHourToCubicMetrePerSecond()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(30, PhysicalUnits.CubicMetrePerHour);

            var result = converter.Convert(sourceValue, PhysicalUnits.CubicMetrePerSecond);

            Assert.AreEqual(8.33333333333E-3, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.CubicMetrePerSecond, result.Unit);
        }

        [TestMethod]
        public void ConvertLitrePerMinuteToCubicMetrePerHour()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(100, PhysicalUnits.LitrePerMinute);

            var result = converter.Convert(sourceValue, PhysicalUnits.CubicMetrePerHour);

            Assert.AreEqual(6, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.CubicMetrePerHour, result.Unit);
        }

        [TestMethod]
        public void ConvertLitrePerSecondToCubicMetrePerHour()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(5, PhysicalUnits.LitrePerSecond);

            var result = converter.Convert(sourceValue, PhysicalUnits.CubicMetrePerHour);

            Assert.AreEqual(18, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.CubicMetrePerHour, result.Unit);
        }
    }
}
