using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    class Program
    {
        static void Main()
        {
            
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            bool isBalanced = true;
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i]==')' || input[i]=='}' || input[i]==']')&&(stack.Count==0))
                {
                    isBalanced = false;
                    break;
                }

                switch (input[i])
                {
                    //opening brackets
                    case '(':
                        {
                            stack.Push(input[i]);
                            break;
                        }
                    case '{':
                        {
                            stack.Push(input[i]);
                            break;
                        }
                    case '[':
                        {
                            stack.Push(input[i]);
                            break;
                        }
                    //check for corresponding closing brakets
                    case ')':
                        {
                            if (stack.Peek()!='(')
                            {
                                isBalanced = false;
                            }
                            else
                            {
                                stack.Pop();
                            }
                            break;
                        }
                    case ']':
                        {
                            if (stack.Peek() != '[')
                            {
                                isBalanced = false;
                            }
                            else
                            {
                                stack.Pop();
                            }
                            break;
                        }
                    case '}':
                        {
                            if (stack.Peek() != '{')
                            {
                                isBalanced = false;
                            }
                            else
                            {
                                stack.Pop();
                            }
                            break;
                        }
                }
                if (isBalanced==false)
                {
                    break;
                }
            }

            if (isBalanced && stack.Count==0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        
    }
}
