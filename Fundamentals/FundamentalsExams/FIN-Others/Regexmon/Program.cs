using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01Regexmon
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            Regex bojomonRegex = new Regex(@"[A-Za-z]+-[A-Za-z]+");
            Regex didimonRegex = new Regex(@"[^A-Za-z- ]+");

            MatchCollection bojoMatches = bojomonRegex.Matches(input);
            MatchCollection didiMatches = didimonRegex.Matches(input);

            List<string> didi = new List<string>();
            List<string> bojo = new List<string>();

            foreach (Match item in didiMatches)
            {
                didi.Add(item.Value);
            }
            foreach (Match item in bojoMatches)
            {
                bojo.Add(item.Value);
            }

            int lowerCount = Math.Max(didi.Count, bojo.Count);

            for (int i = 0; i < lowerCount; i++)
            {
                if (didi.Count>i)
                {
                    Console.WriteLine(didi[i]);
                }
                else
                {
                    break;
                }
                if (bojo.Count>i)
                {
                    Console.WriteLine(bojo[i]);
                }
                else
                {
                    break;
                }        
                
            }
        }
    }
}
