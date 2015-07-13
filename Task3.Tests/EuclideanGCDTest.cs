using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3.Library;

namespace Task3.Tests
{
    [TestClass]
    public class EuclideanGCDTest
    {
        [TestMethod]
        public void EuclideanGCD_ofTwoRelativelyPrimeNumbers_ReturnsOne()
        {
            Assert.AreEqual(1, Calculator.EuclideanGCD(6, 35));
        }

        [TestMethod]
        public void EuclideanGCD_ofTwoEqualNumbers_ReturnsThisNumber()
        {
            Assert.AreEqual(35, Calculator.EuclideanGCD(35, 35));
        }

        [TestMethod]
        public void EuclideanGCD_ofFiveEqualNumbers_ReturnsThisNumber()
        {
            Assert.AreEqual(35, Calculator.EuclideanGCD(35, 35, 35, 35, 35));
        }

        [TestMethod]
        public void EuclideanGCD_ofThreeNonRelativelyPrimeNumbers_ReturnsTheirGCD()
        {
            Assert.AreEqual(3, Calculator.EuclideanGCD(6, 36, 15));
        }

        [TestMethod]
        public void EuclideanGCD_ofFiveNonRelativelyPrimeNumbers_ReturnsTheirGCD()
        {
            Assert.AreEqual(3, Calculator.EuclideanGCD(6, 36, 15, 18, 135));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EuclideanGCD_ofTwoNegativeNumbers_ThrowsException()
        {
            Calculator.EuclideanGCD(-6, -36);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EuclideanGCD_ofOneNumber_ThrowsException()
        {
            Calculator.EuclideanGCD(6);
        }
    }
}
