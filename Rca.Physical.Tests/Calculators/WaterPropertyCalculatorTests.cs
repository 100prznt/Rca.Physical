using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.Physical.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.Physical.Calculators.Tests
{
    [TestClass()]
    public class WaterPropertyCalculatorTests
    {
        [TestMethod()]
        public void CalculateDestinyTest()
        {
            var result = WaterPropertyCalculator.GetDestinyByPressureAndTemperature(new(1.013, PhysicalUnits.Bar, ScaleOfMeasurements.Absolute), new(23.258, PhysicalUnits.Celsius));

            //reference values from: https://thermofluidprop.com/en/properties-online/fluid-property-calculator
            var expectedResult = 997.48; //kg/m^3

            Assert.AreEqual(expectedResult, result.ValueAs(PhysicalUnits.KilogramPerCubicMetre), 1E-3);
        }

        [TestMethod()]
        public void CalculateDynamicViscosityTest()
        {
            var result = WaterPropertyCalculator.GetDynamicViscosityByPressureAndTemperature(new(1.013, PhysicalUnits.Bar, ScaleOfMeasurements.Absolute), new(23.258, PhysicalUnits.Celsius));

            //reference values from: https://thermofluidprop.com/en/properties-online/fluid-property-calculator
            var expectedResult = 0.000926516; //Pa s

            Assert.AreEqual(expectedResult, result.ValueAs(PhysicalUnits.PascalSecond), 1E-6);
        }

        [TestMethod()]
        public void CalculateKineticViscosityTest()
        {
            var result = WaterPropertyCalculator.GetKineticViscosityByPressureAndTemperature(new(1.013, PhysicalUnits.Bar, ScaleOfMeasurements.Absolute), new(23.258, PhysicalUnits.Celsius));

            //reference values from: https://thermofluidprop.com/en/properties-online/fluid-property-calculator
            var expectedResult = 9.289E-7; //m^2/2

            Assert.AreEqual(expectedResult, result.ValueAs(PhysicalUnits.SquareMetrePerSecond), 1E-11);
        }
    }
}