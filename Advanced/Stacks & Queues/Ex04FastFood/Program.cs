using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main()
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOrders = new Queue<int>(ordersInput);
            int biggestOrder = FindTheBiggestOrder(queueOrders);          

            while (queueOrders.Count>0)
            {
                if (foodQuantity>=queueOrders.Peek())
                {
                    foodQuantity -= queueOrders.Peek();
                    queueOrders.Dequeue();
                }
                else
                {                    
                    break;
                }
            }

            if (queueOrders.Count==0)
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine(biggestOrder);
                Console.Write("Orders left: ");
                while (queueOrders.Count>0)
                {
                    Console.Write(queueOrders.Dequeue()+" ");
                }
            }

        }

        private static int FindTheBiggestOrder(Queue<int> queueOrders)
        {
            int biggest = 0;
            Queue<int> tempQueue = new Queue<int>(queueOrders);

            while (tempQueue.Count>0)
            {
                if (biggest<tempQueue.Peek())
                {
                    biggest = tempQueue.Dequeue();
                }
                else
                {
                    tempQueue.Dequeue();
                }
            }
            return biggest;
        }
    }
}
