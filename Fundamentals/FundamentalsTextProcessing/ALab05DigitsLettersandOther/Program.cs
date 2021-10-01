using System;
using System.Collections.Generic;

namespace ALab05DigitsLettersandOther
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<char> digits = new List<char>();
            List<char> letters = new List<char>();
            List<char> others = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    digits.Add(input[i]);
                }
                else if(Char.IsLetter(input[i]))
                {
                    letters.Add(input[i]);
                }
                else
                {
                    others.Add(input[i]);
                }
            }

            Console.WriteLine(String.Join("",digits));
            Console.WriteLine(String.Join("",letters));
            Console.WriteLine(String.Join("",others));
        }
    }
}
