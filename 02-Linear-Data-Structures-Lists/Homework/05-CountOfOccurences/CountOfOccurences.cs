namespace _05_CountOfOccurences
{
    using System;
    using System.Linq;

    public class CountOfOccurences
    {
        public static void Main()
        {
            //int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            //int[] numbers = { 1000 };
            //int[] numbers = { 0, 0, 0 };
            int[] numbers = { 7, 6, 5, 5, 6 };
            Array.Sort(numbers);

            var occurrences = numbers.GroupBy(n => n);

            foreach (var occurrence in occurrences)
            {
                Console.WriteLine(occurrence.Key + " -> " + occurrence.Count() + " times.");
            }
        }
    }
}
