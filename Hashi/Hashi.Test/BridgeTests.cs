using FluentAssertions;
using Xunit;

namespace Hashi.Test
{
    public class BridgeTests
    {
        [Fact]
        public void InitialBridge_ShouldInitializeABridgeWithCoordinates()
        {
            var testee = new Bridge(1, 2, 3, 4, true, true);

            testee.StartX.Should().Be(1);
            testee.StartY.Should().Be(2);
            testee.EndX.Should().Be(3);
            testee.EndY.Should().Be(4);
            testee.IsSingle.Should().BeTrue();
            testee.IsVertical.Should().BeTrue();
        }
    }
}