using System;
using System.Linq;

namespace StringManipulator
{
    class Program
    {
        static void Main()
        {
            var data = string.Empty;
            var command = Console.ReadLine();
            while (command != "End")
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdArgs[0] == "Add")
                {
                    data = AddString(data, cmdArgs[1]);
                    PrintString(data);
                }
                if (cmdArgs[0] == "Upgrade")
                {
                    data = UpgradeString(data, char.Parse(cmdArgs[1]));
                    PrintString(data);
                }
                if (cmdArgs[0] == "Print")
                {
                    PrintString(data);
                }
                if (cmdArgs[0] == "Index")
                {
                    IndexString(data, char.Parse(cmdArgs[1]));
                }
                if (cmdArgs[0] == "Remove")
                {
                    data = RemoveString(data, cmdArgs[1]);
                    PrintString(data);
                }
                command = Console.ReadLine();
            }
        }
        private static void PrintString(string data)
        {
            Console.WriteLine(data);
        }


        private static string RemoveString(string data, string v)
        {
            data = data.Replace(v, "");
            return data;
        }

        private static void IndexString(string data, char v)
        {
            //o	Find the all indeces where {char} occurs, then print them separated by a space.
            //If no occurences - print "None".
            bool isCharFound = false;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i]==v)
                {
                    Console.Write(i+" ");
                    isCharFound = true;
                }            
            }

            if (!isCharFound)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine();
            }
        }

        private static string UpgradeString(string data, char v)
        {
            //o	Find all occurences of {char} and replace it with its ASCII code plus one.
            string newString = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i]==v)
                {
                    newString+= (char)(v + 1);
                }
                else
                {
                    newString += data[i];
                }
            }

            return newString;
        }

        private static string AddString(string data, string v)
        {
            data += v;
            return data;
        }
    }
}
