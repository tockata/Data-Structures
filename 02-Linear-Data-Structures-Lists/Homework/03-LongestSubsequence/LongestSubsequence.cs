namespace _03_LongestSubsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestSubsequence
    {
        public static void Main()
        {
            List<int> numbers = new List<int>()
                {
                    //0
                    //1, 2, 3
                    4, 4, 5, 5, 5
                    //2, 2, 2, 3, 3, 3
                    //12, 2, 7, 4, 3, 3, 8
                };

            var result = FindLongestSubsequence(numbers);

            Console.WriteLine(string.Join(",", result));
        }

        private static List<int> FindLongestSubsequence(List<int> numbers)
        {
            List<int> result = new List<int>();
            int count = 1;
            int maxCount = 0;
            int maxStartIndex = 0;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxStartIndex = i - count + 1;
                    }

                    count = 1;
                }
            }

            if (count > maxCount)
            {
                maxCount = count;
                maxStartIndex = numbers.Count - count;
            }

            for (int i = 0, j = maxStartIndex; i < maxCount; i++)
            {
                result.Add(numbers[maxStartIndex]);
                maxStartIndex++;
            }

            return result;
        }
    }
}
