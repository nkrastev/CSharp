using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Deciphering
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var keys = Console.ReadLine();
            Regex validator = new Regex(@"([d-z{}#|]+)");
            MatchCollection matches = validator.Matches(input);
            var isInputValid = false;
            foreach (Match item in matches)
            {
                if (item.Value==input)
                {
                    isInputValid = true;
                }
            }

            if (!isInputValid)
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
            else
            {
                var decoded=DecodeInput(input);
                var stringsForReplacement = keys.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var firstString = stringsForReplacement[0];
                var secondString = stringsForReplacement[1];

                var result = decoded.Replace(firstString, secondString);
                Console.WriteLine(result);
            }
        }

        private static string DecodeInput(string input)
        {
            var decoded = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                decoded += (char)(input[i] - 3);
            }

            return decoded;
        }
    }
}
