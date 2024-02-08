using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rca.Physical.Utils;

namespace Rca.Physical.Tests.Utils
{
    [TestClass]
    public class DoubleExtensionsTests
    {
        [TestMethod]
        public void Test1()
        {
            var testValue = 412.49999999999994;

            var result = testValue.GetBitwiseRoundedValue();
        }

    }
}
