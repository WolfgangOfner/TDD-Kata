using FluentAssertions;
using Xunit;

namespace Hashi.Test
{
    public class SolverTests
    {
        private readonly Solver _testee;

        public SolverTests()
        {
            _testee = new Solver();
        }

        [Theory]
        [InlineData(1, GameStatus.Won)]
        [InlineData(2, GameStatus.Won)]
        public void SolveGame_RightSolution_ShouldReturnGameStatusWon(int boardNumber, GameStatus expectedResult)
        {
            var game = new Game();
            game.SetupBoard(Helper.GetBoardWithRightSolution(boardNumber));

            var result = _testee.SolveGame(game);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1, GameStatus.Lost)]
        [InlineData(2, GameStatus.Lost)]
        public void SolveGame_WrongSolution_ShouldReturnGameStatusLost(int boardNumber, GameStatus expectedResult)
        {
            var game = new Game();
            game.SetupBoard(Helper.GetBoardWithWrongSolution(boardNumber));

            var result = _testee.SolveGame(game);

            result.Should().Be(expectedResult);
        }
    }
}