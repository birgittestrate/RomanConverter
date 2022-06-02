namespace RomanConverter
{
    public class Converter
    {
        private readonly Roman _roman;

        public Converter()
        {
            _roman = new Roman();
        }

        public string IntToRoman(int intNumber)
        {
            var romanNumber = "";
            foreach (var (key, value) in _roman.Numerals)
            {
                if (intNumber >= key)
                {
                    romanNumber = value + IntToRoman(intNumber - key);
                    break;
                }                 
            }            
            return romanNumber;
        }

        public int RomanToInt(string romanNumber)
        {
            foreach (var (key, value) in _roman.Numerals)          
            {
                if (value.Length == 1)
                {
                    var romanIdx = romanNumber.IndexOf(value, StringComparison.InvariantCulture);
                    if (romanIdx > -1)
                        return RomanToInt(romanNumber.Substring(romanIdx + 1)) +
                               (romanIdx > 0 ? key - RomanToInt(romanNumber.Substring(0, romanIdx)): key);
                }                
            }
            return 0;
        } 
    }
}
