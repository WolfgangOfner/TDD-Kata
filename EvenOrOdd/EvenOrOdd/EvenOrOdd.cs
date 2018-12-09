using System.Collections.Generic;
using System.Linq;

namespace EvenOrOdd
{
    public class EvenOrOdd
    {
        public string GetIsEvenOrOdd(IEnumerable<int> numbers)
        {
            return numbers.Sum() % 2 == 0 ? "Even" : "Odd";
        }
    }
}