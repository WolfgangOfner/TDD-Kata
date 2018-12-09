using FluentAssertions;
using Xunit;

namespace Bowling.Test
{
    public class GameTests
    {
        private readonly Game _testee;

        public GameTests()
        {
            _testee = new Game();
        }

        [Fact]
        public void Roll_ShouldReturnNumberOfRolledPins()
        {
            _testee.Roll(5);
            _testee.Score.Should().Be(5);
        }

        [Fact]
        public void Roll_20Times_ShouldReturnNumberOfRolledPins()
        {
            FinishGame(20, 3);

            _testee.Score.Should().Be(60);
        }

        [Fact]
        public void Roll_Spare_ShouldReturnNumberOfRolledPinsForSpare()
        {
            _testee.Roll(5);
            _testee.Roll(5);
            _testee.Roll(3);

            FinishGame(17, 0);

            var result = _testee.CalculateScore();

            result.Should().Be(16);
        }

        [Fact]
        public void Roll_Strike_ShouldReturnNumberOfRolledPinsForStrike()
        {
            _testee.Roll(10);
            _testee.Roll(3);
            _testee.Roll(5);

            FinishGame(17, 0);

            var result = _testee.CalculateScore();

            result.Should().Be(26);
        }

        private void FinishGame(int rolls, int value)
        {
            for (int i = 0; i < rolls; i++)
            {
                _testee.Roll(value);
            }
        }
    }
}