namespace RomanConverter
{
    public class Converter
    {
        private readonly Dictionary<int, string> _numerals = new()
        {
            { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" },
            { 100, "C" }, { 90, "XC" }, { 50, "L" }, { 40, "XL" },
            { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" }
        };
        
        public string IntToRoman(int intNumber)
        {
            var romanNumber = "";
            foreach (var (key, value) in _numerals)
            {
                if (intNumber < key) continue;
                romanNumber = value + IntToRoman(intNumber - key);
                break;
            }            
            return romanNumber;
        }

        public int RomanToInt(string romanNumber)
        {
            foreach (var (key, value) in _numerals)
            {
                if (value.Length != 1) continue;
                var romanIdx = romanNumber.IndexOf(value, StringComparison.InvariantCulture);
                if (romanIdx > -1)
                    return RomanToInt(romanNumber[(romanIdx + 1)..]) +
                           (romanIdx > 0 ? key - RomanToInt(romanNumber[..romanIdx]): key);
            }
            return 0;
        } 
    }
}
