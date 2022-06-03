using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanConverter.Tests.Unit
{
    [TestClass]
    public class ConverterTest
    {
        public Dictionary<int, string> IntToRomanTestValues = new()
        {
            { 1999,"MCMXCIX"},
            { 2444,"MMCDXLIV"},
            { 90,"XC"}
        };
        public Dictionary<string, int> RomanToIntTestValues = new()
        {
            { "MCMXCIX",1999},
            { "MMCDXLIV",2444},            
            { "XC",90}
        };

        [TestMethod]
        public void TestIntToRoman()
        {
            foreach (var (key, value) in IntToRomanTestValues)
            {
                //Arrange
                var convert = new Converter();
                //Act
                var actualValue = convert.IntToRoman(key);
                //Assert
                Assert.AreEqual(value, actualValue, "The integer " + key + " was not converted correctly to roman");
            }
        }
        
        [TestMethod]
        public void TestRomanToInt()
        {
            foreach (var (key, value) in RomanToIntTestValues)
            {
                //Arrange
                var convert = new Converter();
                //Act
                var actualValue = convert.RomanToInt(key);
                //Assert
                Assert.AreEqual(value, actualValue, "The roman " + key + " was not converted correctly to integer");
            }
        }
    }
}
