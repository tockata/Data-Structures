namespace _02_CalcSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class CalculateSequenceWithQueue
    {
        public static void Main()
        {
            int startNumber = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNumber);

            for (int i = 0; i < 50; i++)
            {
                Console.Write(queue.Peek() + " ");
                queue.Enqueue(queue.Peek() + 1);
                queue.Enqueue(queue.Peek() * 2 + 1);
                queue.Enqueue(queue.Dequeue() + 2);
            }
        }
    }
}
