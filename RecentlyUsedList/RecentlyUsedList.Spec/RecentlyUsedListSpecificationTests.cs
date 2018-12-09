using FluentAssertions;
using Xbehave;

namespace RecentlyUsedList.Spec
{
   public class RecentlyUsedListSpecificationTests
    {
        private int _firstElement;
        private int _secondElement;
        private int _thirdElement;
        private int _fourthElement;

        [Background]
        public void Backround()
        {
            _firstElement = 123;
            _secondElement = 456;
            _thirdElement = 789;
            _fourthElement = 1234;
        }

        [Scenario]
        public void UseTheRecentlyUsedList(RecentlyUsedList testee, int maximumElements)
        {
            "Given the maximum amount of elements is 3"
                .x(() => maximumElements = 3);

            ("An an initialized list with a maximum amount of " + maximumElements + " elements")
                .x(() => testee = new RecentlyUsedList(maximumElements));

            ("When add " + _firstElement)
                .x(() => testee.Add(_firstElement));

            ("And I add " + _secondElement)
                .x(() => testee.Add(_secondElement));

            "Then the count should be 2"
                .x(() => testee.Count.Should().Be(2));

(            "And the element at index 0 should have the value " + _secondElement)
                .x(() => testee.LookUp(0).Should().Be(_secondElement));

            ("When add " + _firstElement)
                .x(() => testee.Add(_firstElement));

            "Then the count should remain 2"
                .x(() => testee.Count.Should().Be(2));

            ("And the index 0 should have the value " + _firstElement)
                .x(() => testee.LookUp(0).Should().Be(_firstElement));

            ("When add " + _thirdElement)
                .x(() => testee.Add(_thirdElement));

            ("And I add " + _fourthElement)
                .x(() => testee.Add(_fourthElement));

            ("Then the count should be " + maximumElements)
                .x(() => testee.Count.Should().Be(maximumElements));
        }
    }
}
