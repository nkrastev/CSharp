using System;
using System.Text.RegularExpressions;

namespace Registration
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var successful = 0;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                Regex regex = new Regex(@"U\$([A-Z][a-z]{2,})U\$P@\$([a-zA-Z]{5,}[0-9]+)P@\$");
                MatchCollection matches = regex.Matches(input);

                if (matches.Count>0)
                {
                    foreach (Match item in matches)
                    {
                        Console.WriteLine("Registration was successful");
                        Console.WriteLine($"Username: {item.Groups[1].Value}, Password: {item.Groups[2].Value}");
                        successful++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }                
            }
            Console.WriteLine($"Successful registrations: {successful}");
        }
    }
}
