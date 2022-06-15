using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanConverter.Tests.Unit
{
    [TestClass]
    public class ConverterTest
    {
        [DataRow(1999, "MCMXCIX")]
        [DataRow(2444, "MMCDXLIV")]
        [DataRow(90, "XC")]

        [DataTestMethod]
        public void TestIntegerToRoman(int inputInteger, string expectedRoman)
        {
            //Arrange
            var convert = new Converter();
            //Act
            var actualRoman = convert.IntegerToRoman(inputInteger);
            //Assert
            Assert.AreEqual(expectedRoman, actualRoman, "The integer " + inputInteger + " was not converted correctly to roman");
        }

        [DataRow("MCMXCIX", 1999)]
        [DataRow("MMCDXLIV", 2444)]
        [DataRow("XC", 90)]

        [DataTestMethod]
        public void TestRomanToInteger(string inputRoman, int expectedInteger)
        {
            //Arrange
            var convert = new Converter();
            //Act
            var actualInteger = convert.RomanToInteger(inputRoman);
            //Assert
            Assert.AreEqual(expectedInteger, actualInteger, "The roman " + inputRoman + " was not converted correctly to integer");
        }
    }
}
