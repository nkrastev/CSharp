using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04ListOperations
{
    class Program
    {
        static void Main()
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0]!="End")
            {
                if (command[0]=="Add")
                {                    
                    AddNumber(inputList, int.Parse(command[1]));
                }
                if (command[0]== "Insert")
                {
                    InsertNumberAtIndex(inputList, int.Parse(command[1]), int.Parse(command[2]));
                }
                if (command[0]== "Remove")
                {
                    RemoveAtIndex(inputList, int.Parse(command[1]));
                }
                if (command[0]== "Shift" && command[1]== "left")
                {
                    ShiftLeft(inputList, int.Parse(command[2]));
                }
                if (command[0] == "Shift" && command[1] == "right")
                {
                    ShiftRight(inputList, int.Parse(command[2]));
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(String.Join(" ",inputList));

        }

        static List<int> ShiftRight(List<int> inputList, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int lastElement = inputList[inputList.Count-1];
                for (int j = inputList.Count-1; j > 0; j--)
                {
                    inputList[j] = inputList[j - 1];
                }
                inputList[0] = lastElement;
                
            }

            return inputList;
        }

        static List<int> ShiftLeft(List<int> inputList, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int firstElement = inputList[0];
                for (int j = 0; j < inputList.Count-1; j++)
                {
                    inputList[j] = inputList[j + 1];
                }
                inputList[inputList.Count - 1] = firstElement;
            }

            return inputList;
        }

        static List<int> RemoveAtIndex(List<int> inputList, int index)
        {
            if (index >= inputList.Count || index < 0)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                inputList.RemoveAt(index);
            }

            return inputList;    
        }

        static List<int> InsertNumberAtIndex(List<int> input, int number, int index)
        {
            if (index>=input.Count || index < 0)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                input.Insert(index, number);
            }

            return input;
        }

        static List<int> AddNumber(List<int> input, int numberToAdd)
        {
            input.Add(numberToAdd);
            return input;
        }
    }
}
