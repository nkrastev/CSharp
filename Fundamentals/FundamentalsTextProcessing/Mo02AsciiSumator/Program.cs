using System;

namespace Mo02AsciiSumator
{
    class Program
    {
        static void Main()
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();
         
            SumAndPrint(input, start, end);
            
        }

        static void SumAndPrint(string[] input, char start, char end)
        {
            int totalSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > start && input[i] < end)
                {
                    totalSum += (int)input[i];
                }
            }

            Console.WriteLine(totalSum);
        }


    }
}
