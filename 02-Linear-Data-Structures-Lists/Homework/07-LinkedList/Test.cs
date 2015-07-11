namespace LinkedList
{
    using System;

    public class Test
    {
        public static void Main()
        {
            //Please use the Unit test from 07-TestLinkedList project /provided by ttitto/

            var list = new SinglyLinkedLinkedList<int>();

            //list.Add(4);
            //list.Add(58);
            //list.Add(659816519);
            //list.Add(165965);
            //list.Add(659816519);
            //list.Add(165965);

            list.Add(4);
            list.Add(58);
            list.Add(659816519);
            list.Add(165965);

            list.Remove(0);

            foreach (var number in list)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            Console.WriteLine(list.FirstIndexOf(4));
            //Console.WriteLine(list.Count);
            //Console.WriteLine(list.FirstIndexOf(659816519));
            //Console.WriteLine(list.LastIndexOf(659816519));
            //Console.WriteLine(list.LastIndexOf(165965));
        }
    }
}
