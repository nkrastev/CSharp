using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex01EvenLines
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("text.txt");
            for (int i = 0; i < input.Length; i++)
            {
                if (i %2==0)
                {
                    var line = input[i];
                    //replace
                    line = Regex.Replace(line, @"[\-\,\.\!\?]", "@");
                    //reverse
                    line = String.Join(" ", line.Split(' ').Reverse());
                    Console.WriteLine(line);
                }
            }
            
        }
       
    }
}
