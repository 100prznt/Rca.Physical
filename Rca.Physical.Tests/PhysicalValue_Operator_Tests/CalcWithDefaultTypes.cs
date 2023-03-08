using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.Physical.Helpers;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class CalcWithDefaultTypes
    {
        [TestMethod]
        public void DividePressureByInt()
        {
            var a = Pressure.FromBars(11);

            var res = a / 2;

            Assert.AreEqual(res.Value, 5.5, 1E-10);
            Assert.AreEqual(res.Unit, PhysicalUnits.Bar);
        }

        [TestMethod]
        public void DividePressureByDouble()
        {
            var a = Pressure.FromBars(12);

            var res = a / 2.5;

            Assert.AreEqual(res.Value, 4.8, 1E-10);
            Assert.AreEqual(res.Unit, PhysicalUnits.Bar);
        }

        [TestMethod]
        public void MultiplyPressureByInt()
        {
            var a = Pressure.FromBars(3.3);

            var res = a * 3;

            Assert.AreEqual(res.Value, 9.9, 1E-10);
            Assert.AreEqual(res.Unit, PhysicalUnits.Bar);
        }

        [TestMethod]
        public void MultiplyPressureByDouble()
        {
            var a = Pressure.FromBars(0.12);

            var res = a * 7.5;

            Assert.AreEqual(res.Value, 0.9, 1E-10);
            Assert.AreEqual(res.Unit, PhysicalUnits.Bar);
        }

    }
}
