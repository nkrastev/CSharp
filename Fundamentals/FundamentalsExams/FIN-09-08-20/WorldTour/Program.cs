using System;
using System.Linq;

namespace WorldTour
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var manipulate = Console.ReadLine();

            while (manipulate != "Travel")
            {
                var command = manipulate.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command[0] == "Add Stop")
                {
                    var index = int.Parse(command[1]);
                    var stringItem = command[2];
                    input = AddStop(input, index, stringItem);
                }
                if (command[0] == "Remove Stop")
                {
                    var startIndex = int.Parse(command[1]);
                    var endIndex = int.Parse(command[2]);
                    input = RemoveStop(input, startIndex, endIndex);
                }
                if (command[0] == "Switch")
                {
                    var oldString = command[1];
                    var newString = command[2];
                    input = SwitchString(input, oldString, newString);
                }
                manipulate = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }

        private static string SwitchString(string input, string oldString, string newString)
        {
            if (input.Contains(oldString))
            {
                input = input.Replace(oldString, newString);
            }
            Console.WriteLine(input);
            return input;
        }

        private static string RemoveStop(string input, int startIndex, int endIndex)
        {
            if (startIndex >= 0 && endIndex >= 0 && startIndex < input.Length && endIndex < input.Length)
            {
                input = input.Remove(startIndex, endIndex - startIndex + 1);
            }
            Console.WriteLine(input);
            return input;
        }

        private static string AddStop(string input, int index, string stringItem)
        {
            //insert the given string at that index only if the index is valid
            if (index >= 0 && index < input.Length)
            {
                input = input.Insert(index, stringItem);
            }
            Console.WriteLine(input);
            return input;
        }
    }
}
