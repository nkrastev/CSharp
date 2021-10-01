using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07AppendArrays
{
    class Program
    {
        static void Main()
        {
            List<string> input = Console.ReadLine().Split("|").ToList();
            input.Reverse();

            foreach (var item in input)
            {                
                //StringSplitOptions.RemoveEmptyEntries
                List<int> tempList = item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                foreach (var item2 in tempList)
                {
                    Console.Write(item2+" ");
                }
            }
        }
    }
}
