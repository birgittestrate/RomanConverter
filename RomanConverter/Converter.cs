namespace RomanConverter
{
    public class Converter
    {
        private readonly Dictionary<int, string> _integerToRomanDictionary = new()
        {
            { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" },
            { 100, "C" }, { 90, "XC" }, { 50, "L" }, { 40, "XL" },
            { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" }
        };

        private readonly List<char> _validChars = new() { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

        public string IntegerToRoman(int intNumber)
        {
            var romanNumber = "";
            foreach (var (key, value) in _integerToRomanDictionary)
            {
                if (intNumber < key)
                {
                    continue;
                }
                romanNumber = value + IntegerToRoman(intNumber - key);
                break;
            }
            return romanNumber;
        }

        public int RomanToInteger(string romanNumber)
        {
            var invalidChars = romanNumber.ToCharArray().Count(ch => !_validChars.Contains(ch));

            if (invalidChars > 0)
            {
                throw new ArgumentException("Roman number is invalid: " + romanNumber);
            }

            foreach (var (key, value) in _integerToRomanDictionary)
            {
                if (value.Length != 1)
                {
                    continue;
                }
                var romanIdx = romanNumber.IndexOf(value, StringComparison.InvariantCulture);
                if (romanIdx >= 0)
                {
                    return RomanToInteger(romanNumber[(romanIdx + 1)..]) +
                           (romanIdx > 0 ? key - RomanToInteger(romanNumber[..romanIdx]) : key);
                }
            }
            return 0;
        } 
    }
}
