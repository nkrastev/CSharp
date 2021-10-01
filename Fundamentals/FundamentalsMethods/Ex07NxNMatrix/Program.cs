using System;

namespace Ex07NxNMatrix
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            PrintMatrix(number);
        }

        static void PrintMatrix(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(n+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
