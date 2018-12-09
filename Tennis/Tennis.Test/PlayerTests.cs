using FluentAssertions;
using Xunit;

namespace Tennis.Test
{
    public class PlayerTests
    {
        private readonly Player _testee;

        public PlayerTests()
        {
            _testee = new Player();
        }

        [Fact]
        public void WinPoint_ShouldIncrementPlayerScoreByOne()
        {
            _testee.WinPoint();

            _testee.Score.Should().Be(1);
        }
    }
}