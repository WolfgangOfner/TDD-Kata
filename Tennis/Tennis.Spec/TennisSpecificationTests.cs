using FluentAssertions;
using Xbehave;
using Xunit;

namespace Tennis.Spec
{
    public class TennisSpecificationTests
    {
        private Player _playerA;
        private Player _playerB;
        private Game _game;

        [Background]
        public void Background()
        {
            "Given player A"
                .x(() => _playerA = new Player());

            "and player B"
                .x(() => _playerB = new Player());

            "and a game with these two players"
                .x(() => _game = new Game(new StandingsCalculator(), _playerA, _playerB));
        }

        [Scenario]
        [InlineData("AABB", "thirty:thirty", "AA", "PlayerA won")]
        [InlineData("BB", "love:thirty", "BB", "PlayerB won")]
        [InlineData("AABBAB", "deuce", "BB", "PlayerB won")]
        [InlineData("AABBABA", "advantage PlayerA", "A", "PlayerA won")]
        public void Play_WonPointsAreAABBThenAA_PlayerAWinsTheGame(string firstPoints, string firstResult, string secondPoints, string secondResult)
        {
            ("When a game is played with " + firstPoints)
                .x(() => PlayGame(firstPoints));

            ("Then the score is " + firstResult)
                .x(() => _game.Score.Should().Be(firstResult));

            ("When a game is played with " + secondPoints)
                .x(() => PlayGame(secondPoints));

            ("Then the end result is " + secondResult)
                .x(() => _game.Score.Should().Be(secondResult));
        }

        private void PlayGame(string pointWins)
        {
            foreach (var point in pointWins)
            {
                _game.PlayPoint(point == 'A' ? _playerA : _playerB);
            }
        }
    }
}