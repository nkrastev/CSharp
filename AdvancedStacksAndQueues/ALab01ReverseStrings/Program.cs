using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseStrings
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack=new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            while (stack.Any())
            {
                Console.Write(stack.Pop());
            }

        }
    }
}
