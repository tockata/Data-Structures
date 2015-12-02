namespace _02_CountSymbols
{
    using System;
    using System.Linq;
    using Dictionary;

    public class CountSymbols
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<char, int> charactersCount = new Dictionary<char, int>();
            foreach (var character in input)
            {
                if (!charactersCount.ContainsKey(character))
                {
                    charactersCount[character] = 0;
                }

                charactersCount[character]++;
            }

            charactersCount
                .OrderBy(ch => ch.Key)
                .ToList()
                .ForEach(character => Console.WriteLine($"{character.Key}: {character.Value} time/s"));
        }
    }
}
