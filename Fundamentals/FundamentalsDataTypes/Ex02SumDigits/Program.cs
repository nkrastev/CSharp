using System;

namespace Ex02SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            //You will be given a single integer. Your task is to find the sum of its digits.

            int number = int.Parse(Console.ReadLine());

            int sumOfDigits = 0;
            
            while (number != 0)
            {
                sumOfDigits = sumOfDigits + number % 10;
                number = number / 10;
            }

            Console.WriteLine(sumOfDigits);

        }
    }
}
