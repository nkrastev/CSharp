using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace EmojiDetector
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<string> emojiList = new List<string>();

            ExtractEmojies(input, emojiList);

            BigInteger textCoolness = ExtractNumbers(input);

            //output
            Console.WriteLine($"Cool threshold: {textCoolness}");
            if (emojiList.Count > 0)
            {
                Console.WriteLine($"{emojiList.Count} emojis found in the text. The cool ones are:");
                CalculateEmojiCoolness(emojiList, textCoolness);
            }
        }

        private static void CalculateEmojiCoolness(List<string> emojiList, BigInteger textCoolness)
        {
            foreach (var item in emojiList)
            {
                int sum = 0;
                for (int i = 2; i < item.Length - 2; i++)
                {
                    sum += item[i];
                }
                if (sum > textCoolness)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static BigInteger ExtractNumbers(string input)
        {
            BigInteger total = 1;
            Regex regex = new Regex(@"[0-9]");
            MatchCollection matches = regex.Matches(input);
            foreach (Match item in matches)
            {
                total *= int.Parse(item.Value);
            }

            return total;
        }

        private static List<string> ExtractEmojies(string input, List<string> emojiList)
        {
            Regex regex = new Regex(@"(\*|:){2}([A-Z][a-z]{2,})(\1){2}");
            MatchCollection matches = regex.Matches(input);
            foreach (Match item in matches)
            {
                emojiList.Add(item.Value);
            }
            return emojiList;
        }
    }
}
