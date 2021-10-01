using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex02ChangeList
{
    class Program
    {
        static void Main()
        {
            List<int> inputList = ReadListOfIntegers();
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0]!="end")
            {
                if (command[0]== "Delete")
                {
                    int element = int.Parse(command[1]);
                    DeleteElementFromList(inputList, element);
                }

                if (command[0]== "Insert")
                {
                    int element = int.Parse(command[1]);
                    int position = int.Parse(command[2]);
                    InsertElementToList(inputList, element, position);
                }
                command = Console.ReadLine().Split().ToArray();
            }
            //output
            PrintTheList(inputList);
        }

        private static void PrintTheList(List<int> inputList)
        {
            Console.WriteLine(String.Join(" ",inputList));
        }

        private static List<int> InsertElementToList(List<int> inputList, int element, int position)
        {
            inputList.Insert(position, element);

            return inputList;
        }

        private static List<int> DeleteElementFromList(List<int> inputList, int element)
        {
            inputList.RemoveAll(item => item == element);
            return inputList;
        }

        private static List<int> ReadListOfIntegers()
        {
            List<int> listItems = Console.ReadLine().Split().Select(int.Parse).ToList();
            return listItems;
        }
    }
}
