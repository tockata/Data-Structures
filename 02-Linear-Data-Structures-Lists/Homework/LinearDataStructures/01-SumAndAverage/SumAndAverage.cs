namespace _01_SumAndAverage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (input != string.Empty)
            {
                string[] splittedInput = input.Split(' ');
                List<int> numbers = new List<int>();

                foreach (var numberAsString in splittedInput)
                {
                    numbers.Add(int.Parse(numberAsString));
                }

                Console.WriteLine("Sum: " + numbers.Sum() + "; Average: " + numbers.Average());
            }
            else
            {
                Console.WriteLine("Sum: 0; Average: 0");
            }
        }
    }
}
