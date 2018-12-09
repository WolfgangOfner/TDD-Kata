using System.Collections.Generic;

namespace BingoBongo
{
    public class BingoBongo
    {
        public IEnumerable<string> PlayGame(int endNumber)
        {
            var listOfNumbers = new List<string>();

            for (int i = 1; i <= endNumber; i++)
            {
                string result = i % 3 == 0 ? "Bingo" : string.Empty;
                result += i % 5 == 0 ? "Bongo" : string.Empty;
                result += i % 7 == 0 ? "Conga" : string.Empty;

                listOfNumbers.Add(result.Equals(string.Empty) ? i.ToString() : result);
            }

            return listOfNumbers;
        }
    }
}