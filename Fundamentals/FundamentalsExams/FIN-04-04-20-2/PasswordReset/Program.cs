using System;
using System.Linq;

namespace PasswordReset
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] commandParts = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (commandParts[0] == "TakeOdd")
                {
                    input = TakeOdd(input);
                    Console.WriteLine(input);
                }
                if (commandParts[0] == "Cut")
                {
                    int index = int.Parse(commandParts[1]);
                    int lenght = int.Parse(commandParts[2]);
                    input = CutPassword(input, index, lenght);
                }
                if (commandParts[0] == "Substitute")
                {
                    string substring = commandParts[1];
                    string substitute = commandParts[2];
                    input = SubstitutePassword(input, substring, substitute);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {input}");
        }

        private static string SubstitutePassword(string input, string substring, string substitute)
        {
            if (input.Contains(substring))
            {
                input = input.Replace(substring, substitute);
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }
            return input;
        }

        private static string CutPassword(string input, int index, int lenght)
        {
            input = input.Remove(index, lenght);
            Console.WriteLine(input);
            return input;
        }

        private static string TakeOdd(string input)
        {
            string newString = "";
            newString = string.Concat(input.Where((c, i) => i % 2 != 0));
            return newString;
        }
    }
}
