using System;
using System.Linq;

namespace ALab02SumMatrixColumns
{
    class Program
    {
        static void Main()
        {
            //input
            var size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var rows = size[0];
            var cols = size[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currentCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentCols[col];
                }
            }

            //output
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                var sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }

        }
    }
}
