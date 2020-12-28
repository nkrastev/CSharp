using System;
using System.Linq;

namespace Ex08CustomComparator
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var odd = input.Where(n => n % 2 == 0).OrderBy(n=>n).ToList();
            var even = input.Where(n => n % 2 != 0).OrderBy(n=>n).ToList();
            odd.AddRange(even);
            Console.WriteLine(String.Join(" ",odd));
            
        }
    }
}
