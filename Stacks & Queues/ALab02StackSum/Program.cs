using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ALab02StackSum
{
    class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            string commands = Console.ReadLine();

            while (commands.ToLower()!="end")
            {
                string[] commandItems = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandItems[0].ToLower()=="add")
                {
                    int firstNum = int.Parse(commandItems[1]);
                    int secondNum = int.Parse(commandItems[2]);
                    AddToStack(stack, firstNum, secondNum);
                }

                if (commandItems[0].ToLower()=="remove")
                {
                    int countToRemove = int.Parse(commandItems[1]);
                    RemoveFromStack(stack, countToRemove);
                }
                commands = Console.ReadLine();
            }
            //output
            Console.WriteLine($"Sum: {stack.Sum()}");
        }

        private static Stack<int> RemoveFromStack(Stack<int> stack, int countToRemove)
        {
            if (stack.Count>=countToRemove)
            {
                for (int i = 1; i <= countToRemove; i++)
                {
                    stack.Pop();
                }
            }

            return stack;
        }

        private static Stack<int> AddToStack(Stack<int> stack, int firstNum, int secondNum)
        {
            stack.Push(firstNum);
            stack.Push(secondNum);
            return stack;
        }
    }
}
