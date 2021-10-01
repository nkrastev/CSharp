using System;

namespace Ex05TriplesofLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            //print all triples of the first n small Latin letters

            int numberOfLetters = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLetters; i++)
            {
                for (int j = 0; j < numberOfLetters; j++)
                {
                    for (int k = 0; k < numberOfLetters; k++)
                    {
                        char firstSymbol = (char)(i+97);
                        char secondSymbol = (char)(j + 97);
                        char thirdSymbol = (char)(k + 97);
                        Console.WriteLine($"{firstSymbol}{secondSymbol}{thirdSymbol}");
                    }
                }
            }


        }
    }
}
