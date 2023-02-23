using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class DerivationSpeedTests
    {
        [TestMethod]
        public void CalculateMetrePerSecondFromMetreAndSecond()
        {
            var a = new PhysicalValue(41.753, PhysicalUnits.Metre);
            var b = new PhysicalValue(6.951, PhysicalUnits.Second);

            var res = a / b;

            Assert.AreEqual(6.006761617, res.Value, 1E-10);
            Assert.AreEqual(PhysicalUnits.MetrePerSecond, res.Unit);
        }

        [TestMethod]
        public void CalculateKilometrePerSecondFromKilometreAndHour()
        {
            var a = new PhysicalValue(200, PhysicalUnits.Kilometre);
            var b = new PhysicalValue(2, PhysicalUnits.Hour);

            var res = a / b;

            Assert.AreEqual(27.7777777778, res.Value, 1E-10);
            Assert.AreEqual(PhysicalUnits.MetrePerSecond, res.Unit);
        }
    }
}
