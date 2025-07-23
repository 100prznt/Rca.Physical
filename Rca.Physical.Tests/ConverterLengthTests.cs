using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterLengthTests
    {
        [TestMethod]
        public void ConvertMetreToCentimetre()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(2.9665, PhysicalUnits.Metre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Centimetre);

            Assert.AreEqual(296.65, result.Value, 1E-8);
            Assert.AreEqual(PhysicalUnits.Centimetre, result.Unit);
        }

        [TestMethod]
        public void ConvertCentimetreToMetre()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(1357.15, PhysicalUnits.Centimetre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Metre);

            Assert.AreEqual(13.5715, result.Value, 1E-8);
            Assert.AreEqual(PhysicalUnits.Metre, result.Unit);
        }

        [TestMethod]
        public void ConvertMeterToMillimeter()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(2.79665, PhysicalUnits.Metre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Millimetre);

            Assert.AreEqual(2796.65, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Millimetre, result.Unit);
        }

        [TestMethod]
        public void ConvertMillimeterToMeter()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(1357.15, PhysicalUnits.Millimetre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Metre);

            Assert.AreEqual(1.35715, result.Value, 1E-10);
            Assert.AreEqual(PhysicalUnits.Metre, result.Unit);
        }

        [TestMethod]
        public void ConvertMeterToKilometer()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(2966.15, PhysicalUnits.Metre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Kilometre);

            Assert.AreEqual(2.96615, result.Value, 1E-8);
            Assert.AreEqual(PhysicalUnits.Kilometre, result.Unit);
        }

        [TestMethod]
        public void ConvertKilometerToMeter()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(13.57159, PhysicalUnits.Kilometre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Metre);

            Assert.AreEqual(13571.59, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Metre, result.Unit);
        }

        [TestMethod]
        public void ConvertMicrometreToMillimetre()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(254, PhysicalUnits.Micrometre);

            var result = converter.Convert(sourceValue, PhysicalUnits.Millimetre);

            Assert.AreEqual(0.254, result.Value, 1E-4);
            Assert.AreEqual(PhysicalUnits.Millimetre, result.Unit);
        }

        [TestMethod]
        public void ConvertMileToInch()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(1, PhysicalUnits.Mile);

            var result = converter.Convert(sourceValue, PhysicalUnits.Inch);

            Assert.AreEqual(63360, result.Value, 1); //TODO: to large error!
            Assert.AreEqual(PhysicalUnits.Inch, result.Unit);
        }
    }
}
