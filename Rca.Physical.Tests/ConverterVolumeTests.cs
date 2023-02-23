using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterVolumeTests
    {
        [TestMethod]
        public void ConvertLitreToMillilitre()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(296.65, PhysicalUnits.Litre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Millilitre);

            Assert.AreEqual(296650, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Millilitre, result.Unit);
        }

        [TestMethod]
        public void ConvertCubicmeterToLitre()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(5.7152, PhysicalUnits.CubicMetre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Litre);

            Assert.AreEqual(5715.2, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Litre, result.Unit);
        }

        [TestMethod]
        public void ConvertMillilitreToLitre()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(2966.5, PhysicalUnits.Millilitre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Litre);

            Assert.AreEqual(2.9665, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Litre, result.Unit);
        }

        [TestMethod]
        public void ConvertLitreToCubicmeter()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(5715.19, PhysicalUnits.Litre);

            var result = converter.Convert(sourceValue, PhysicalUnits.CubicMetre);

            Assert.AreEqual(5.71519, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.CubicMetre, result.Unit);
        }
    }
}
