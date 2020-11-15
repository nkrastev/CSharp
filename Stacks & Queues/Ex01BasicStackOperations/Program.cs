using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            //N representing the number of elements to push into the stack
            int n = input[0];
            //S representing the number of elements to pop from the stack
            int s = input[1];
            //X, an element that you should look for in the stack IS IT SURE X IS AND INTEGER?
            int x = input[2];

            //numbers
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //Create and fill in stack
            Stack<int> stack = new Stack<int>(numbers);

            //Pop S numbers
            for (int i = 1; i <= s; i++)
            {
                stack.Pop();
            }

            //Stack is empty
            if (stack.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                //Stack is not empty. Stack contains X?
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    //find smallest
                    int smallest = int.MaxValue;

                    while (stack.Count>=1)
                    {
                        if (smallest > stack.Peek())
                        {
                            smallest = stack.Peek();
                            stack.Pop();
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                    Console.WriteLine(smallest);
                }
            }

            



        }
    }
}
