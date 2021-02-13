using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rightSocks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var left = new Stack<int>(leftSocks);
            var right = new Queue<int>(rightSocks);

            var pairs = new List<int>();
            var biggestPair = 0;

            while (left.Count>0 && right.Count>0)
            {
                if (left.Peek()>right.Peek())
                {
                    //pair
                    if (left.Peek()+right.Peek()>biggestPair)
                    {
                        biggestPair = left.Peek() + right.Peek();
                    }
                    //Console.WriteLine(left.Peek() + right.Peek());
                    pairs.Add(left.Peek() + right.Peek());
                    left.Pop();
                    right.Dequeue();
                }
                else if (left.Peek()<right.Peek())
                {
                    //remove the left one and check the next one
                    left.Pop();
                }
                else if (left.Peek()==right.Peek())
                {
                    //remove the right sock and increment the value of the left one with 1.
                    right.Dequeue();
                    var temp = left.Pop() + 1;
                    left.Push(temp);
                }
                
            }

            //output
            Console.WriteLine(biggestPair);
            Console.WriteLine(String.Join(" ",pairs));
        }
    }
}
