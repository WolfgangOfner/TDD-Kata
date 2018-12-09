using FluentAssertions;
using Xunit;

namespace Tennis.Test
{
    public class StandingsCalculatorTests
    {
        private const string Love = "love";
        private const string Fifteen = "fifteen";
        private const string Thirty = "thirty";
        private const string Fourty = "fourty";
        private const string Deuce = "deuce";
        private const string AdvantagePlayerA = "advantage PlayerA";
        private const string AdvantagePlayerB = "advantage PlayerB";
        private const string PlayerAWon = "PlayerA won";
        private const string PlayerBWon = "PlayerB won";

        [Theory]
        [InlineData(0, 0, Love + ":" + Love)]
        [InlineData(1, 0, Fifteen + ":" + Love)]
        [InlineData(2, 1, Thirty + ":" + Fifteen)]
        [InlineData(3, 2, Fourty + ":" + Thirty)]
        [InlineData(3, 3, Deuce)]
        [InlineData(4, 3, AdvantagePlayerA)]
        [InlineData(4, 5, AdvantagePlayerB)]
        [InlineData(4, 6, PlayerBWon)]
        [InlineData(4, 2, PlayerAWon)]
        public void Calculate_ShouldReturnTheScoreOfTheGameAsString(int scorePlayerA, int scorePlayerB, string expectedResult)
        {
            var testee = new StandingsCalculator();

            var result = testee.Calculate(scorePlayerA, scorePlayerB);

            result.Should().Be(expectedResult);
        }
    }
}