using FluentAssertions;
using Xunit;

namespace Stack.Test
{
    public class StackElementTests
    {
        [Fact]
        public void Value_ShouldSetAValueToTheStackElement()
        {
            var testee = new StackElement(5);

            testee.Value.Should().Be(5);
        }
    }
}