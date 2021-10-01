using System;
using System.Linq;

namespace ALab03PrimaryDiagonal
{
    class Program
    {
        static void Main()
        {
            //input
            var sizeOfSquareMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfSquareMatrix, sizeOfSquareMatrix];
            //read matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            //go throught matrix and sum elements
            var sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == row)
                    {
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
