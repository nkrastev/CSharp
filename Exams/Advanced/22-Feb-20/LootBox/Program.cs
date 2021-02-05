using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main()
        {            
            Queue<int> first = ReadQueue();
            Stack<int> second = ReadStack();
            var value = 0;

            while (first.Count>0 && second.Count>0)
            {
                var firstElement = first.Peek();
                var secondElement = second.Peek();

                if ((firstElement+secondElement)%2==0)
                {
                    value += firstElement + secondElement;
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    second.Pop();
                    first.Enqueue(secondElement);
                }
            }

            if (first.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (value>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {value}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {value}");
            }

        }

        private static Stack<int> ReadStack()
        {
            var result = new Stack<int>();
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (var item in input)
            {
                result.Push(item);
            }
            return result;
        }

        private static Queue<int> ReadQueue()
        {
            var result = new Queue<int>();
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < input.Length; i++)
            {
                result.Enqueue(input[i]);
            }
            return result;
        }
    }
}
