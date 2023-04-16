using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class PhysicalValue_ToString_Tests
    {

        [TestMethod]
        public void NaN_ToString()
        {

            PhysicalValue value = PhysicalValue.NaN;

            var result = value.ToString();

            Assert.AreEqual("NaN", result);
        }


        [TestMethod]
        public void NaN_ToString_AutoFit()
        {

            PhysicalValue value = PhysicalValue.NaN;

            var result = value.ToString(true, "N2");

            Assert.AreEqual("NaN", result);
        }
    }
}
