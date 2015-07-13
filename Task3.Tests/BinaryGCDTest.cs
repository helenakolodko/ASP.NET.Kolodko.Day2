using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task3.Library;

namespace Task3.Tests
{
    [TestClass]
    public class BinaryGCDTest
    {
        [TestMethod]
        public void BinaryGCD_ofTwoRelativelyPrimeNumbers_ReturnsOne()
        {
            Assert.AreEqual(1, Calculator.BinaryGCD(6, 35));
        }

        [TestMethod]
        public void BinaryGCD_ofTwoEqualNumbers_ReturnsThisNumber()
        {
            Assert.AreEqual(35, Calculator.BinaryGCD(35, 35));
        }

        [TestMethod]
        public void BinaryGCD_ofFiveEqualNumbers_ReturnsThisNumber()
        {
            Assert.AreEqual(35, Calculator.BinaryGCD(35, 35, 35, 35, 35));
        }

        [TestMethod]
        public void BinaryGCD_ofThreeNonRelativelyPrimeNumbers_ReturnsTheirGCD()
        {
            Assert.AreEqual(3, Calculator.BinaryGCD(6, 36, 15));
        }

        [TestMethod]
        public void BinaryGCD_ofFiveNonRelativelyPrimeNumbers_ReturnsTheirGCD()
        {
            Assert.AreEqual(3, Calculator.BinaryGCD(6, 36, 15, 18, 135));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinaryGCD_ofTwoNegativeNumbers_ThrowsException()
        {
            Calculator.BinaryGCD(-6, -36);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinaryGCD_ofOneNumber_ThrowsException()
        {
            Calculator.BinaryGCD(6);
        }
    }
}
