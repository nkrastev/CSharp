using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main()
        {
            int[] inputDelivery = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int rackCount = 1;
            int rackState = 0;
            Stack<int> delivery = new Stack<int>(inputDelivery);

            while (delivery.Count>0)
            {                
                if (delivery.Peek()<= rackCapacity-rackState)
                {
                    //there is a place in the current rack
                    rackState += delivery.Pop();
                }
                else
                {
                    //not enought place, get new rack
                    rackState = 0;
                    rackState += delivery.Pop();
                    rackCount++;
                }
            }
            Console.WriteLine(rackCount);
        }
    }
}
