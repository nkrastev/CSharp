using System;

namespace Ex04SumofChars
{
    class Program
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int totalSum=0;

            for (int i = 0; i < numberOfLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                totalSum += (int)(letter);
            }
            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
