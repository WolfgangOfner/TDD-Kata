using System;
using FluentAssertions;
using Xunit;

namespace StringCalculatorKata.Test
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator _testee;

        public StringCalculatorTests()
        {
            _testee = new StringCalculator();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1, 2, 3, 4, 5, 6", 21)]
        [InlineData("1\n2, 3", 6)]
        public void Add_StringWithValidInputs_ShouldReturnSum(string input, int expectedResult)
        {
            var result = _testee.Add(input);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Add_StringWithCharReturnsInvalidArgumentException()
        {
            Action act = () => _testee.Add("A");

            act.Should().Throw<FormatException>();
        }
    }
}