using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class DerivationVolumeTests
    {
        [TestMethod]
        public void CalculateVolumeFromSquaremeterMeter()
        {
            var a = new PhysicalValue(4.753, PhysicalUnits.SquareMetre);
            var b = new PhysicalValue(6.951, PhysicalUnits.Metre);

            var res = a * b;

            Assert.AreEqual(33.038103, res.Value, 1E-10);
            Assert.AreEqual(PhysicalUnits.CubicMetre, res.Unit);
        }

        [TestMethod]
        public void CalculateVolumeFromSquaremeterMillimeter()
        {
            var a = new PhysicalValue(475.3, PhysicalUnits.Millimetre);
            var b = new PhysicalValue(0.6951, PhysicalUnits.SquareMetre);

            var res = a * b;

            Assert.AreEqual(0.33038103, res.Value, 1E-10);
            Assert.AreEqual(PhysicalUnits.CubicMetre, res.Unit);
        }

        [TestMethod]
        public void CalculateVolumeFromSquaremeterCentimeter()
        {
            var a = new PhysicalValue(175.36, PhysicalUnits.Centimetre);
            var b = new PhysicalValue(2.951, PhysicalUnits.SquareMetre);

            var res = a * b;

            Assert.AreEqual(5.1748736, res.Value, 1E-10);
            Assert.AreEqual(PhysicalUnits.CubicMetre, res.Unit);
        }
    }
}
