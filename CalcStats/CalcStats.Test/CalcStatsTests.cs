using FluentAssertions;
using Xunit;

namespace CalcStats.Test
{
    public class CalcStatsTests
    {
        private readonly CalcStats _testee;

        public CalcStatsTests()
        {
            _testee = new CalcStats();
        }

        [Theory]
        [InlineData(new [] {1 ,2 ,3 ,4}, 1)]
        [InlineData(new [] {1, 0, -1 ,-2 ,-3 ,-4}, -4)]
        [InlineData(new [] {14}, 14)]
        public void CalculateStats_ShouldSetMinimumValue(int[] numbers, int expectedResult)
        {
            _testee.CalculateStats(numbers);

            _testee.MinimumValue.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4 }, 4)]
        [InlineData(new[] { 1, 0, -1, -2, -3, -4 }, 1)]
        [InlineData(new[] { 14 }, 14)]
        public void CalculateStats_ShouldSetMaximumValue(int[] numbers, int expectedResult)
        {
            _testee.CalculateStats(numbers);

            _testee.MaximumValue.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4 }, 4)]
        [InlineData(new[] { 1, 0, -1, -2, -3, -4 }, 6)]
        [InlineData(new[] { 14 }, 1)]
        public void CalculateStats_ShouldSetNumberOfElements(int[] numbers, int expectedResult)
        {
            _testee.CalculateStats(numbers);

            _testee.NumberOfElements.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4 }, 2.5)]
        [InlineData(new[] { 1, 0, -1, -2, -3, -4 }, -1.5)]
        [InlineData(new[] { 14 }, 14)]
        public void CalculateStats_ShouldSetAverageValue(int[] numbers, double expectedResult)
        {
            _testee.CalculateStats(numbers);

            _testee.AverageValue.Should().Be(expectedResult);
        }
    }
}