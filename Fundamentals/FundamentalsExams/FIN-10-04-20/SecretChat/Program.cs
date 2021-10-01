using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main()
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] instructions = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (instructions[0] == "InsertSpace")
                {
                    int index = int.Parse(instructions[1]);
                    message = InsertSpace(message, index);
                }
                if (instructions[0] == "Reverse")
                {
                    string substring = instructions[1];
                    message = Reverse(message, substring);
                }
                if (instructions[0] == "ChangeAll")
                {
                    string substring = instructions[1];
                    string replacement = instructions[2];
                    message = ChangeAll(message, substring, replacement);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");

        }

        private static string ChangeAll(string message, string substring, string replacement)
        {
            message = message.Replace(substring, replacement);
            Console.WriteLine(message);
            return message;
        }

        private static string Reverse(string message, string substring)
        {
            if (message.Contains(substring))
            {
                message = message.Remove(message.IndexOf(substring), substring.Length);

                char[] charArray = substring.ToCharArray();
                Array.Reverse(charArray);
                string reversed = new string(charArray);
                message = message.Insert(message.Length, reversed);
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("error");
            }
            return message;
        }

        private static string InsertSpace(string message, int index)
        {
            message = message.Insert(index, " ");
            Console.WriteLine(message);
            return message;
        }
    }
}
