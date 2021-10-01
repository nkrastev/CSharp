using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05AppliedArithmetics
{
    class Program
    {
        static void Main()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine();

            Func<List<int>, string, List<int>> functionCommands = (list, command) =>
            {
                if (command == "add") return list.Select(x => x + 1).ToList();
                else if (command == "multiply") return list.Select(x => x * 2).ToList();
                else return list.Select(x => x - 1).ToList();
            };

            Action<List<int>> print = list =>
            {
                Console.WriteLine(String.Join(" ", list));
            };

            while (command!="end")
            {
                if (command == "print")
                {
                    print(list);
                }
                else
                {
                    list=functionCommands(list, command);
                }
                command = Console.ReadLine();
            }
        }
    }
}
