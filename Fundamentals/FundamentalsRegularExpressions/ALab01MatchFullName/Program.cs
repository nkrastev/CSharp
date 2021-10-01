using System;
using System.Text.RegularExpressions;

namespace ALab01MatchFullName
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            foreach (Match item in matches)
            {
                Console.Write(item.Value+" ");
            }
        }
    }
}
