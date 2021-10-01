using System;
using System.Linq;

namespace Ex03CustomMinFunction
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Min(x => x)
                .ToString();
            Console.WriteLine(input);
        }
    }
}
