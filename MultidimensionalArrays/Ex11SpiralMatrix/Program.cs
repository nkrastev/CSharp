using System;

namespace Ex11SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //spiral matrix is always square

            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            var direction = "right";
            var row = 0;
            var col = 0;

            for (int i = 0; i < n*n; i++)
            {
                matrix[row, col] = i + 1;
                if (direction=="right")
                {
                    col++;
                }
                if (direction=="left")
                {
                    col--;
                }
                if (direction=="up")
                {
                    row--;
                }
                if (direction=="down")
                {
                    row++;
                }

                //checks and change direction

                if ((col==n || IsOccupied(matrix, row, col)) && direction=="right")
                {
                    col--;
                    row++;
                    direction ="down";
                }
                if ((row == n || IsOccupied(matrix, row, col)) && direction == "down")
                {
                    row--;
                    col--;
                    direction = "left";
                }
                if ((col == -1 || IsOccupied(matrix, row, col)) && direction == "left")
                {
                    row--;
                    col++;
                    direction = "up";
                }
                if ((row == -1 || IsOccupied(matrix, row, col)) && direction == "up")
                {
                    row++;
                    col++;
                    direction = "right";
                }
            }

            PrintMatrix(matrix);
            
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool IsOccupied(int[,] matrix, int row, int col)
        {
            return
                row >= 0 &&
                col >= 0 &&
                row < matrix.GetLength(0) &&
                col < matrix.GetLength(0) &&
                matrix[row, col] != 0;
        }
    }
}
