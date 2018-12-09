using FluentAssertions;
using Xunit;

namespace BingoBongo.Test
{
    public class BingoBongoTests
    {
        private const string Bingo = "Bingo";
        private const string Bongo = "Bongo";
        private const string Conga = "Conga";
        private readonly BingoBongo _testee;

        public BingoBongoTests()
        {
            _testee = new BingoBongo();
        }

        [Theory]
        [InlineData(100)]
        public void PlayGame_ReturnsListOfStringsWith100Elements(int numberOfRounds)
        {
            var result = _testee.PlayGame(numberOfRounds);

            result.Should().HaveCount(numberOfRounds);
        }

        [Theory]
        [InlineData(2, Bingo)]
        [InlineData(98, Bingo)]
        [InlineData(4, Bongo)]
        [InlineData(99, Bongo)]
        [InlineData(14, Bingo + Bongo)]
        [InlineData(89, Bingo + Bongo)]
        [InlineData(104, Bingo + Bongo + Conga)]
        public void PlayGame_ReturnsDividableBy3AsBingo(int index, string expectedResult)
        {
            var result = _testee.PlayGame(120);

            result.Should().HaveElementAt(index, expectedResult);
        }
    }
}