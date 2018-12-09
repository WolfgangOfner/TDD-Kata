using FluentAssertions;
using Xunit;

namespace LeapYear.Test
{
    public class LeapYearTests
    {
        [Theory]
        [InlineData(4, true)]
        [InlineData(100, false)]
        [InlineData(400, true)]
        [InlineData(555, false)]
        [InlineData(556, true)]
        public void IsLeapYear_ShouldReturnBooleanToIndicateWheterEnteredValueIsALeapYear(int year, bool expectedResult)
        {
            var testee = new LeapYear();

            var result = testee.IsLeapYear(year);

            result.Should().Be(expectedResult);
        }
    }
}