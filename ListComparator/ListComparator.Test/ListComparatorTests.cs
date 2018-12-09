using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace ListComparator.Test
{
    public class ListComparatorTests
    {
        [Theory]
        [InlineData(new[] { 1 , 2 ,3}, new[] { 1, 2, 3 }, 3)]
        [InlineData(new[] { 1 , 3}, new[] { 1, 2, 3 }, 2)]
        [InlineData(new int[0], new[] { 1, 2, 3 }, 0)]
        public void Compare_ShouldReturnAmountOfTheValuesFromListOneInListTwo(IEnumerable<int> firstList, IEnumerable<int> secondList, int expectedResult)
        {
            var testee = new ListComparator();

            var result = testee.Compare(firstList, secondList);

            result.Should().Be(expectedResult);
        }
    }
}