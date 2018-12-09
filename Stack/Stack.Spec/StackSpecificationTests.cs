using FluentAssertions;
using Xbehave;

namespace Stack.Spec
{
    public class StackSpecificationTests
    {
        [Scenario]
        public void PushAndPopElements(MyStack stack)
        {
            "When the stack is created"
                .x(() => stack = new MyStack(5));

            "And 3 is pushed on the stack"
                .x(() => stack.Push(3));

            "And 7 is pushed on the stack"
                .x(() => stack.Push(7));

            "And the count of the stack is 3"
                .x(() => stack.Count.Should().Be(3));

            "When a peek is executed"
                .x(() => stack.Peek());

            "Then the count of the stack remains 3"
                .x(() => stack.Count.Should().Be(3));

            "When an element is poped"
                .x(() => stack.Pop());

            "And another element is poped"
                .x(() => stack.Pop());

            "And another element is poped"
                .x(() => stack.Pop());

            "Then the count of the stack is 0"
                .x(() => stack.Count.Should().Be(0));

            "When 9 is pushed on the stack"
                .x(() => stack.Push(9));

            "Then the count of the stack is 1"
                .x(() => stack.Count.Should().Be(1));
        }
    }
}