using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterPowerTests
    {
        [TestMethod]
        public void ConvertWattToKilowatt()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(296.65, PhysicalUnits.Watt);

            var result = converter.Convert(sourceValue, PhysicalUnits.Kilowatt);

            Assert.AreEqual(0.29665, result.Value, 1E-4);
            Assert.AreEqual(PhysicalUnits.Kilowatt, result.Unit);
        }

        [TestMethod]
        public void ConvertKilowattToWatt()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(57.15, PhysicalUnits.Kilowatt);

            var result = converter.Convert(sourceValue, PhysicalUnits.Watt);

            Assert.AreEqual(57150, result.Value, 1);
            Assert.AreEqual(PhysicalUnits.Watt, result.Unit);
        }

        [TestMethod]
        public void ConvertHorsepowerToWatt()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(57.15, PhysicalUnits.Horsepower);

            var result = converter.Convert(sourceValue, PhysicalUnits.Watt);

            Assert.AreEqual(42616.74766, result.Value, 1E-5);
            Assert.AreEqual(PhysicalUnits.Watt, result.Unit);
        }

        [TestMethod]
        public void ConvertWattToHorsepower()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(13457.15, PhysicalUnits.Watt);

            var result = converter.Convert(sourceValue, PhysicalUnits.Horsepower);

            Assert.AreEqual(18.046335, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Horsepower, result.Unit);
        }

        [TestMethod]
        public void ConvertPferdestaerkenToWatt()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(57.15, PhysicalUnits.Pferdestaerken);

            var result = converter.Convert(sourceValue, PhysicalUnits.Watt);

            Assert.AreEqual(42033.75356, result.Value, 1E-5);
            Assert.AreEqual(PhysicalUnits.Watt, result.Unit);
        }

        [TestMethod]
        public void ConvertWattToPferdestaerken()
        {
            var converter = new Converter();
            var sourceValue = new PhysicalValue(13457.15, PhysicalUnits.Watt);

            var result = converter.Convert(sourceValue, PhysicalUnits.Pferdestaerken);

            Assert.AreEqual(18.296632, result.Value, 1E-6);
            Assert.AreEqual(PhysicalUnits.Pferdestaerken, result.Unit);
        }
    }
}
