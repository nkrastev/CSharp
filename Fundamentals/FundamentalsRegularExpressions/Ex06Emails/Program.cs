using System;
using System.Text.RegularExpressions;

namespace Ex06ExtractEmails
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            
            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-_][A-Za-z]+)+))(\b|(?=\s))";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                Console.WriteLine(item);
            }


        }
    }
}
