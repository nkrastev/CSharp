using System;
using System.Collections.Generic;

namespace ALab03WordSynonyms
{
    class Program
    {
        static void Main()
        {
            int wordsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < wordsCount; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!dict.ContainsKey(word))
                {
                    List<string> synonymList = new List<string>();
                    synonymList.Add(synonym);
                    dict.Add(word, synonymList);
                }
                else
                {
                    dict[word].Add(synonym);
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {String.Join(", ",item.Value)}");
            }
        }
    }
}
