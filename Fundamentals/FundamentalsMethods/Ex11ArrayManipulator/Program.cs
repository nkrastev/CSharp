using System;
using System.Linq;

namespace Ex11ArrayManipulator
{
    class Program
    {
        static void Main()
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArray = command.Split();

                if (commandArray[0] == "exchange")
                {
                    int splitNumber = int.Parse(commandArray[1]);
                    inputArr= (int[])ExchangeArray(inputArr, splitNumber);
                }

                if (commandArray[0] == "min" || commandArray[0] == "max")
                {
                    string minOrMax = commandArray[0];
                    string oddOrEven = commandArray[1];
                    PrintMinMaxOddEven(inputArr, minOrMax, oddOrEven);
                }

                if (commandArray[0] == "first")
                {
                    int elementCount = int.Parse(commandArray[1]);
                    string oddOrEven = commandArray[2];
                    PrintFirstElements(inputArr, elementCount, oddOrEven);
                }

                if (commandArray[0] == "last")
                {
                    int elementCount = int.Parse(commandArray[1]);
                    string oddOrEven = commandArray[2];
                    PrintLastElements(inputArr, elementCount, oddOrEven);
                }
                command = Console.ReadLine();
            }

            //output the final array
            Console.Write("[");
            for (int i = 0; i < inputArr.Length; i++)
            {
                Console.Write(inputArr[i]);
                if (i<inputArr.Length-1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]");

        }

        static Array ExchangeArray(int[] arr, int splitIndex)
        {
            if (splitIndex >= arr.Length)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }
            else
            {
                int[] changedArray = new int[arr.Length];
                int counterForNewArray = 0;
                for (int i = splitIndex+1 ; i < arr.Length; i++)
                {
                    changedArray[counterForNewArray] = arr[i];
                    counterForNewArray++;
                }
                for (int i = 0; i < splitIndex+1 ; i++)
                {
                    changedArray[counterForNewArray] = arr[i];
                    counterForNewArray++;
                }

                /*foreach (var item in changedArray)
                {
                    Console.Write(item+" / ");
                }*/

                return changedArray;
            }
        }

        static void PrintMinMaxOddEven(int[] arr, string commandMinMax, string commandOddEven)
        {
            // odd
            int minOdd = int.MaxValue;
            int maxOdd = int.MinValue;
            int minOddPosition = -1;
            int maxOddPosition = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0 && minOdd >= arr[i])
                {
                    minOdd = arr[i];
                    minOddPosition = i;
                }
                if (arr[i] % 2 != 0 && maxOdd <= arr[i])
                {
                    maxOdd = arr[i];
                    maxOddPosition = i;
                }
            }
            // even
            int minEven = int.MaxValue;
            int maxEven = int.MinValue;
            int minEvenPosition = -1;
            int maxEvenPosition = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0 && minEven >= arr[i])
                {
                    minEven = arr[i];
                    minEvenPosition = i;
                }
                if (arr[i] % 2 == 0 && maxEven <= arr[i])
                {
                    maxEven = arr[i];
                    maxEvenPosition = i;
                }
            }
            //output
            if (commandOddEven == "odd")
            {
                if (commandMinMax == "min")
                {
                    if (minOddPosition != -1)
                    {
                        Console.WriteLine(minOddPosition);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                if (commandMinMax == "max")
                {
                    if (maxOddPosition != -1)
                    {
                        Console.WriteLine(maxOddPosition);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
            }
            if (commandOddEven == "even")
            {
                if (commandMinMax == "min")
                {
                    if (minEvenPosition != -1)
                    {
                        Console.WriteLine(minEvenPosition);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                if (commandMinMax == "max")
                {
                    if (maxEvenPosition != -1)
                    {
                        Console.WriteLine(maxEvenPosition);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
            }
        }

        static void PrintFirstElements(int[] arr, int countOfElements, string oddOrEven)
        {
            ////first {count} even/odd– returns the first {count} elements -> [1, 8, 2, 3] -> first 2 even -> print [8, 2]
            if (countOfElements > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (oddOrEven == "odd")
                {
                    // first N odd Elements
                    //count all odd elements
                    int oddCounter = 0;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] % 2 != 0) { oddCounter++;}
                    }
                    int[] allOdds = new int[countOfElements];
                    //setup array with only odds                     
                    for (int i = 0; i < countOfElements; i++)
                    {
                        if (arr[i] % 2 != 0)
                        {
                            allOdds[i] = arr[i];
                        }
                        else allOdds[i] = -1; // fill the new array with invalid input data
                    }

                    //output
                    Console.Write("[");
                    for (int i = 0; i < countOfElements; i++)
                    {
                        if (allOdds[i]>=0) { Console.Write(allOdds[i]); }
                        if (i < countOfElements - 1 && allOdds[i-1] >= 0) { Console.Write(", "); }
                    }
                    Console.WriteLine("]");



                }
                if (oddOrEven == "even")
                {
                    int evenCounter = 0;
                    Console.Write("[");
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] % 2 == 0)
                        {
                            Console.Write(arr[i]);
                            evenCounter++;
                            if (evenCounter == countOfElements || i == arr.Length - 1)
                            {
                                Console.WriteLine("]");
                                break;
                            }
                            else
                            {
                                Console.Write(", ");
                            }
                        }
                    }
                    if (evenCounter == 0) { Console.WriteLine("]"); }
                }
            }
        }

        static void PrintLastElements(int[] arr, int countOfElements, string oddOrEven)
        {
            ////LAST!!!
            if (countOfElements > arr.Length)
            {
                Console.WriteLine("Invalid count");
            }
            else
            {
                if (oddOrEven == "odd")
                {
                    // needed last N odd elements
                    int[] allOdds = new int[countOfElements];
                    int counterOdds = 0;
                    for (int i = arr.Length-1; i >=0; i--)
                    {
                        if (arr[i] % 2 !=0)
                        {
                            allOdds[counterOdds] = arr[i];
                            counterOdds++;
                            if (counterOdds==countOfElements)
                            {
                                break;
                            }
                        }
                    }
                    Console.Write("[");
                    for (int i = allOdds.Length-1; i >= 0; i--)
                    {
                        if (allOdds[i] != 0) { Console.Write(allOdds[i]); }
                        if (i > 0 && allOdds[i] != 0) { Console.Write(", "); }
                    }
                    Console.WriteLine("]");
                }
                if (oddOrEven == "even")
                {
                    // needed last N EVEN elements, I'm lazy and will not change the name of the variables ;)
                    int[] allOdds = new int[countOfElements];
                    int counterOdds = 0;
                    for (int i = arr.Length - 1; i >= 0; i--)
                    {
                        if (arr[i] % 2 == 0)
                        {
                            allOdds[counterOdds] = arr[i];
                            counterOdds++;
                            if (counterOdds == countOfElements)
                            {
                                break;
                            }
                        }
                    }
                    Console.Write("[");
                    for (int i = allOdds.Length - 1; i >= 0; i--)
                    {
                        if (allOdds[i] != 0) { Console.Write(allOdds[i]); }
                        if (i > 0 && allOdds[i] != 0) { Console.Write(", "); }
                    }
                    Console.WriteLine("]");
                }
            }
        }


    }
}
