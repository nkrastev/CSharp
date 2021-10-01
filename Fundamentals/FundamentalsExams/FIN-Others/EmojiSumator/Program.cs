using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiSumator
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            string nameOfEmojiCode = GetEmojiName(Console.ReadLine());
            Regex regex = new Regex(@"([ .,!\?]):([a-z]{4,}):([ .,!\?])");
            MatchCollection matches = regex.Matches(input);
            var totalPower = 0;
            bool haveToDouble = false;
            List<string> emojiFound = new List<string>();
            foreach (Match item in matches)
            {
                totalPower += CalculatePower(item.Groups[2].Value);
                emojiFound.Add(":" + item.Groups[2].Value + ":");
                if (nameOfEmojiCode==item.Groups[2].Value)
                {
                    haveToDouble = true;
                }
            }
            if (haveToDouble)
            {
                totalPower *= 2;
            }
            if (emojiFound.Count>0)
            {
                Console.WriteLine($"Emojis found: {String.Join(", ",emojiFound)}");
            }

            Console.WriteLine($"Total Emoji Power: {totalPower}");
        }

        private static string GetEmojiName(string v)
        {
            var emojiName = string.Empty;
            var numbers = v.Split(":", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                emojiName += ((char)numbers[i]);
            }
            return emojiName;
        }

        private static int CalculatePower(string value)
        {
            var power = 0;
            for (int i = 0; i < value.Length; i++)
            {
                power += value[i];
            }
            return power;
        }
    }
}
