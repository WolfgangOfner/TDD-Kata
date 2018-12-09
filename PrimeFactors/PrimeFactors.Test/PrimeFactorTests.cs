using FluentAssertions;
using Xunit;

namespace PrimeFactors.Test
{
    public class PrimeFactorTests
    {
        readonly PrimeFactor _testee;

        public PrimeFactorTests()
        {
            _testee = new PrimeFactor();
        }

        [Theory]
        [InlineData(-100, 0)]
        [InlineData(2, 1)]
        [InlineData(100, 4)]
        public void CalculatePrimeFactors_ShouldReturnArrayWithTheRightAmountOfNumbers(int number, int expectedAmountOfReturnedNumbers)
        {
            var result = _testee.CalculatePrimeFactors(number);

            result.Should().HaveCount(expectedAmountOfReturnedNumbers);
        }

        [Theory]
        [InlineData(-100, new int[0])]
        [InlineData(2, new[] { 2 })]
        [InlineData(100, new[] { 2, 2, 5, 5 })]
        public void CalculatePrimeFactors_ShouldReturnArrayWithTheRightNumbers(int number, int[] expectedArray)
        {
            var result = _testee.CalculatePrimeFactors(number);

            result.Should().BeEquivalentTo(expectedArray);
        }
    }
}