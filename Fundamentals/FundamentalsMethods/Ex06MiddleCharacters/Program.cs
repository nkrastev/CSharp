using System;

namespace Ex06MiddleCharacters
{
    class Program
    {
        static void Main()
        {
            string inputString = Console.ReadLine();

            PrintMiddleCharacter(inputString);            
        }

        static void PrintMiddleCharacter(string input)
        {
            //aaString
            if (input.Length % 2==0)
            {
                char first = input[input.Length / 2 - 1];
                char second = input[input.Length / 2];
                Console.WriteLine($"{first}{second}");                              
            }
            else
            {
                Console.WriteLine(input[input.Length / 2]); 
            }
        }
    }
}
