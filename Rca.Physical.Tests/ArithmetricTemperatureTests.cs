using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ArithmetricTemperatureTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void AdditionCelsiusCelsius()
        {
            var a = new PhysicalValue(23.25, PhysicalUnits.Celsius);
            var b = new PhysicalValue(56.78, PhysicalUnits.Celsius);

            _ = a + b; //throw ArithmeticException
        }

        [TestMethod]
        public void AdditionCelsiusKelvin()
        {
            var a = new PhysicalValue(23.25, PhysicalUnits.Celsius); //Absolute value (296.4 K)
            var b = new PhysicalValue(303.94, PhysicalUnits.Kelvin); //Offset value

            var result = a + b;

            Assert.AreEqual(327.19, result.ValueAs(PhysicalUnits.Celsius), 1E-10); //loose of precision through double datatype (327.18999999999994)

            //Double check also for Celsius
            Assert.AreEqual(600.34, result.ValueAs(PhysicalUnits.Kelvin), 1E-10); //loose of precision through double datatype
        }

        [TestMethod]
        public void AdditionKelvinCelsius()
        {
            var a = new PhysicalValue(298.26, PhysicalUnits.Kelvin);
            var b = new PhysicalValue(36.41, PhysicalUnits.Celsius);

            var result = a + b;

            Assert.AreEqual(607.82, result.ValueAs(PhysicalUnits.Kelvin), 1E-10); //loose of precision through double datatype

            //Double check also for Celsius
            Assert.AreEqual(334.67, result.ValueAs(PhysicalUnits.Celsius), 1E-10); //loose of precision through double datatype
        }

        [TestMethod]
        public void AdditionKelvinKelvin()
        {
            var a = new PhysicalValue(298.26, PhysicalUnits.Kelvin);
            var b = new PhysicalValue(36.41, PhysicalUnits.Kelvin);

            var result = a + b;

            Assert.AreEqual(334.67, result.ValueAs(PhysicalUnits.Kelvin), 1E-10); //loose of precision through double datatype
        }

        [TestMethod]
        public void SubtractionCelsiusCelsius()
        {
            var a = new PhysicalValue(56.78, PhysicalUnits.Celsius);
            var b = new PhysicalValue(23.25, PhysicalUnits.Celsius);

            var result = a - b;

            Assert.AreEqual(PhysicalUnits.Kelvin, result.Unit); //result must be represent a temperature difference in Kelvin

            Assert.AreEqual(33.53, result.ValueAs(PhysicalUnits.Kelvin), 1E-10); //loose of precision through double datatype
        }

        [TestMethod]
        public void SubtractionKelvinKelvin()
        {
            var a = new PhysicalValue(56.78, PhysicalUnits.Kelvin);
            var b = new PhysicalValue(23.25, PhysicalUnits.Kelvin);

            var result = a - b;

            Assert.AreEqual(PhysicalUnits.Kelvin, result.Unit); //result must be represent a temperature difference in Kelvin

            Assert.AreEqual(33.53, result.ValueAs(PhysicalUnits.Kelvin), 1E-10); //loose of precision through double datatype
        }

        [TestMethod]
        public void SubtractionCelsiusKelvin()
        {
            var a = new PhysicalValue(56.78, PhysicalUnits.Celsius);
            var b = new PhysicalValue(23.25, PhysicalUnits.Kelvin);

            var result = a - b;

            Assert.AreEqual(PhysicalUnits.Celsius, result.Unit); //result must be represent a absolut temperature in Celsius

            Assert.AreEqual(33.53, result.ValueAs(PhysicalUnits.Celsius), 1E-10); //loose of precision through double datatype
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void SubtractionKelvinCelsius()
        {
            var a = new PhysicalValue(303.94, PhysicalUnits.Kelvin);
            var b = new PhysicalValue(23.25, PhysicalUnits.Celsius);

            _ = a - b; //throw ArithmeticException
        }
    }
}
