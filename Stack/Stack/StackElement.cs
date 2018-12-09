namespace Stack
{
    public class StackElement
    {
        public StackElement(object value)
        {
            Value = value;
        }

        public object Value { get; }

        public StackElement Next { get; set; }

        public void Push(object value)
        {
            if (Next == null)
            {
                Next = new StackElement(value);
            }
            else
            {
                Next.Push(value);
            }
        }
    }
}