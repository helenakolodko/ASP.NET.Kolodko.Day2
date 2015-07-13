using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Library;

namespace Task3.Tests
{
    [TestClass]
    public class HexademicalFormatterTest
    {
        [TestMethod]
        public void Format_PositiveNumberWithNoFormatString_ReturnsHexademical()
        {
            int number = 15;
            string result = string.Format(new HexademicalFormatter(), "{0}", number);
            Assert.AreEqual(number.ToString("X"), result);
        }

        [TestMethod]
        public void Format_NegativeNumberWithNoFormatString_ReturnsHexademical()
        {
            int number = -15;
            string result = string.Format(new HexademicalFormatter(), "{0}", number);
            Assert.AreEqual(number.ToString("X"), result);
        }

        [TestMethod]
        public void Format_NumberWithXFormatString_ReturnsHexademical()
        {
            int number = 15;
            string result = string.Format(new HexademicalFormatter(), "{0:X}", number);
            Assert.AreEqual(number.ToString("X"), result);
        }
    }
}
