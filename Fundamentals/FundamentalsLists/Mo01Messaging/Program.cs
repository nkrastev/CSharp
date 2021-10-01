using System;
using System.Collections.Generic;
using System.Linq;

namespace Me01Messaging
{
    class Program
    {
        static void Main()
        {
            //input
            List<int> numbersList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string inputText = Console.ReadLine();
            int lenghtOfInputText = inputText.Length;
            string resultText = "";

            for (int i = 0; i < numbersList.Count; i++)
            {
                string currentElement = numbersList[i].ToString();
                int sumOfDigitOfCurrentElement=0;
                for (int j = 0; j < currentElement.Length; j++)
                {
                    sumOfDigitOfCurrentElement += int.Parse(currentElement[j].ToString());
                }                

                //check if index is out of range
                if (sumOfDigitOfCurrentElement>=lenghtOfInputText)
                {
                    sumOfDigitOfCurrentElement -= lenghtOfInputText;
                }

                resultText += inputText[sumOfDigitOfCurrentElement];
                inputText=inputText.Remove(sumOfDigitOfCurrentElement, 1);


            }

            Console.WriteLine(resultText);

        }
    }
}
