using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanConverter;

namespace RomanConverterTest
{
    [TestClass]
    public class ConverterTest
    {
        public Dictionary<int, string> IntToRomanTestValues = new Dictionary<int, string>()
        {
            { 1999,"MCMXCIX"},
            { 2444,"MMCDXLIV"},
            { 90,"XC"}
        };
        public Dictionary<string, int> RomanToIntTestValues = new Dictionary<string, int>()
        {
            { "MCMXCIX",1999},
            { "MMCDXLIV",2444},            
            { "XC",90}
        };

        [TestMethod]
        public void ValidateIntToRoman()
        {
            try
            {
                foreach (var test in IntToRomanTestValues)
                {
                    Converter convert = new Converter();                    
                    string actualValue = convert.IntToRoman(test.Key);
                    Assert.AreEqual(test.Value, actualValue, "The integer " + test.Key + " was not converted correctly to roman");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + ": " + e.StackTrace);
                throw;
            }           
        }
        
        [TestMethod]
        public void ValidateRomanToInt()
        {
            try
            {
                foreach (var test in RomanToIntTestValues)
                {
                    Converter convert = new Converter();
                    int actualValue = convert.RomanToInt(test.Key);
                    Assert.AreEqual(test.Value, actualValue, "The roman " + test.Key + " was not converted correctly to integer");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + ": " + e.StackTrace);
                throw;
            }                        
        }
    }
}
