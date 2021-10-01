using System;

namespace Ex08FactorialDivision
{
    class Program
    {
        static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine($"{CalcFactorial(firstNumber)/CalcFactorial(secondNumber):f2}");
            
        }

        static double CalcFactorial(double n)
        {
            double result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
