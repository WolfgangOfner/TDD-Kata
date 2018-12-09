using System;
using FluentAssertions;
using Xunit;

namespace RecentlyUsedList.Test
{
    public class RecentlyUsedListTests
    {
        private readonly RecentlyUsedList _testee;
        private const int MaximumNumbersInList = 10;
        private const int EnteredNumber = 123456;

        public RecentlyUsedListTests()
        {

            _testee = new RecentlyUsedList(MaximumNumbersInList);
        }

        [Fact]
        public void Init_ShouldHaveCountOfZero()
        {
            _testee.Count.Should().Be(0);
        }

        [Fact]
        public void Add_AddsAValue_ShouldIncrementTheCount()
        {
            _testee.Add(EnteredNumber);
            
            _testee.Count.Should().Be(1);
        }

        [Fact]
        public void Add_EnterDuplicate_ShouldNotEnterTheDuplicateValue()
        {
            _testee.Add(EnteredNumber);
            _testee.Add(EnteredNumber);

            _testee.Count.Should().Be(1);
        }

        [Fact]
        public void Add_EnterDuplicate_ShouldPutDuplicateToIndexZero()
        {
            _testee.Add(EnteredNumber);
            _testee.Add(111);
            _testee.Add(EnteredNumber);

            var result = _testee.LookUp(0);

            result.Should().Be(EnteredNumber);
        }

        [Fact]
        public void Add_MaximumAmountOfNumbersReached_ShouldNotChangeTheCount()
        {
            FillList();

            var countBeforeChange = _testee.Count;

            _testee.Add(EnteredNumber);

            countBeforeChange.Should().Be(_testee.Count);
        }

        [Fact]
        public void Add_MaximumAmountOfNumbersReached_ShouldRemoveElementAtLastIndex()
        {
            FillList();

            var oldLastElement = _testee.LookUp(MaximumNumbersInList - 1);

            _testee.Add(EnteredNumber);

            _testee.LookUp(MaximumNumbersInList - 1).Should().NotBe(oldLastElement);
        }

        [Fact]
        public void LookUp_ShouldReturnNumberAtEnteredIndex()
        {
            _testee.Add(00000);
            _testee.Add(EnteredNumber);

            var result = _testee.LookUp(0);

            result.Should().Be(EnteredNumber);
        }

        [Theory]
        [InlineData(MaximumNumbersInList)]
        [InlineData(-3)]
        public void LookUp_IndexOutOfRange_ShouldThrowIndexOutOfRangeException(int index)
        {
            _testee.Invoking(_ => _.LookUp(index)).Should().Throw<ArgumentOutOfRangeException>();
        }

        private void FillList()
        {
            for (int i = 0; i < 10; i++)
            {
                _testee.Add(i);
            }
        }
    }
}