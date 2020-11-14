using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            //1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    brackets.Push(i);
                }
                if (input[i]==')')
                {
                    int startIndex = brackets.Pop();
                    string expression = input.Substring(startIndex, i - startIndex+1);
                    Console.WriteLine(expression);                    
                }
            }
        }
    }
}
