using System;
using System.Collections.Generic;

namespace Me03TakeSkipRope
{
    class Program
    {
        static void Main()
        {
            string inputString = Console.ReadLine();
            List<int> listNumbers = new List<int>();
            List<string> listNonNumbers = new List<string>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            string theResult = "";

            GetNumbers(inputString, listNumbers);
            GetNonNumbers(inputString, listNonNumbers);
            GetTakeAndSkipLists(listNumbers, takeList, skipList);



            //Console.WriteLine(String.Join(" take ", takeList));
            //Console.WriteLine(String.Join(" / ", listNonNumbers));

            Console.WriteLine(ExtractTheResult(theResult, listNonNumbers, takeList, skipList));
        }

        private static string ExtractTheResult(string theResult, List<string> listNonNumbers, List<int> takeList, List<int> skipList)
        {

            for (int i = 0; i < takeList.Count; i++)
            {
                //Console.WriteLine($"Position {position}");
                //Console.WriteLine($"Take {takeList[i]} chars");
                for (int j = 0; j < takeList[i]; j++)
                {
                    if (listNonNumbers.Count >= 1)
                    {
                        theResult += listNonNumbers[0];
                        listNonNumbers.RemoveAt(0);
                    }

                }

                //skip next skiplist[i] non numbers
                for (int j = 0; j < skipList[i]; j++)
                {
                    if (listNonNumbers.Count >= 1)
                    {

                        listNonNumbers.RemoveAt(0);
                    }
                }

            }


            return theResult;
        }

        private static (List<int>, List<int>) GetTakeAndSkipLists(List<int> listNumbers, List<int> takeList, List<int> skipList)
        {
            for (int i = 0; i < listNumbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(listNumbers[i]);
                }
                else
                {
                    skipList.Add(listNumbers[i]);
                }
            }

            return (takeList, skipList);
        }

        private static List<string> GetNonNumbers(string inputString, List<string> listNonNumbers)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (!Char.IsDigit(inputString[i]))
                {
                    listNonNumbers.Add(inputString[i].ToString());
                }
            }
            return listNonNumbers;
        }

        private static List<int> GetNumbers(string inputString, List<int> listNumbers)
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (Char.IsDigit(inputString[i]))
                {
                    listNumbers.Add(int.Parse(inputString[i].ToString()));
                }
            }
            return listNumbers;
        }
    }
}