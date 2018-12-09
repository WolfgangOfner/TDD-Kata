using System.Collections.Generic;
using System.Linq;

namespace RecentlyUsedList
{
    public class RecentlyUsedList
    {
        private readonly List<int> _numbers;
        private readonly int _maximumNumbersInList;

        public RecentlyUsedList(int maximumNumbersInList = 10)
        {
            _numbers = new List<int>();
            _maximumNumbersInList = maximumNumbersInList;
        }

        public int Count => _numbers.Count;
        
        public void Add(int number)
        {
            if (IsInList(number))
            {
                MoveElementToIndexZero(number);
            }
            else
            {
                _numbers.Insert(0, number);

                RemoveOldestEntryIfListIsFull();
            }
        }

        public int LookUp(int index)
        {
            return _numbers[index];
        }

        private bool IsInList(int number)
        {
            return _numbers.Any(x => x == number);
        }

        private void MoveElementToIndexZero(int number)
        {
            _numbers.Remove(number);
            Add(number);
        }

        private void RemoveOldestEntryIfListIsFull()
        {
            if (Count > _maximumNumbersInList)
            {
                _numbers.RemoveAt(_maximumNumbersInList);
            }
        }
    }
}