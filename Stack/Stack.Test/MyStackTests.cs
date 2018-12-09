using System;
using FluentAssertions;
using Xunit;

namespace Stack.Test
{
    public class MyStackTests
    {
        public MyStackTests()
        {
            _testee = new MyStack(RootValue);
        }

        private MyStack _testee;
        private const int RootValue = 5;

        [Theory]
        [InlineData(5)]
        public void Init_ShouldSetCountToOne(int value)
        {
            _testee = new MyStack(value);

            _testee.Root.Value.Should().Be(value);
        }

        [Theory]
        [InlineData(2, 3)]
        public void Push_WithTwoElements_ShouldSetCountToThree(int firstNodeValue, int secondNodeValue)
        {
            _testee.Push(firstNodeValue);
            _testee.Push(secondNodeValue);

            _testee.Count.Should().Be(3);
        }

        [Theory]
        [InlineData(2, 3)]
        public void Peek_ShouldReturnLastElementWithoutRemovingIt(int firstNodeValue, int secondNodeValue)
        {
            _testee.Push(firstNodeValue);
            _testee.Push(secondNodeValue);

            var poppedElement = _testee.Peek();

            poppedElement.Value.Should().Be(secondNodeValue);
            _testee.Count.Should().Be(3);
        }

        [Fact]
        public void Peek_WithOnlyOneElementOnStack_ShouldNotChangeTheCount()
        {
            var result = _testee.Peek();

            result.Value.Should().Be(RootValue);
            _testee.Count.Should().Be(1);
        }

        [Fact]
        public void Peek_OnEmptyStack_ShouldThrowException()
        {
            _testee.Pop();
            _testee.Invoking(_ => _.Peek()).Should().Throw<InvalidOperationException>();
        }

        [Theory]
        [InlineData(2, 3)]
        public void Pop_ShouldReturnLastElementAndRemoveIt(int firstNodeValue, int secondNodeValue)
        {
            _testee.Push(firstNodeValue);
            _testee.Push(secondNodeValue);

            var poppedElement = _testee.Pop();

            poppedElement.Value.Should().Be(secondNodeValue);
            _testee.Count.Should().Be(2);
        }

        [Fact]
        public void Pop_WithOnlyOneElementOnStack_ShouldSetTheCountToZero()
        {
            var poppedElement = _testee.Pop();

            poppedElement.Value.Should().Be(RootValue);
            _testee.Count.Should().Be(0);
        }

        [Fact]
        public void Pop_OnEmptyStack_ShouldThrowException()
        {
            _testee.Pop();
            _testee.Invoking(_ => _.Pop()).Should().Throw<InvalidOperationException>();
        }
    }
}