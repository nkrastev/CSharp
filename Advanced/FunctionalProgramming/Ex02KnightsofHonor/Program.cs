using System;
using System.Linq;

namespace Ex02KnightsofHonor
{
    class Program
    {
        static void Main()
        {
            Action<string> print = name => Console.WriteLine($"Sir {name}");
            
            var input = Console.ReadLine().Split().ToList();
            foreach (var item in input)
            {
                print(item);
            }          
        }
    }
}
