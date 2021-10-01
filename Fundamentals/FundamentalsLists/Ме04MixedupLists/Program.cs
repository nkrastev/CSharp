using System;
using System.Collections.Generic;
using System.Linq;

namespace Ме04MixedupLists
{
    class Program
    {
        static void Main()
        {
            List<double> firstList = ReadListFromLine();
            List<double> secondList = ReadListFromLine();
            double startRange = 0;
            double endRange = 0;

            //get range
            if (firstList.Count>secondList.Count)
            {
                //first list is bigger, get last 2 elements for range
                startRange = firstList[firstList.Count - 2];
                endRange = firstList[firstList.Count - 1];
                if (startRange>endRange)
                {
                    //swap values of range
                    double temp = endRange;
                    endRange = startRange;
                    startRange = temp;
                }
                //remove last 2 elements to get equal lists
                firstList.RemoveAt(firstList.Count - 1);
                firstList.RemoveAt(firstList.Count - 1);
            }
            else
            {
                //second list is bigger
                startRange = secondList[0];
                endRange = secondList[1];
                if (startRange > endRange)
                {
                    //swap values of range
                    double temp = endRange;
                    endRange = startRange;
                    startRange = temp;
                }
                //remove last 2 elements to get equal lists
                secondList.RemoveAt(0);
                secondList.RemoveAt(0);
            }
            // we have two equal lists

            List<double> mergedList = new List<double>();

            for (int i = 0; i < firstList.Count; i++)
            {
                mergedList.Add(firstList[i]);
                mergedList.Add(secondList[firstList.Count - i-1]);
            }

            mergedList.Sort();

            for (int i = 0; i < mergedList.Count; i++)
            {
                if (mergedList[i]>startRange && mergedList[i]<endRange)
                {
                    Console.Write(mergedList[i]+" ");
                }
            }

            

        }

        private static List<double> ReadListFromLine()
        {
            List<double> readList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();
            return readList;
        }
    }
}
