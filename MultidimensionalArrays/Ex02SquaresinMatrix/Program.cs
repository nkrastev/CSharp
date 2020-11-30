using System;
using System.Linq;

namespace Ex02SquaresinMatrix
{
    class Program
    {
        static void Main()
        {
            char[,] matrix = ReadMatrix();
            int squares = CheckMatrix(matrix);
            Console.WriteLine(squares);    
        }

        private static int CheckMatrix(char[,] matrix)
        {
            var result = 0;
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (
                        matrix[row,col]==matrix[row+1,col] &&
                        matrix[row,col]==matrix[row+1,col+1]&&
                        matrix[row,col]==matrix[row,col+1]
                        )
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public static char[,] ReadMatrix()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            char[,] intMatrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var currentCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    intMatrix[i, j] = currentCol[j];
                }
            }
            return intMatrix;
        }
    }
}
