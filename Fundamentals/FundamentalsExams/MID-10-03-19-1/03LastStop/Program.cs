using System;
using System.Collections.Generic;
using System.Linq;

namespace LastStop
{
    class Program
    {
        static void Main()
        {
            List<int> mainList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string instructions = Console.ReadLine();

            while (instructions!= "END")
            {
                string[] commands = instructions
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)                
                    .ToArray();

                if (commands[0]== "Change")
                {
                    int paintingNumber = int.Parse(commands[1]);
                    int changedNumber = int.Parse(commands[2]);
                    int searchedIndex = mainList.IndexOf(paintingNumber);
                    if (searchedIndex != -1)
                    {
                        mainList[searchedIndex] = changedNumber;
                    }
                }

                if (commands[0] == "Hide")
                {
                    int searchedIndex = mainList.IndexOf(int.Parse(commands[1]));
                    if (searchedIndex != -1)
                    {
                        mainList.RemoveAt(searchedIndex);
                    }
                }

                if (commands[0] == "Switch")
                {
                    int number1 = int.Parse(commands[1]);
                    int number2 = int.Parse(commands[2]);

                    int index1 = mainList.IndexOf(number1);
                    int index2 = mainList.IndexOf(number2);

                    if (index1 != -1 && index2 != -1)
                    {
                        mainList[index1] = number2;
                        mainList[index2] = number1;
                    }
                }

                if (commands[0] == "Insert")
                {
                    int indexToInsert = int.Parse(commands[1]);
                    int number = int.Parse(commands[2]);

                    if (indexToInsert >= 0 && indexToInsert < mainList.Count - 1)
                    {
                        mainList.Insert(indexToInsert+1, number);
                    }
                }

                if (commands[0]== "Reverse")
                {
                    mainList.Reverse();
                }
                instructions = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ",mainList));
        }       
    }
}
