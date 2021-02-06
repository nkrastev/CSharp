using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {           
            var inputTasks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var inputThreads = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var tasks = new Stack<int>(inputTasks);
            var threads = new Queue<int>(inputThreads);

            var valueOfTaskToKill = int.Parse(Console.ReadLine());

            while (tasks.Count>0 && threads.Count>0)
            {
                if (tasks.Peek() == valueOfTaskToKill)
                {
                    Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasks.Peek()}");
                    break;
                }

                if (threads.Peek()>=tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else if (threads.Peek()<tasks.Peek())
                {
                    threads.Dequeue();
                }                
            }

            Console.WriteLine(String.Join(" ", threads));
        }
    }
}
