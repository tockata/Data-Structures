namespace _04_RemoveOddOccurences
{
    using System;
    using System.Collections.Generic;

    public class RemoveOddOccurences
    {
        public static void Main()
        {
            List<int> numbers = new List<int>(){ 1, 2, 3, 4, 1 };
            //List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 3, 6, 7, 6, 7, 6 };
            //List<int> numbers = new List<int>() { 1, 2, 1, 2, 1, 2 };
            //List<int> numbers = new List<int>() { 3, 7, 3, 3, 4, 3, 4, 3, 7 };
            //List<int> numbers = new List<int>() { 1, 1 };

            List<int> clearedNumbers = RemoveOddOccurencesOfNumber(numbers);
            Console.WriteLine(string.Join(", ", clearedNumbers));
        }

        private static List<int> RemoveOddOccurencesOfNumber(List<int> numbers)
        {
            List<int> result = numbers;

            for (int i = 0; i < result.Count; i++)
            {
                int currentNumber = result[i];
                var occurrences = result.FindAll(n => n == currentNumber);

                if (occurrences.Count % 2 != 0)
                {
                    result.RemoveAll(n => n == currentNumber);
                    i--;
                }
            }

            return result;
        }
    }
}
