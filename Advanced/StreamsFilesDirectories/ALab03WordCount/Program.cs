using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ALab03WordCount
{
    class Program
    {
        static void Main()
        {            
            var text = File.ReadAllText("text.txt").Split(new char[] { ' ', '-',',','.' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var words = File.ReadAllText("words.txt").Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var wordsCount = ReadWordsAndEnterInDict(words);

            //go throught file and search each word
            for (int i = 0; i < text.Length; i++)
            {
                if (wordsCount.ContainsKey(text[i].ToLower()))
                {
                    wordsCount[text[i].ToLower()]++;
                }                            
            }

            //output
            wordsCount = wordsCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            StringBuilder sb = new StringBuilder();
            foreach (var item in wordsCount)
            {
                var line=($"{item.Key} - {item.Value}");
                Console.WriteLine(line);
                sb.Append(line+"\n");
            }            
            File.WriteAllText("output.txt", sb.ToString());

        }

        private static Dictionary<string, int> ReadWordsAndEnterInDict(string[] words)
        {
            // we assume searched words are unique
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                wordsCount.Add(words[i].ToLower(), 0);
            }
            return wordsCount;
        }
    }
}
