namespace _02_SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortWords
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (input != string.Empty)
            {
                List<string> words = input.Split().ToList();
                words.Sort();

                foreach (var word in words)
                {
                    Console.Write(word + " ");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The input is empty! Try again!");
            }
        }
    }
}
