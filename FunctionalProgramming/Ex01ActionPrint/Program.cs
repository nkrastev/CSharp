using System;
using System.Linq;

namespace Ex01ActionPrint
{
    class Program
    {
        static void Main()
        {
            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
