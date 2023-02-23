using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class PhysicalValue_Tests
    {
        [Ignore]
        [TestMethod]
        public void GetFittedPhysicalValue_Test()
        {
            var a = new PhysicalValue(0.01, PhysicalUnits.Metre);

            var res = a.GetFittedPhysicalValue();

            Assert.AreEqual(PhysicalUnits.Centimetre, res.Unit);
        }
    }
}
