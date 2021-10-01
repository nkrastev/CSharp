using System;
using System.Linq;

namespace ALab01SortEvenNumbers
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x=>x%2==0)
                .OrderBy(x=>x)
                .ToList();
            Console.WriteLine(String.Join(", ",input));
        }
    }
}
