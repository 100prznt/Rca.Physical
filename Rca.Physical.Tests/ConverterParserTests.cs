using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rca.Physical.Tests
{
    [TestClass]
    public class ConverterParserTests
    {
        public Dictionary<string, PhysicalValue> TestValues = new Dictionary<string, PhysicalValue>()
        {
            { "123,258 °C", new PhysicalValue(123.258, PhysicalUnits.Celsius) },
            { "123,258K", new PhysicalValue(123.258, PhysicalUnits.Kelvin) },
            { "-123,258 °C", new PhysicalValue(-123.258, PhysicalUnits.Celsius) },
            { "-123,258°C", new PhysicalValue(-123.258, PhysicalUnits.Celsius) },
            { "13,258E2°C", new PhysicalValue(1325.8, PhysicalUnits.Celsius) },
            { "13,258E2 bar", new PhysicalValue(1325.8, PhysicalUnits.Bar) },
            { "13,258E2 kPa", new PhysicalValue(1325.8, PhysicalUnits.Kilopascal) },
            { "13,258E2 ccm", new PhysicalValue(1325.8, PhysicalUnits.CubicCentimetre) },
            { "123,258 m WS", new PhysicalValue(123.258, PhysicalUnits.MetresOfWaterGauge) },
        };

        [Ignore]
        [TestMethod]
        public void Parse()
        {
            foreach (var testData in TestValues)
            {
                var result = Converter.ParsePhysicalValue(testData.Key);
                Assert.AreEqual(testData.Value.Value, result.Value, 1E-10);
                Assert.AreEqual(testData.Value.Unit, result.Unit);
            }
        }
    }
}
