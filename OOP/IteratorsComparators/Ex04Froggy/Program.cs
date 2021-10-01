using System;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            //1, 2, 3, 4, 5, 6, 7, 8
            var input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            Lake lake = new Lake(input);

            Console.WriteLine(String.Join(", ", lake));

        }
    }
}
