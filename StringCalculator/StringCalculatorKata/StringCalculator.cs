using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var splitInput = numbers.Split(new[] {",", "\n"}, StringSplitOptions.None);

            return splitInput[0].Equals("") ? 0 : splitInput.Sum(Convert.ToInt32);
        }
    }
}