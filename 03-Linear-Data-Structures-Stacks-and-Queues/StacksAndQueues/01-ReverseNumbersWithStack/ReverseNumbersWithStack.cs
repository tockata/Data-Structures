namespace _01_ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;

    public class ReverseNumbersWithStack
    {
        public static void Main()
        {
            Console.Write("How many numbers do you want to enter: ");
            int count = int.Parse(Console.ReadLine());

            if (count != 0)
            {
                Stack<int> numbers = new Stack<int>();
                for (int i = 0; i < count; i++)
                {
                    numbers.Push(int.Parse(Console.ReadLine()));
                }

                for (int i = 0; i < count; i++)
                {
                    Console.Write(numbers.Pop() + " ");
                }
            }
        }
    }
}
