using System;
using FluentAssertions;
using Xunit;

namespace Queue.Test
{
    public class MyQueueTests
    {
        private readonly MyQueue _testee;
        private const string FirstValue = "5";

        public MyQueueTests()
        {
            _testee = new MyQueue(FirstValue);
        }

        [Fact]
        public void Init_ShouldCreateAQueueWithOneElement()
        {
            var testee = new MyQueue("5");

            testee.Count.Should().Be(1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void Enqueue_ShouldIncreaseCountByOnePlusEnteredAmountOfElements(int amountOfElements)
        {
            for (int i = 0; i < amountOfElements; i++)
            {
                _testee.Enqueue(i);
            }

            _testee.Count.Should().Be(amountOfElements + 1);
        }

        [Fact]
        public void Dequeue_ShouldReturnFristElementAndRemoveIt()
        {
            var result = _testee.Dequeue();
            var reducedQueueCount = _testee.Count;

            reducedQueueCount.Should().Be(0);
            result.Should().BeEquivalentTo(FirstValue);
        }

        [Fact]
        public void Dequeue_WhenQueueIsEmpty_ShouldThrowInvalidOperationException()
        {
            _testee.Dequeue();

            _testee.Invoking(_ => _.Dequeue()).Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Peek_ShouldReturnFirstElementButNotRemoveIt()
        {
            var result = _testee.Peek();

            _testee.Count.Should().Be(1);
            result.Should().BeEquivalentTo(FirstValue);
        }

        [Fact]
        public void Peek_WhenQueueIsEmpty_ShouldThrowInvalidOperationException()
        {
            _testee.Dequeue();

            _testee.Invoking(_ => _.Peek()).Should().Throw<InvalidOperationException>();
        }
    }
}
