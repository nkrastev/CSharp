using System;
using System.Linq;

namespace _04GenericSwapMethodIntegers
{
    class Program
    {
        static void Main()
        {

            var n = int.Parse(Console.ReadLine());
            var customList = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                customList.AddToList(int.Parse(Console.ReadLine()));
            }

            var elementsToSwap = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            // will not check if indexes are valid
            customList.Swap(elementsToSwap[0], elementsToSwap[1]);

            Console.WriteLine(customList.Print());

        }
    }
}
