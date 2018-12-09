using System.Collections.Generic;

namespace HumanReadableTime
{
    public class HumanReadableTime
    {
        public string GetReadableTime(int input)
        {
            var result = "invalid";
            var unformatedTime = new List<int>();

            if (IsValidInput(input))
            {
                while (input > 0)
                {
                    unformatedTime.Add(input % 60);
                    input /= 60;
                }

                FillResult(unformatedTime);

                unformatedTime.Reverse();

                result = FormatResult(unformatedTime);
            }

            return result;
        }

        private static bool IsValidInput(int input)
        {
            return input < 360000 && input >= 0;
        }

        private static string FormatResult(IEnumerable<int> unformatedTime)
        {
            var result = string.Empty;

            foreach (var item in unformatedTime)
            {
                result += item.ToString().Length > 1 ? item.ToString() : $"0{item}";
                result += ":";
            }

            return result.Substring(0, result.Length - 1);
        }

        private static void FillResult(ICollection<int> unformatedTime)
        {
            while (unformatedTime.Count < 3)
            {
                unformatedTime.Add(0);
            }
        }
    }
}