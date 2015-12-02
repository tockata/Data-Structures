namespace _03_Phonebook
{
    using System;
    using System.Linq;

    using Dictionary;

    public class Phonebook
    {
        public static void Main()
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "search")
            {
                string[] contactAndNumber = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.Trim())
                    .ToArray();
                if (!phoneBook.ContainsKey(contactAndNumber[0]))
                {
                    phoneBook[contactAndNumber[0]] = contactAndNumber[1];
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end")
            {
                if (phoneBook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phoneBook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact '{input}' does not exist.");
                }

                input = Console.ReadLine();
            }
        }
    }
}
