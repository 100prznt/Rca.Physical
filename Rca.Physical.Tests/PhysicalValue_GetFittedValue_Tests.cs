using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class PhysicalValue_GetFittedValue_Tests
    {
        [TestMethod]
        public void MetreToCentimetre_Test()
        {
            //Centimetre is not marked for auto fitting!

            var a = new PhysicalValue(0.01, PhysicalUnits.Metre);

            var res = a.GetFittedPhysicalValue();

            Assert.AreEqual(PhysicalUnits.Millimetre, res.Unit);
            Assert.AreEqual(10, res.Value);
        }

        [TestMethod]
        public void MetreToMillimetre_Test()
        {
            var a = new PhysicalValue(0.001, PhysicalUnits.Metre);

            var res = a.GetFittedPhysicalValue();

            Assert.AreEqual(PhysicalUnits.Millimetre, res.Unit);
            Assert.AreEqual(1, res.Value);
        }


        [TestMethod]
        public void LitreToCubicMetre_Test()
        {
            var a = new PhysicalValue(1000, PhysicalUnits.Litre);

            var res = a.GetFittedPhysicalValue();

            Assert.AreEqual(PhysicalUnits.CubicMetre, res.Unit);
            Assert.AreEqual(1, res.Value);
        }
    }
}
