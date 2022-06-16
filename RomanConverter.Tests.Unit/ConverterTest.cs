using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanConverter.Tests.Unit
{
    [TestClass]
    public class ConverterTest
    {
        [DataRow(1999, "MCMXCIX")]
        [DataRow(2444, "MMCDXLIV")]
        [DataRow(90, "XC")]
        [DataRow(0, "")]
        [DataRow(-1, "")]

        [DataTestMethod]
        public void TestIntegerToRoman(int inputInteger, string expectedRoman)
        {
            //Arrange
            var convert = new Converter();
            //Act
            string actualRoman = convert.IntegerToRoman(inputInteger);
            //Assert
            Assert.AreEqual(expectedRoman, actualRoman);
        }
        
        [DataRow("MCMXCIX", 1999)]
        [DataRow("MMCDXLIV", 2444)]
        [DataRow("XC", 90)]
        [DataRow("", 0)]

        [DataTestMethod]
        public void TestRomanToInteger_ValidValues(string inputRoman, int expectedInteger)
        {
            //Arrange
            var convert = new Converter();
            //Act
            var actualInteger = convert.RomanToInteger(inputRoman);
            //Assert
            Assert.AreEqual(expectedInteger, actualInteger);
        }

        [DataRow("AMCDXLIV")]
        [DataRow("MCM CIX")]

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRomanToInteger_InValidValues(string inputRoman)
        {
            //arrange
            var convert = new Converter();
            //Act
            _= convert.RomanToInteger(inputRoman);
        }
    }
}
