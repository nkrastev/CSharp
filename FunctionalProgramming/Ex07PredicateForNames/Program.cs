using System;
using System.Linq;

namespace Ex07PredicateForNames
{
    class Program
    {
        static void Main()
        {
            var lenght = int.Parse(Console.ReadLine());
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length <= lenght)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
