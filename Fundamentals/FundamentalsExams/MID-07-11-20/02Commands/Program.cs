using System;
using System.Collections.Generic;
using System.Linq;

namespace Commands
{
    class Program
    {
        static void Main()
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string instruction = Console.ReadLine();

            while (instruction != "end")
            {
                string[] command = instruction.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                ExecuteCommands(input, command);                
                instruction = Console.ReadLine();
            }
            //output
            Console.WriteLine(String.Join(", ",input));
        }

        private static List<string> ExecuteCommands(List<string> input, string[] command)
        {
            if (command[0] == "reverse")
            {
                input.Reverse(int.Parse(command[2]), int.Parse(command[4]));
            }
            if (command[0] == "sort")
            {
                input.Sort(int.Parse(command[2]), int.Parse(command[4]), null);
            }
            if (command[0] == "remove")
            {
                int count = int.Parse(command[1]);
                for (int i = 1; i <= count; i++)
                {
                    input.RemoveAt(0);
                }
            }
            return input;
        }
    }
}
