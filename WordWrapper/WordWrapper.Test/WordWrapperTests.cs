using FluentAssertions;
using Xunit;

namespace WordWrapper.Test
{
    public class WordWrapperTests
    {
        [Theory]
        [InlineData("", 3, "")]
        [InlineData("HelloWorld", 3, "Hel\nloW\norl\nd")]
        [InlineData("Hello World", 5, "Hello\nWorld")]
        [InlineData("word word", 5, "word\nword")]
        [InlineData("word word", 4, "word\nword")]
        [InlineData("HelloWorld", 1, "H\ne\nl\nl\no\nW\no\nr\nl\nd")]
        public void Wrap_ShouldReturnStringWithLineBreaks(string input, int columnLength, string expectedResult)
        {
            var result = WordWrapper.Wrap(input, columnLength);

            result.Should().Be(expectedResult);
        }
    }
}