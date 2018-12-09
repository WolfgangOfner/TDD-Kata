using System;

namespace Stack
{
    public class MyStack
    {
        public MyStack(object value)
        {
            Root = new StackElement(value);
            Count++;
        }

        public StackElement Root { get; private set; }

        public int Count { get; private set; }

        public void Push(object value)
        {
            Root.Push(value);
            Count++;
        }

        public StackElement Peek()
        {
            if (Root == null)
            {
                throw new InvalidOperationException("Root element must not be null");
            }

            var peekedElement = Root;

            for (var i = 0; i < Count - 1; i++)
            {
                peekedElement = peekedElement.Next;
            }

            return peekedElement;
        }

        public StackElement Pop()
        {
            object value = null;

            if (Root == null)
            {
                throw new InvalidOperationException("Root element must not be null");
            }

            if (Root.Next == null)
            {
                value = Root.Value;
                Root = null;
            }
            else
            {
                var root = Root;

                for (var i = 1; i < Count - 1; i++)
                {
                    root = root.Next;

                    if (i == Count - 2)
                    {
                        value = root.Next.Value;
                        root.Next = null;
                    }
                }
            }

            Count--;

            return new StackElement(value);
        }
    }
}