using System;
using System.Linq;

namespace TheImitationGame
{
    class Program
    {
        static void Main()
        {
            var message = Console.ReadLine();
            var instructions = Console.ReadLine();
            while (instructions != "Decode")
            {
                var command = instructions.Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "Move")
                {
                    var numberOfLetters = int.Parse(command[1]);
                    message = MoveLetters(message, numberOfLetters);
                }
                if (command[0] == "Insert")
                {
                    var index = int.Parse(command[1]);
                    var value = command[2];
                    message = InsertString(message, index, value);
                }
                if (command[0] == "ChangeAll")
                {
                    var substring = command[1];
                    var replacement = command[2];
                    message = ChangeAll(message, substring, replacement);
                }
                instructions = Console.ReadLine();
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }

        private static string ChangeAll(string message, string substring, string replacement)
        {
            message = message.Replace(substring, replacement);
            return message;
        }

        private static string InsertString(string message, int index, string value)
        {
            message = message.Insert(index, value);
            return message;
        }

        private static string MoveLetters(string message, int numberOfLetters)
        {
            //o	Moves the first n letters to the back of the string. ??? If n is bigger than the lenght?
            if (numberOfLetters < message.Length)
            {
                string toCut = message.Substring(0, numberOfLetters);
                message = message.Remove(0, numberOfLetters);
                message = message.Insert(message.Length, toCut);
            }
            return message;
        }
    }
}
