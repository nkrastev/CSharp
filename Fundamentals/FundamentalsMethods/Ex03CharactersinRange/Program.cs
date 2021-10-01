using System;

namespace Ex03CharactersinRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char startChar = char.Parse(Console.ReadLine());
            char endChar = char.Parse(Console.ReadLine());

            PrintCharsBetween(startChar, endChar);
        }

        static void PrintCharsBetween(char starting, char ending)
        {
            // check for the first value in ASCII
            if ((int)starting> (int)ending)
            {
                int temp = (int)starting;
                starting = ending;
                ending = (char)temp;
            }

            for (int i = (int)starting+1; i < (int)ending; i++)
            {
                Console.Write((char)i+" ");
            }            
        }
    }
}
