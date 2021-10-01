using System;
using System.Linq;

namespace ALab05WordFilter
{
    class Program
    {
        static void Main()
        {
            string[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x =>  x.Length % 2 == 0)
                .ToArray();

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
