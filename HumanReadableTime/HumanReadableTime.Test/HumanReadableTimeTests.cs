using FluentAssertions;
using Xunit;

namespace HumanReadableTime.Test
{
    public class HumanReadableTimeTests
    {
        [Theory]
        [InlineData(0, "00:00:00")]
        [InlineData(1, "00:00:01")]
        [InlineData(60, "00:01:00")]
        [InlineData(3599, "00:59:59")]
        [InlineData(3600, "01:00:00")]
        [InlineData(39599, "10:59:59")]
        [InlineData(360000, "invalid")]
        public void GetReadableTime_InputNumber_ShouldReturnFormatedTime(int input, string expectedResult)
        {
            var testee = new HumanReadableTime();
            var result = testee.GetReadableTime(input);

            result.Should().Be(expectedResult);
        }
    }
}