namespace WordWrapper
{
    public class WordWrapper
    {
        public static string Wrap(string input, int columLength)
        {
            if (input.Length <= columLength)
            {
                return input;
            }

            if (input[columLength - 1] == ' ')
            {
                return input.Substring(0, columLength - 1) + "\n" + Wrap(input.Substring(columLength), columLength);
            }

            return input.Substring(0, columLength) + "\n" + Wrap(input.Substring(columLength).TrimStart(), columLength);
        }
    }
}