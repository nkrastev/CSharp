using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DestinationMapper
{
    class Program
    {
        static void Main()
        {
            Regex regex = new Regex(@"(=|\/)([A-Z][A-Za-z]{2,})(\1)");
            MatchCollection matches = regex.Matches(Console.ReadLine());
            List<string> destinations = new List<string>();
            var travelPoints = 0;
            foreach (Match item in matches)
            {
                travelPoints += item.Groups[2].Value.Length;
                destinations.Add(item.Groups[2].Value);
            }

            Console.WriteLine("Destinations: " + String.Join(", ", destinations));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
