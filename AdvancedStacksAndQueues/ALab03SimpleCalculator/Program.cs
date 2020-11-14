using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab03SimpleCalculator
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            //Array.Reverse(input);
            Stack<string> stack = new Stack<string>(input.Reverse());

            int totalSum = 0;
            
            while (stack.Any())
            {
                string currentElement = stack.Pop();
                if (currentElement!="+" && currentElement!="-")
                {
                    totalSum += int.Parse(currentElement);
                }
                if (currentElement=="+")
                {
                    totalSum += int.Parse(stack.Pop());
                }
                if (currentElement=="-")
                {
                    totalSum -= int.Parse(stack.Pop());
                }
            }
            Console.WriteLine(totalSum);

        }
    }
}
