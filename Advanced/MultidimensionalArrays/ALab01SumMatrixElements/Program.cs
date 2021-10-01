using System;
using System.Linq;

namespace ALab01SumMatrixElements
{
    class Program
    {
        static void Main()
        {
            var rowsCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = rowsCols[0];
            var cols = rowsCols[1];
            int[,] intMatrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var currentCol = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    intMatrix[i, j] = currentCol[j];
                }
            }
            var totalSum = 0;
            for (int row = 0; row < intMatrix.GetLength(0); row++)
            {
                var colSum = 0;
                for (int col = 0; col < intMatrix.GetLength(1); col++)
                {
                    colSum += intMatrix[row, col];
                }
                totalSum += colSum;
            }

            Console.WriteLine(intMatrix.GetLength(0));
            Console.WriteLine(intMatrix.GetLength(1));
            Console.WriteLine(totalSum);

        }
    }
}
