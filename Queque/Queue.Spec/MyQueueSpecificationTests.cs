using System.Collections.Generic;
using FluentAssertions;
using Xbehave;
using Xunit;

namespace Queue.Spec
{
    public class MyQueueSpecificationTests
    {
        private MyQueue _queue;

        [Scenario]
        [InlineData("42")]
        public void Test(object elemntToCheck)
        {
            object peekedElement = null;
            object dequeuedElement = null;

            "Given a new queue with one element"
                .x(() => _queue = new MyQueue(elemntToCheck));

            "When I add one element"
                .x(() => _queue.Enqueue(2));

            "Then there should be two elements in the queue"
                .x(() => _queue.Count.Should().Be(2));

            "When I add another element"
                .x(() => _queue.Enqueue(new List<string>()));

            "And another element"
                .x(() => _queue.Enqueue("next element"));

            "Then there should be four elements in the queue"
                .x(() => _queue.Count.Should().Be(4));

            "When I peek an element"
                .x(() => peekedElement = _queue.Peek());

            "Then there should be still four elements in the queue"
                .x(() => _queue.Count.Should().Be(4));

            ("And the peeked element is " + elemntToCheck)
                .x(() => peekedElement.Should().Be(elemntToCheck));

            "When I dequeue an element"
                .x(() => dequeuedElement = _queue.Dequeue());

            "Then there should be three elements in the queue"
                .x(() => _queue.Count.Should().Be(3));

            ("And the dequeued element is " + elemntToCheck)
                .x(() => dequeuedElement.Should().Be(elemntToCheck));
        }
    }
}