using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Regex regexCapitalLetters = new Regex(@"([#$%*&])([A-Z]+)\1");
            MatchCollection capLetters = regexCapitalLetters.Matches(input[0]);

            Regex regexWordsLenght = new Regex(@"[0-9]{2}:[0-9]{2}");
            MatchCollection wordsLenght = regexWordsLenght.Matches(input[1]);

            List<string> wordsPart3 = input[2].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();           

            string capLettersString = GetCapitalLetters(capLetters);
            for (int i = 0; i < capLettersString.Length; i++)
            {
                //Console.WriteLine(capLettersString[i]);
                char curCapitalLetter = capLettersString[i];
                //check for current capital letter in words lenght matches
                int curWordLenght = WordLenght(curCapitalLetter, wordsLenght);
                //check word starting with cur capital letter and word lenght = curWordLenght to check in list
                CheckConditionsAndPrintResult(wordsPart3, curWordLenght, curCapitalLetter);                
            }
        }

        private static void CheckConditionsAndPrintResult(List<string> wordsPart3, int curWordLenght, char curCapitalLetter)
        {
            for (int j = 0; j < wordsPart3.Count; j++)
            {
                if (wordsPart3[j].Length == curWordLenght && wordsPart3[j].StartsWith(curCapitalLetter))
                {
                    Console.WriteLine(wordsPart3[j]);
                }
            }
        }

        private static int WordLenght(char curCapitalLetter, MatchCollection wordsLenght)
        {
            int wordLenght = 0;
            foreach (Match item in wordsLenght)
            {
                //matches are in format 65:03
                string forSplit = item.ToString();
                int[] matchArray = forSplit.Split(":", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstNumber = matchArray[0];
                int secondNumber = matchArray[1];                
                if (firstNumber == (int)(curCapitalLetter))
                {
                    wordLenght = secondNumber;
                }
            }

            return wordLenght+1;
        }

        private static string GetCapitalLetters(MatchCollection capLetters)
        {
            string capLettersString = "";
            string newString = "";
            foreach (Match item in capLetters)
            {
                capLettersString = item.ToString();
            }
            for (int i = 0; i < capLettersString.Length; i++)
            {
                if (i != 0 && i != capLettersString.Length - 1)
                {
                    newString += capLettersString[i];
                }
            }
            return newString;
        }
    }
}