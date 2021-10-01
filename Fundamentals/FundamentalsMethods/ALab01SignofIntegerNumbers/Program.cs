using System;
using System.Linq;

namespace ALabTasks
{
    class Program
    {
        static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(Calculations(firstNumber,operation,secondNumber));

        }

        static double Calculations(double num1, char operation, double num2)
        {
            double result = 0;

            switch (operation)
            {
                case '+':
                    {
                        result = num1 + num2;
                        break;
                    }
                case '-':
                    {
                        result = num1 - num2;
                        break;
                    }
                case '*':
                    {
                        result = num1 * num2;
                        break;
                    }
                case '/':
                    {
                        result = num1 / num2;
                        break;
                    }

            }

            return result;            
        }
       

    }
}
