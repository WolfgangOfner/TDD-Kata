using System.Collections.Generic;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";

        public IEnumerable<string> PlayFizzBuzz(int rounds)
        {
            var result = new List<string>();
            var output = string.Empty;

            for (var i = 1; i <= rounds; i++)
            {
                output = i % 3 == 0 ? Fizz : string.Empty;
                output += i % 5 == 0 ? Buzz : string.Empty;
                output += output == string.Empty ? i.ToString() : string.Empty;

                result.Add(output);
            }

            return result;
        }
    }
}