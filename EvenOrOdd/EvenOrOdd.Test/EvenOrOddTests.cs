using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace EvenOrOdd.Test
{
    public class EvenOrOddTests
    {
        private const string Odd = "Odd";
        private const string Even = "Even";

        [Theory]
        [InlineData(new []{ 1, 2, 3, 4, 5, 6 }, Odd)]
        [InlineData(new []{ -1, -2, -3, -4, -5, -6, -7 }, Even)]
        [InlineData(new int[0], Even)]
        public void GetIsEvenOrOdd_ShouldReturnStringWithTheResult(IEnumerable<int> numbers, string expectedResult)
        {
            var testee = new EvenOrOdd();
            
            var result = testee.GetIsEvenOrOdd(numbers);

            result.Should().Be(expectedResult);
        }
    }
}