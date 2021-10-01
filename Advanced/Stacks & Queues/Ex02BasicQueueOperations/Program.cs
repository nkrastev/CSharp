using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //N representing the number of elements to push into the queue
            int n = input[0];
            //S representing the number of elements to pop from the queue
            int s = input[1];
            //X, an element that you should look for in the queue
            int x = input[2];

            //numbers
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //Create and fill in queue
            Queue<int> queue = new Queue<int>(numbers);

            //Pop S numbers
            for (int i = 1; i <= s; i++)
            {
                queue.Dequeue();
            }

            //Queue is empty
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                //Queue is not empty. Queue contains X?
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    //find smallest
                    int smallest = int.MaxValue;

                    while (queue.Count >= 1)
                    {
                        if (smallest > queue.Peek())
                        {
                            smallest = queue.Peek();
                            queue.Dequeue();
                        }
                        else
                        {
                            queue.Dequeue();
                        }
                    }
                    Console.WriteLine(smallest);
                }
            }
        }
    }
}
