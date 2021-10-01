using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            FillInDictionary(dict, Console.ReadLine());
            CheckDictionary(dict, Console.ReadLine());
            LastCommand(dict, Console.ReadLine());
        }

        private static void LastCommand(Dictionary<string, List<string>> dict, string v)
        {
            if (v== "List")
            {
                dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var item in dict)
                {
                    Console.Write(item.Key+" ");
                }
            }
        }

        private static void CheckDictionary(Dictionary<string, List<string>> dict, string v)
        {
            var input = v.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (dict.ContainsKey(input[i]))
                {
                    Console.WriteLine(input[i] + ":");
                    List<string> ordered = dict[input[i]].OrderByDescending(x => x.Length).ToList();
                    foreach (var item in ordered)
                    {
                        Console.WriteLine($" -{item}");
                    }
                }
            }
        }
        private static Dictionary<string, List<string>> FillInDictionary(Dictionary<string, List<string>> dict, string input)
            {
                var wordDescription = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < wordDescription.Length; i++)
                {
                    var wordPlusDesc = wordDescription[i].Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var word = wordPlusDesc[0];
                    var desc = wordPlusDesc[1];
                    if (dict.ContainsKey(word))
                    {
                        //word is already in the Dictionary, add desc in the list value
                        dict[word].Add(desc);
                    }
                    else
                    {
                        //new word for key and new list of descriptions
                        dict.Add(word, new List<string> { desc });
                    }
                }
                return dict;
            }
        }
}
