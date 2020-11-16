using System;
using System.Collections.Generic;

namespace MaximumandMinimumElement
{
    class Program
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string query = Console.ReadLine();

                if (query.StartsWith('1'))
                {
                    //1 x – Push the element x into the stack.
                    PushToStack(stack, query);
                } 
                else if (query=="2")
                {
                    //2 – Delete the element present at the top of the stack.
                    DeleteTop(stack);
                }
                else if (query=="3")
                {
                    //3 – Print the maximum element in the stack.
                    PrintTheMaximumElement(stack);
                }
                else
                {
                    //4 - Print the minimum element in the stack
                    PrintTheMinimumElement(stack);
                }
            }

            Console.WriteLine(String.Join(", ",stack));
        }

        private static void PrintTheMinimumElement(Stack<int> stack)
        {
            //create mirror stack and pop elements til end
            int minElement = int.MaxValue;
            Stack<int> tempStack = new Stack<int>(stack);
            while (tempStack.Count>0)
            {
                if(tempStack.Peek()<minElement)
                {
                    minElement = tempStack.Pop();
                }
                else
                {
                    tempStack.Pop();
                }
            }
            if (minElement!=int.MaxValue)
            {
                Console.WriteLine(minElement);
            }            
        }

        private static void PrintTheMaximumElement(Stack<int> stack)
        {
            //create mirror stack and pop elements til end
            int maxElement = int.MinValue;
            Stack<int> tempStack = new Stack<int>(stack);
            while (tempStack.Count > 0)
            {
                if (tempStack.Peek() > maxElement)
                {
                    maxElement = tempStack.Pop();
                }
                else
                {
                    tempStack.Pop();
                }
            }
            if (maxElement != int.MinValue)
            {
                Console.WriteLine(maxElement);
            }


        }

        private static Stack<int> DeleteTop(Stack<int> stack)
        {
            stack.Pop();
            return stack;
        }

        private static Stack<int> PushToStack(Stack<int> stack, string query)
        {
            int elementToPush = int.Parse(query.Substring(2, query.Length - 2));
            stack.Push(elementToPush);
            return stack;
        }
    }
}
