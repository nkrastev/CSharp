using System;

namespace Ex05AddandSubtract
{
    class Program
    {
        static void Main()
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            
            Console.WriteLine(Subtract(number3, Sum(number1, number2)));

        }
        static int Sum(int first, int second)
        {            
            int theSum = first + second;
            return theSum;
        }

        static int Subtract(int third, int resultFromSum)
        {
            int result = resultFromSum - third;
            return result;
        }

    }
}
