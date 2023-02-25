using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterParserTests
    {
        public Dictionary<string, PhysicalValue> TemperatureValues = new()
        {
            { "123,258 °C", new PhysicalValue(123.258, PhysicalUnits.Celsius) },
            { "123,258K", new PhysicalValue(123.258, PhysicalUnits.Kelvin) },
            { "-123,258 °C", new PhysicalValue(-123.258, PhysicalUnits.Celsius) },
            { "-123,258°C", new PhysicalValue(-123.258, PhysicalUnits.Celsius) },
            { "13,258E2°C", new PhysicalValue(1325.8, PhysicalUnits.Celsius) },
            { ",258E2K", new PhysicalValue(25.8, PhysicalUnits.Kelvin) },
            { "-258K", new PhysicalValue(-258, PhysicalUnits.Kelvin) },
            { "-258  K", new PhysicalValue(-258, PhysicalUnits.Kelvin) },
            { "13,258E-2 °C", new PhysicalValue(0.13258, PhysicalUnits.Celsius) },
        };

        [TestMethod]
        public void Temperatures()
        {
            foreach (var testData in TemperatureValues)
            {
                var result = Converter.ParsePhysicalValue(testData.Key, CultureInfo.GetCultureInfo("de-DE"));
                Assert.AreEqual(testData.Value.Value, result.Value, 1E-10);
                Assert.AreEqual(testData.Value.Unit, result.Unit);
            }
        }

        public Dictionary<string, PhysicalValue> PressureValues = new()
        {
            { "123,258 mWS", new PhysicalValue(123.258, PhysicalUnits.MetresOfWaterGauge) },
            { "123,258bar", new PhysicalValue(123.258, PhysicalUnits.Bar) },
            { "-123,258 mbar", new PhysicalValue(-123.258, PhysicalUnits.Millibar) },
            { "-123,258mbar", new PhysicalValue(-123.258, PhysicalUnits.Millibar) },
            { "13,258E2 kPa", new PhysicalValue(1325.8, PhysicalUnits.Kilopascal) },
            { "13,258E-2 kPa", new PhysicalValue(0.13258, PhysicalUnits.Kilopascal) },
            { ",258E2psi", new PhysicalValue(25.8, PhysicalUnits.Psi) },
            { "-258mbar", new PhysicalValue(-258, PhysicalUnits.Millibar) },
            { "-258  bar", new PhysicalValue(-258, PhysicalUnits.Bar) },
            { "13,258E2 bar", new PhysicalValue(1325.8, PhysicalUnits.Bar) },
            { "13,258E2 Pa", new PhysicalValue(1325.8, PhysicalUnits.Pascal) },
            { "13,258E2 psi", new PhysicalValue(1325.8, PhysicalUnits.Psi) },
            { "123,258 m WS", new PhysicalValue(123.258, PhysicalUnits.MetresOfWaterGauge) },
        };

        [TestMethod]
        public void Pressures()
        {
            foreach (var testData in PressureValues)
            {
                var result = Converter.ParsePhysicalValue(testData.Key, CultureInfo.GetCultureInfo("de-DE"));
                Assert.AreEqual(testData.Value.Value, result.Value, 1E-10);
                Assert.AreEqual(testData.Value.Unit, result.Unit);
            }
        }
    }
}
