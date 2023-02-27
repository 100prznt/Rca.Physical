using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterAreaTests
    {
        [TestMethod]
        public void ConvertSquareMetreToSquareCentimetre()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(0.25, PhysicalUnits.SquareMetre);

            var result = converter.Convert(sourceValue, PhysicalUnits.SquareCentimetre);

            Assert.AreEqual(2500, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.SquareCentimetre, result.Unit);
        }

        [TestMethod]
        public void ConvertSquareMetreToSquareMillimetre()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(0.25, PhysicalUnits.SquareMetre);

            var result = converter.Convert(sourceValue, PhysicalUnits.SquareMillimetre);

            Assert.AreEqual(250000, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.SquareMillimetre, result.Unit);
        }

        [TestMethod]
        public void ConvertSquareMillimetreToSquareCentimetre()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(45821.54, PhysicalUnits.SquareMillimetre);

            var result = converter.Convert(sourceValue, PhysicalUnits.SquareCentimetre);

            Assert.AreEqual(458.2154, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.SquareCentimetre, result.Unit);
        }
    }
}
