using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = ReadMatrix();
            int maxSum = int.MinValue;
            int maxRow = int.MinValue;
            int maxCol = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    //calculate sum for the square with current coordinates
                    int currentSum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                    if (currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            //output
            Console.WriteLine(matrix[maxRow,maxCol]+" "+matrix[maxRow,maxCol+1]);
            Console.WriteLine(matrix[maxRow+1,maxCol]+" "+matrix[maxRow+1,maxCol+1]);
            Console.WriteLine(maxSum);

        }



        public static int[,] ReadMatrix()
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
            return intMatrix;
        }
            
    }
}
