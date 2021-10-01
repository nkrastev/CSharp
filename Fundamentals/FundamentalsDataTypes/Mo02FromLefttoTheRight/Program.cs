using System;
using System.Numerics;

namespace Mo02FromLefttoTheRight
{
    class Program
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');

                if (long.Parse(numbers[0])>long.Parse(numbers[1]))
                {
                    CalculateAndPrintSumOfDigits(numbers[0]);
                }
                else
                {
                    CalculateAndPrintSumOfDigits(numbers[1]);
                }
                
                
            }
        }

        static void CalculateAndPrintSumOfDigits(string numberWithDigits)
        {
            long number = Math.Abs(long.Parse(numberWithDigits));
            int sumOfDigits = 0;
            while (number != 0)
            {
                sumOfDigits = (int)(sumOfDigits + number % 10);
                number = number / 10;
            }
            Console.WriteLine(sumOfDigits);
        }
    }
}
