using System.Collections.Generic;

namespace PrimeFactors
{
    public class PrimeFactor
    {
        public IEnumerable<int> CalculatePrimeFactors(int number)
        {
            var result = new List<int>();

            for (var i = 2; number > 1; i++)
            {
                if (number % i == 0)
                {
                    var j = 0;

                    while (number % i == 0)
                    {
                        number /= i;
                        j++;
                    }

                    for (var k = 0; k < j; k++)
                    {
                        result.Add(i);
                    }
                }
            }

            return result;
        }
    }
}