using System;

namespace Ex01SmallestofThreeNumbers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = new int[3];
            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            PrintSmallest(numbers);
        }

        static void PrintSmallest(int[] arrNumbers)
        {
            Array.Sort(arrNumbers);
            Console.WriteLine(arrNumbers[0]);
        }
    }
}
