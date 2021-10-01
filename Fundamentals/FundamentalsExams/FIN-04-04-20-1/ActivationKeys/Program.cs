using System;
using System.Linq;

namespace ActivationKeys
{
    class Program
    {
        static void Main()
        {
            string rawKey = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] commandItems = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandItems[0] == "Contains")
                {
                    CommandContains(rawKey, commandItems[1]);
                }
                if (commandItems[0] == "Flip")
                {
                    int startIndex = int.Parse(commandItems[2]);
                    int endIndex = int.Parse(commandItems[3]);
                    rawKey = CommandFlip(rawKey, commandItems[1], startIndex, endIndex);
                }
                if (commandItems[0] == "Slice")
                {
                    int startIndex = int.Parse(commandItems[1]);
                    int endIndex = int.Parse(commandItems[2]);
                    rawKey = CommandSlice(rawKey, startIndex, endIndex);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {rawKey}");
        }

        private static string CommandSlice(string rawKey, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                int temp = startIndex;
                startIndex = endIndex;
                endIndex = temp;
            }
            string newKey = rawKey.Remove(startIndex, endIndex - startIndex);
            Console.WriteLine(newKey);
            return newKey;
        }

        private static string CommandFlip(string rawKey, string upperLower, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                int temp = startIndex;
                startIndex = endIndex;
                endIndex = temp;
            }
            var newRawKey = "";
            if (upperLower == "Upper")
            {
                newRawKey = new string
                    (
                        rawKey
                            .Select((c, i) =>
                                (i >= startIndex && i < endIndex) ? Char.ToUpper(c) : c)
                            .ToArray()
                    );
            }
            if (upperLower == "Lower")
            {
                newRawKey = new string
                    (
                        rawKey
                            .Select((c, i) =>
                                (i >= startIndex && i < endIndex) ? Char.ToLower(c) : c)
                            .ToArray()
                    );
            }
            Console.WriteLine(newRawKey);
            return newRawKey;
        }

        private static void CommandContains(string rawKey, string v)
        {
            if (rawKey.Contains(v))
            {
                Console.WriteLine($"{rawKey} contains {v}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }
    }
}
