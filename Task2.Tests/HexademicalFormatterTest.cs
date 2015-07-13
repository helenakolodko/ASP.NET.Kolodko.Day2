using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Library;

namespace Task2.Tests
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

        [TestMethod]
        public void Format_NumberWithCFormatString_ReturnsCurrency()
        {
            int number = 15;
            string result = string.Format(new HexademicalFormatter(), "{0:C}", number);
            Assert.AreEqual(number.ToString("C"), result);
        }

        [TestMethod]
        public void Format_LargePositiveNumberWithNoFormatString_ReturnsHexademical()
        {
            long number = 15564165456;
            string result = string.Format(new HexademicalFormatter(), "{0}", number);
            Assert.AreEqual(number.ToString("X"), result);
        }

        [TestMethod]
        public void Format_LargeNegativeNumberWithNoFormatString_ReturnsHexademical()
        {
            long number = -15564165456;
            string result = string.Format(new HexademicalFormatter(), "{0}", number);
            Assert.AreEqual(number.ToString("X"), result);
        }
    }
}
