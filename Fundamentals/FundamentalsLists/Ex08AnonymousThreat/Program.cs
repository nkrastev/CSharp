using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex08AnonymousThreat
{
    class Program
    {
        static void Main()
        {
            List<string> inputList = Console.ReadLine()
                .Split()
                .ToList();

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0]!="3:1")
            {
                if (command[0]=="merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    MergeElements(inputList, startIndex, endIndex);
                }

                if (command[0]== "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);
                    DivideElements(inputList, index, partitions);
                }

                command = Console.ReadLine().Split().ToArray();
            }

            //output
            Console.WriteLine(String.Join(" ",inputList));

        }

        private static List<string> DivideElements(List<string> inputList, int index, int partitions)
        {
            // ab CD ef , 3 parts
            string elementToBeDivided = inputList[index];            
            inputList.RemoveAt(index);

            int partSize = elementToBeDivided.Length / partitions;
            int reminder = elementToBeDivided.Length % partitions;

            List<string> tmpList = new List<string>();

            for (int i = 0; i < partitions; i++)
            {
                string tmpString = "";

                for (int p = 0; p < partSize; p++)
                {
                    tmpString += elementToBeDivided[(i * partSize) + p];
                }

                if (i == partitions - 1 && reminder != 0)
                {
                    tmpString += elementToBeDivided.Substring(elementToBeDivided.Length - reminder);
                }

                tmpList.Add(tmpString);
            }
            inputList.InsertRange(index, tmpList);

            return inputList;
        }



        private static List<string> MergeElements(List<string> inputList, int startIndex, int endIndex)
        {
            //check if indexes are in the range
            if (startIndex<0)
            {
                startIndex = 0;
            }
            if (startIndex>inputList.Count-1)
            {
                startIndex = inputList.Count - 1;
            }            
            if (endIndex>inputList.Count-1)
            {
                endIndex = inputList.Count - 1;
            }            
            // merging
            string tempValue = "";
            for (int i = startIndex; i <=endIndex; i++)
            {
                tempValue += inputList[i];                               
            }
            for (int i = endIndex; i > startIndex; i--)
            {
                inputList.RemoveAt(i);
            }            
            inputList[startIndex] = tempValue;          
            return inputList;
        }
    }
}
