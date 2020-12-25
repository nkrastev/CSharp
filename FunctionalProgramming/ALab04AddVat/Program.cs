using System;
using System.Linq;

namespace ALab04AddVat
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 0.2 + x)
                .ToList();
            foreach (var item in input)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
