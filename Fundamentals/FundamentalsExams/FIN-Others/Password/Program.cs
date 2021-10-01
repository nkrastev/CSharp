using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Password
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                Regex regex = new Regex(@"^(.+)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^><]{3})<(\1)");
                MatchCollection matches = regex.Matches(input);
                if (matches.Count==0)
                {
                    Console.WriteLine("Try another password!");
                }
                else
                {
                    StringBuilder password = new StringBuilder();
                    foreach (Match item in matches)
                    {
                        password.Append(item.Groups[2].Value);
                        password.Append(item.Groups[3].Value);
                        password.Append(item.Groups[4].Value);
                        password.Append(item.Groups[5].Value);
                    }
                    Console.WriteLine($"Password: {password.ToString()}");
                }
            }
        }
    }
}
