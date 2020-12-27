using System;
using System.Linq;

namespace Ex04FindEvensorOdds
{
    class Program
    {
        static void Main()
        {
            var range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var startRange = range[0];
            var endRange = range[1];

            var command = Console.ReadLine();
            Print(startRange, endRange, command);
            
        }

        private static void Print(int startRange, int endRange, string command)
        {
            if (command=="odd")
            {
                for (int i = startRange; i <= endRange; i++)
                {
                    if (i % 2!=0)
                    {
                        Console.Write(i+" ");
                    }
                }
            }
            else
            {
                for (int i = startRange; i <= endRange; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
