using System;
using System.Linq;

namespace Ex08LettersChangeNumbers
{
    class Program
    {
        static void Main()
        {
            string[] mainInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            double totalSum = 0;

            for (int i = 0; i < mainInput.Length; i++)
            {
                string input = mainInput[i];

                char firstLetterItem = input[0];
                char lastLetterItem = input[input.Length - 1];

                //get positions of the letters
                int firstLetterPosition=PositionInAlphabeth(firstLetterItem);
                int lastLetterPosition = PositionInAlphabeth(lastLetterItem);

                //get the number from the string
                int number = GetTheNumberFromTheString(input);

                //calculations
                if (Char.IsUpper(firstLetterItem))
                {
                    totalSum += number * 1.0 / firstLetterPosition;
                }
                else
                {
                    totalSum += number * 1.0 * firstLetterPosition;
                }

                if (Char.IsUpper(lastLetterItem))
                {
                    totalSum -= lastLetterPosition;
                }
                else
                {
                    totalSum += lastLetterPosition;
                }

            }

            Console.WriteLine($"{totalSum:f2}");
        }

        private static int GetTheNumberFromTheString(string input)
        {
            //remove first and last symbol
            input=input.Remove(0, 1);
            input=input.Remove(input.Length - 1, 1);            
            int theNumber = int.Parse(input);
            return theNumber;
        }

        private static int PositionInAlphabeth(char firstLetterItem)
        {
            int position = (int)firstLetterItem % 32;
            return position;
        }
    }
}
