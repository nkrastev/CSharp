using System;
using System.Linq;

namespace ALab06Jagged_ArrayModification
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = ReadMatrix();

            var instructions = Console.ReadLine();
            while (instructions != "END")
            {
                var command = instructions.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "Add")
                {
                    var row = int.Parse(command[1]);
                    var col = int.Parse(command[2]);
                    var value = int.Parse(command[3]);
                    AddValueToMatrix(matrix, row, col, value);
                }
                if (command[0] == "Subtract")
                {
                    var row = int.Parse(command[1]);
                    var col = int.Parse(command[2]);
                    var value = int.Parse(command[3]);
                    SubstractValueToMatrix(matrix, row, col, value);
                }
                instructions = Console.ReadLine();
            }

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] SubstractValueToMatrix(int[,] matrix, int row, int col, int value)
        {
            if (
                row > matrix.GetLength(0) - 1 ||
                col > matrix.GetLength(1) - 1 ||
                row < 0 ||
                col <0
                )
            {
                Console.WriteLine("Invalid coordinates");
            }
            else
            {
                matrix[row, col] -= value;
            }
            return matrix;
        }
        private static int[,] AddValueToMatrix(int[,] matrix, int row, int col, int value)
        {
            if (
                row>matrix.GetLength(0)-1|| 
                col>matrix.GetLength(1)-1 ||
                row < 0 ||
                col < 0)
            {
                Console.WriteLine("Invalid coordinates");
            }
            else
            {
                matrix[row, col] += value;
            }
            return matrix;
        }

        public static int[,] ReadMatrix()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var rows = matrixSize;
            var cols = matrixSize;
            int[,] intMatrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var currentCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    intMatrix[i, j] = currentCol[j];
                }
            }
            return intMatrix;
        }
    }
}
