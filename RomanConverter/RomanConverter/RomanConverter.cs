using System.Collections.Generic;

namespace RomanConverter
{
    public class RomanConverter
    {
        private static readonly List<string> romanNumbers =
            new List<string> {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};

        private static readonly List<int> romanValues =
            new List<int> {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};

        public static string ConvertToRomanNumber(int arabicNumber)
        {
            return Calculate(arabicNumber);
        }

        private static string Calculate(int arabicNumber)
        {
            var result = string.Empty;

            while (true)
            {
                if (arabicNumber == 0)
                {
                    return result;
                }

                for (var i = 0; i < romanNumbers.Count; i++)
                {
                    if (arabicNumber >= romanValues[i])
                    {
                        result += romanNumbers[i];
                        arabicNumber -= romanValues[i];

                        break;
                    }
                }
            }
        }
    }
}