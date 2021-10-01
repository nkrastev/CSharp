using System;
using System.Collections.Generic;
using System.Linq;

namespace _03GenericSwapMethodStrings
{
    class Program
    {
        static void Main()
        {

            var n = int.Parse(Console.ReadLine());
            var customList = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                customList.AddToList(Console.ReadLine());
            }

            var elementsToSwap = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();            
            
            // will not check if indexes are valid
            customList.Swap(elementsToSwap[0], elementsToSwap[1]);

            Console.WriteLine(customList.Print());

        }
    }
}
