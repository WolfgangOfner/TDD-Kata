using FluentAssertions;
using Xunit;

namespace TicTacToe.Test
{
    public class TicTacToeTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void SolveGame_PlayerWinsInRow_ShouldReturnPlayerNumber(int winner, int expectedResult)
        {
            var testee = new TicTacToe();

            var board = new[,]
            {
                {winner, winner, winner},
                {1, 1, 2},
                {2, 0, 0}
            };

            var result = testee.SolveGame(board);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void SolveGame_PlayerWinsInColumn_ShouldReturnPlayerNumber(int winner, int expectedResult)
        {
            var testee = new TicTacToe();

            var board = new[,]
            {
                {winner, 2, 1},
                {winner, 1, 0},
                {winner, 0, 0}
            };

            var result = testee.SolveGame(board);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        public void SolveGame_PlayerWinsInDiagonal_ShouldReturnPlayerNumber(int winner, int expectedResult)
        {
            var testee = new TicTacToe();

            var board = new[,]
            {
                {1, 2, 2},
                {2, winner, 0},
                {2, 0, 1}
            };

            var result = testee.SolveGame(board);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void SolveGame_GameInProgress_ShouldReturnMinusOne()
        {
            var testee = new TicTacToe();

            var board = new[,]
            {
                {0, 2, 1},
                {0, 1, 0},
                {2, 0, 0}
            };

            var result = testee.SolveGame(board);

            result.Should().Be(-1);
        }

        [Fact]
        public void SolveGame_GameIsTied_ShouldReturn0()
        {
            var testee = new TicTacToe();

            var board = new[,]
            {
                {1, 2, 1},
                {2, 1, 2},
                {2, 1, 2}
            };

            var result = testee.SolveGame(board);

            result.Should().Be(0);
        }
    }
}