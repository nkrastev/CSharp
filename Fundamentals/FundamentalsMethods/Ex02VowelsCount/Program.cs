using System;
using System.Linq;

namespace Ex02VowelsCount
{
    class Program
    {
        static void Main()
        {
            string inputString = Console.ReadLine();
           

            PrintVowelCount(inputString);

        }

        static void PrintVowelCount(string input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //A, E, I, O, U
                if (input[i].ToString().ToLower() == "a" ||
                    input[i].ToString().ToLower() == "e" ||
                    input[i].ToString().ToLower() == "i" ||
                    input[i].ToString().ToLower() == "o" ||
                    input[i].ToString().ToLower() == "u")
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
