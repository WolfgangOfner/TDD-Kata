using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Hashi.Test
{
    public class GameTests
    {
        private readonly Game _testee;

        public GameTests()
        {
            _testee = new Game();
        }

        [Theory]
        [InlineData(1, GameStatus.Won)]
        public void SolveGame_RightSolution_ShouldSetGameStatusToWon(int boardNumber, GameStatus expectedResult)
        {
            _testee.SetupBoard(Helper.GetBoardWithRightSolution(boardNumber));
            var fake = A.Fake<ISolver>();
            A.CallTo(() => fake.SolveGame(_testee)).Returns(expectedResult);

            _testee.SolveGame(fake);

            _testee.GameStatus.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1, GameStatus.Lost)]
        [InlineData(2, GameStatus.Lost)]
        public void SolveGame_WrongSolution_ShouldSetGameStatusToWon(int boardNumber, GameStatus expectedResult)
        {
            _testee.SetupBoard(Helper.GetBoardWithWrongSolution(boardNumber));
            var fake = A.Fake<ISolver>();
            A.CallTo(() => fake.SolveGame(_testee)).Returns(expectedResult);

            _testee.SolveGame(fake);

            _testee.GameStatus.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1)]
        public void CheckRightNumberOfBridgesForEveryIsland_EveryIslandShouldHaveTheRightNumberOfBridges(
            int boardNumber)
        {
            _testee.SetupBoard(Helper.GetBoardWithRightSolution(boardNumber));

            foreach (var item in _testee.Board)
            {
                if (item is Island island)
                {
                    island.Connections.Should().Be(island.NeededConnection);
                }
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void CheckIfBridgesCross_ShouldThrowExceptionIfBridgesCross(int boardNumber)
        {
            _testee.SetupBoard(Helper.GetBoardWithBrokenBridge(boardNumber));

            _testee.GameStatus.Should().Be(GameStatus.Lost);
        }
    }
}