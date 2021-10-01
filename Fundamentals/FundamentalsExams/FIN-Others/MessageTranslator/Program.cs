using System;
using System.Text.RegularExpressions;

namespace MessageTranslator
{
    class Program
    {
        static void Main()
        {
            Regex regex = new Regex(@"!([A-Z][a-z]{2,})!:\[([a-zA-z]{8,})\]");
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                MatchCollection matches = regex.Matches(input);
                if (matches.Count==0)
                {
                    Console.WriteLine("The message is invalid");
                }
                else
                {
                    var command = string.Empty;
                    var message = string.Empty;
                    foreach (Match item in matches)
                    {
                        command = item.Groups[1].Value;
                        message = item.Groups[2].Value;
                    }
                    Console.Write(command+": ");
                    for (int j = 0; j < message.Length; j++)
                    {
                        Console.Write((int)message[j]+" ");
                    }
                    Console.WriteLine();

                }
            }
        }
    }
}
