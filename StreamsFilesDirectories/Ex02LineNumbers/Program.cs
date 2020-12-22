using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Ex02LineNumbers
{
    class Program
    {
        static void Main()
        {
            var text = File.ReadAllLines("text.txt");
            var counter = 1;

            for (int i = 0; i < text.Length; i++)
            {
                //count letters per line
                var letterCount = CountLetters(text[i]);
                //count punct marks
                var punctCount = CountPunctuation(text[i]);
                Console.WriteLine($"Line {counter}: {text[i]} ({letterCount})({punctCount})");
                counter++;
            }
        }

        private static int CountPunctuation(string v)
        {
            var count = 0;
            Regex mark = new Regex(@"[.,!?\-\']");
            for (int i = 0; i < v.Length; i++)
            {
                if (mark.IsMatch(v[i].ToString()))
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountLetters(string v)
        {
            var count = 0;
            for (int i = 0; i < v.Length; i++)
            {
                if (Char.IsLetter(v[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
