using System;
using System.Text.RegularExpressions;

namespace ALab03MatchDates
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\b([0-9]{2})([-.\/])([A-Z][a-z]{2})(\2)([0-9]{4})\b";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match item in matches)
            {                
                Console.WriteLine($"Day: {item.Groups[1]}, Month: {item.Groups[3]}, Year: {item.Groups[5]}");
            }
        }
    }
}
