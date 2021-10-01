using System;

namespace Mo03RecursiveFibonacci
{
    class Program
    {
        static void Main()
        {
            int wantedPositionNumber = int.Parse(Console.ReadLine());

            //•	The output should be the n’th Fibonacci number counting from 1.

            Console.WriteLine(GetFibonacci(wantedPositionNumber));

        }

        static int GetFibonacci(int number)
        {
            if (number <= 1)
            {
                return number;
            }
            else
            {
                return GetFibonacci(number - 1) + GetFibonacci(number - 2);
            }
        }
    }
}
