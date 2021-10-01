using System;

namespace Ex01IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());
            int number4 = int.Parse(Console.ReadLine());

            //Add first to the second, divide(integer) the sum by the third number and multiply the result by the fourth number.
            int result = number1 + number2;
            result = result / number3;
            result = result * number4;

            Console.WriteLine(result);
        }
    }
}
