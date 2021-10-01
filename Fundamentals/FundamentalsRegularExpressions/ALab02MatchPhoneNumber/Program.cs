using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ALab02MatchPhoneNumber
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\+359( |-)2(\1)[0-9]{3}(\1)[0-9]{4}\b";

            var matches = Regex.Matches(input, pattern);
            var items = matches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(String.Join(", ",items));
        }
    }
}
