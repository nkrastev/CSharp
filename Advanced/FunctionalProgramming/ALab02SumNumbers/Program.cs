using System;
using System.Linq;

namespace ALab02SumNumbers
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)                
                .ToList();

            Console.WriteLine(input.Count);
            Console.WriteLine(input.Sum());

        }
    }
}
