using System;
using System.Linq;

namespace Lab06EvenandOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int evenSum = 0;
            int oddSum = 0;

            foreach (int number in numbers)
            {
                

                _ = (number % 2 == 0) ? evenSum += number : oddSum += number;
            }

            

            Console.WriteLine(evenSum-oddSum);
        }
    }
}
