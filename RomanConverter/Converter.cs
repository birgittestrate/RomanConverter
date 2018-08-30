namespace RomanConverter
{
    public class Converter
    {
        public Roman roman;

        public Converter()
        {
            roman = new Roman();
        }

        public string IntToRoman(int intNumber)
        {
            string romanNumber = "";
            foreach (var romanItem in roman.Numerals)
            {
                if (intNumber >= romanItem.Key)
                {
                    romanNumber = romanItem.Value + IntToRoman(intNumber - romanItem.Key);
                    break;
                }                 
            }            
            return romanNumber;
        }

        public int RomanToInt(string romanNumber)
        {
            foreach (var romanItem in roman.Numerals)          
            {
                if (romanItem.Value.Length == 1)
                {
                    int romanIdx = romanNumber.IndexOf(romanItem.Value);
                    if (romanIdx > -1)
                        return RomanToInt(romanNumber.Substring(romanIdx + 1)) +
                               (romanIdx > 0 ? romanItem.Key - RomanToInt(romanNumber.Substring(0, romanIdx)): romanItem.Key);
                }                
            }
            return 0;
        } 
    }
}
