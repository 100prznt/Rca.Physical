using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterPressureTests
    {
        [TestMethod]
        public void ConvertBarToPascal()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(296.65, PhysicalUnits.Bar);

            var result = converter.Convert(sourceValue, PhysicalUnits.Pascal);

            Assert.AreEqual(29665000, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Pascal, result.Unit);
        }

        [TestMethod]
        public void ConvertPascalToBar()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(57.15, PhysicalUnits.Pascal);

            var result = converter.Convert(sourceValue, PhysicalUnits.Bar);

            Assert.AreEqual(0.0005715, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Bar, result.Unit);
        }

        [TestMethod]
        public void ConvertmBarToPascal()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(296.65, PhysicalUnits.Millibar);

            var result = converter.Convert(sourceValue, PhysicalUnits.Pascal);

            Assert.AreEqual(29665, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Pascal, result.Unit);
        }

        [TestMethod]
        public void ConvertPascalTomBar()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(57.15, PhysicalUnits.Pascal);

            var result = converter.Convert(sourceValue, PhysicalUnits.Millibar);

            Assert.AreEqual(0.5715, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Millibar, result.Unit);
        }
    }
}
