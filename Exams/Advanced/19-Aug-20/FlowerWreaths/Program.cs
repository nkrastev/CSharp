using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            
            var wreathCount = 0;
            var flowersForLater = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                if (lilies.Peek() + roses.Peek() == 15)
                {
                    wreathCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    var value = lilies.Pop() - 2;
                    lilies.Push(value);
                }
                else if (lilies.Peek() + roses.Peek() < 15)
                {
                    flowersForLater += lilies.Pop();
                    flowersForLater += roses.Dequeue();
                }
            }

            var wreathFromLaterFlower = flowersForLater / 15;

            if (wreathCount + wreathFromLaterFlower >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount + wreathFromLaterFlower} wreaths!");
            }
            else
            {

                Console.WriteLine($"You didn't make it, you need {5 - wreathCount - wreathFromLaterFlower} wreaths more!");
            }
        }

    }
}
