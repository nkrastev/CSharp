using System;
using System.Linq;

namespace ALab04SymbolinMatrix
{
    class Program
    {
        static void Main()
        {
            //input
            var sizeOfSquareMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeOfSquareMatrix, sizeOfSquareMatrix];
            //read matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            //read symbol
            var symbol = char.Parse(Console.ReadLine());
            var isFound = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (symbol == matrix[row, col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                    if (isFound)
                    {
                        break;
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
