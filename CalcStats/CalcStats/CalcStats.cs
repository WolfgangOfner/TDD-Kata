using System.Linq;

namespace CalcStats
{
    public class CalcStats
    {
        public int MinimumValue { get; private set; }

        public int MaximumValue { get; private set; }

        public int NumberOfElements { get; private set; }

        public double AverageValue { get; private set; }

        public void CalculateStats(int[] numbers)
        {
            MinimumValue = numbers.Min();
            MaximumValue = numbers.Max();
            NumberOfElements = numbers.Length;
            AverageValue = numbers.Average();
        }
    }
}