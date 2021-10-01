using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsLab
{
    class Program
    {
        static void Main()
        {
            //input
            List<int> inputList = ReadListOfInts();

            //are there changes in the original list?
            bool areChangesMade = false;

            //commands read and loop
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0]!="end")
            {
                if (command[0]=="Add")
                {
                    int number = int.Parse(command[1]);
                    inputList.Add(number);
                    areChangesMade = true;
                }
                if (command[0]== "Remove")
                {
                    int number = int.Parse(command[1]);
                    inputList.RemoveAll(item => item== number);
                    areChangesMade = true;
                }
                if (command[0]== "RemoveAt")
                {
                    int index = int.Parse(command[1]);
                    inputList.RemoveAt(index);
                    areChangesMade = true;
                }
                if (command[0]== "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);
                    inputList.Insert(index, number);
                    areChangesMade = true;
                }
                if (command[0]== "Contains")
                {
                    int number = int.Parse(command[1]);
                    if(inputList.Contains(number))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                if (command[0]== "PrintEven")
                {
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        if(inputList[i] %2==0)
                        {
                            Console.Write(inputList[i]+" ");
                            
                        }
                    }
                    Console.WriteLine();
                }
                if (command[0] == "PrintOdd")
                {
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        if (inputList[i] % 2 != 0)
                        {
                            Console.Write(inputList[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                if (command[0]== "GetSum")
                {
                    int numbersSum = 0;
                    for (int i = 0; i < inputList.Count; i++)
                    {
                        numbersSum += inputList[i];
                    }
                    Console.WriteLine(numbersSum);
                }
                if (command[0]== "Filter")
                {
                    string conditionFilter = command[1];
                    int number = int.Parse(command[2]);
                    if (command[1]== "<")
                    {
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            if (inputList[i]<number)
                            {
                                Console.Write(inputList[i]+" ");
                            }
                        }
                        Console.WriteLine();
                    }
                    if (command[1] == ">")
                    {
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            if (inputList[i] > number)
                            {
                                Console.Write(inputList[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    if (command[1] == "<=")
                    {
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            if (inputList[i] <= number)
                            {
                                Console.Write(inputList[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }
                    if (command[1] == ">=")
                    {
                        for (int i = 0; i < inputList.Count; i++)
                        {
                            if (inputList[i] >= number)
                            {
                                Console.Write(inputList[i] + " ");
                            }
                        }
                        Console.WriteLine();
                    }

                }




                command = Console.ReadLine().Split().ToArray();

            }



            if (areChangesMade)
            {
                foreach (var item in inputList)
                {
                    Console.Write(item + " ");
                }
            }
            


        }



        private static List<int> ReadListOfInts()
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            return list;
        }
    }
}