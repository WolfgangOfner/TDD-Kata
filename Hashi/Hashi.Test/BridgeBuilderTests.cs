using System;
using FluentAssertions;
using Xunit;

namespace Hashi.Test
{
    public class BridgeBuilderTests
    {
        private readonly BridgeBuilder _testee;

        public BridgeBuilderTests()
        {
            _testee = new BridgeBuilder();
        }

        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 1)]
        public void CreateBridges_ShouldReturnListOfBridges(bool vertical, int expectedResult)
        {
            var game = new Game();
            game.SetupBoard(Helper.GetBoardWithHorizontalOrVerticalBridge(vertical));

            var result = _testee.CreateBridges(game.Board);

            result.Count.Should().Be(expectedResult);
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
        public void CreateBridges_ShouldThrowAnExceptionWhenBridgeCantBeCreated(int boardNumber)
        {
            var game = new Game();
            game.SetupBoard(Helper.GetBoardWithBrokenBridge(boardNumber));

            Action result = () => { _testee.CreateBridges(game.Board); };

            result.Should().Throw<HashiException>();
        }

       
    }
}