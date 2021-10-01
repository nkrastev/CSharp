using System;
using System.Linq;

namespace Ex03ExtractFile
{
    class Program
    {
        static void Main()
        {            
            string input = Console.ReadLine();
            string[] items = input.Split(new[] {"\\","." },StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            Console.WriteLine($"File name: {items[items.Length-2]}");
            Console.WriteLine($"File extension: {items[items.Length-1]}");
            
        }


    }
}
