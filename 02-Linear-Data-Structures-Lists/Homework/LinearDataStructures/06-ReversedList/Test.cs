namespace _06_ReversedList
{
    using System;

    public class Test
    {
        public static void Main()
        {
            ReversedList<int> numbers = new ReversedList<int>();

            for (int i = 0; i < 20; i++)
            {
                numbers.Add(i);
                Console.Write("Capacity: " + numbers.Capacity + ", Count: " + numbers.Count);
                Console.WriteLine();
            }

            PrintReversedList(numbers);

            numbers.Remove(3);
            numbers.Remove(10);
            numbers.Remove(16);

            PrintReversedList(numbers);

            Console.WriteLine(numbers[5]);
            numbers[5] = 999;
            Console.WriteLine(numbers[5]);

            ReversedList<int> test = new ReversedList<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);

            PrintReversedList(test);
            test.Remove(3);
            PrintReversedList(test);
        }

        private static void PrintReversedList(ReversedList<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
