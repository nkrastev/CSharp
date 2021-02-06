using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrixRows = size[0];
            var matrixCols = size[1];

            int[,] matrix = new int[matrixRows, matrixCols]; // by default there are 0
            

            var command = Console.ReadLine();
            while (command!= "Bloom Bloom Plow")
            {
                var cmdAgrs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (cmdAgrs[0]>=matrix.GetLength(0) || cmdAgrs[0]<0 || cmdAgrs[1]>=matrix.GetLength(1) || cmdAgrs[1]<0)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    PlantFlower(matrix, cmdAgrs[0], cmdAgrs[1]);
                }
                
                command = Console.ReadLine();
            }
            Print(matrix);

        }

        private static int[,] PlantFlower(int[,] matrix, int plantRow, int plantCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row==plantRow || col==plantCol)
                    {
                        matrix[row, col]++;
                    }
                }
            }
            return matrix;
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
