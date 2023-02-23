using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class DerivationAreaTests
    {
        [TestMethod]
        public void CalculateSquaremeterFromMeter()
        {
            var a = new PhysicalValue(4.753, PhysicalUnits.Metre);
            var b = new PhysicalValue(6.951, PhysicalUnits.Metre);

            var res = a * b;

            Assert.AreEqual(33.038103, res.Value, 1E-10);
            Assert.AreEqual(PhysicalUnits.SquareMetre, res.Unit);
        }

        [TestMethod]
        public void CalculateSquaremeterFromMillimeter()
        {
            var a = new PhysicalValue(475.3, PhysicalUnits.Millimetre);
            var b = new PhysicalValue(695.1, PhysicalUnits.Millimetre);

            var res = a * b;

            Assert.AreEqual(0.33038103, res.Value, 1E-10);
            Assert.AreEqual(PhysicalUnits.SquareMetre, res.Unit);
        }

        [TestMethod]
        public void CalculateSquaremeterFromCentimeterMeter()
        {
            var a = new PhysicalValue(175.36, PhysicalUnits.Centimetre);
            var b = new PhysicalValue(2.951, PhysicalUnits.Metre);

            var res = a * b;

            Assert.AreEqual(5.1748736, res.Value, 1E-10);
            Assert.AreEqual(PhysicalUnits.SquareMetre, res.Unit);
        }
    }
}
