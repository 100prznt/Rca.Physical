using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class PhysicalValue_IEquatable_Tests
    {
        PhysicalValue m_NaN_a = PhysicalValue.NaN;
        PhysicalValue m_NaN_b = PhysicalValue.NaN;
        PhysicalValue m_PhysicalValue_25Celcius = new(25, PhysicalUnits.Celsius);
        PhysicalValue m_PhysicalValue_25Celcius_2 = new(25, PhysicalUnits.Celsius);
        PhysicalValue m_PhysicalValue_25Kelvin = new(25, PhysicalUnits.Kelvin);

        [TestMethod]
        public void NaN_a_NaN_b()
        {
            Assert.IsFalse(PhysicalValue.Equals(m_NaN_a, m_NaN_b));
        }

        [TestMethod]
        public void NaN_a_NaN_b_direct()
        {
            Assert.IsFalse(m_NaN_a.Equals(m_NaN_b));
        }

        [TestMethod]
        public void NaN_a_NaN_a()
        {
            Assert.IsFalse(PhysicalValue.Equals(m_NaN_a, m_NaN_a));
        }

        [TestMethod]
        public void NaN_a_PhysicalValue_25Celcius()
        {
            Assert.IsFalse(PhysicalValue.Equals(m_NaN_a, m_PhysicalValue_25Celcius));
        }

        [TestMethod]
        public void PhysicalValue_25Celcius()
        {
            Assert.IsTrue(PhysicalValue.Equals(m_PhysicalValue_25Celcius, m_PhysicalValue_25Celcius_2));
        }

        [TestMethod]
        public void PhysicalValue_25Celcius_m_PhysicalValue_25Kelvin()
        {
            Assert.IsFalse(PhysicalValue.Equals(m_PhysicalValue_25Celcius, m_PhysicalValue_25Kelvin));
        }

        [TestMethod]
        public void NaN_a_double25()
        {
            Assert.IsFalse(PhysicalValue.Equals(m_NaN_a, (double)25));
        }
    }
}
