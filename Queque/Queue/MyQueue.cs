using System;
using System.Collections.Generic;

namespace Queue
{
    public class MyQueue
    {
        private readonly List<object> _queue;

        public MyQueue(object value)
        {
            _queue = new List<object> { value };
        }

        public int Count => _queue.Count;

        public void Enqueue(object value)
        {
            _queue.Add(value);
        }

        public object Peek()
        {
            CheckIfListIsEmpty();

            return _queue[0];
        }

        public object Dequeue()
        {
            CheckIfListIsEmpty();

            var result = _queue[0];
            _queue.RemoveAt(0);

            return result;
        }

        private void CheckIfListIsEmpty()
        {
            if (_queue.Count == 0)
            {
                throw new InvalidOperationException("Can't execute operation on an empty queue!");
            }
        }
    }
}