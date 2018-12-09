using FluentAssertions;
using Xbehave;
using Xunit;

namespace Bowling.Spec
{
    public class BowlingSpecificationTests
    {
        private Game _game;

        [Background]
        public void Background()
        {
            "Given a game is started"
                .x(() => _game = new Game());
        }

        [Scenario]
        [InlineData(10, 21, 300, "perfect game")]
        [InlineData(5, 21, 150, "spare game")]
        [InlineData(0, 20, 0, "pointless game")]
        public void PlayGame(int pints, int rolls, int expectedResult, string gameDescription)
        {
            ("When a player plays a " + gameDescription)
                .x(() => PlayGame(pints, rolls));

            ("Then the score is " + expectedResult)
                .x(() => _game.CalculateScore().Should().Be(expectedResult));
        }

        private void PlayGame(int pints, int rolls)
        {
            for (var i = 0; i < rolls; i++)
            {
                _game.Roll(pints);
            }
        }
    }
}