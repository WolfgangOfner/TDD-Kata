using FluentAssertions;
using Xunit;

namespace RomanConverter.Test
{
    public class RomanConverterTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(40, "XL")]
        [InlineData(50, "L")]
        [InlineData(60, "LX")]
        [InlineData(90, "XC")]
        [InlineData(99, "XCIX")]
        [InlineData(100, "C")]
        [InlineData(400, "CD")]
        [InlineData(500, "D")]
        [InlineData(900, "CM")]
        [InlineData(999, "CMXCIX")]
        [InlineData(1000, "M")]
        public void ConvertToRomanNumber_WhenArabicNumberIsEntered_ShouldReturnRomanNumber(int arabicNumber, string expectedResult)
        {
            var result = RomanConverter.ConvertToRomanNumber(arabicNumber);

            result.Should().Be(expectedResult);
        }
    }
}