using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex06ReverseAndExclude
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var divisionBy = int.Parse(Console.ReadLine());
            var newList = input.Where(x => x % divisionBy != 0).Reverse().ToList();            
            Console.WriteLine(String.Join(" ",newList));
        }
    }
}
