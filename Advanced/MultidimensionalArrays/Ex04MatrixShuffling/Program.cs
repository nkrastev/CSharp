using System;
using System.Linq;

namespace Ex04MatrixShuffling
{
    class Program
    {
        static void Main()
        {
            string[,] matrix = ReadMatrix();
            string instructions = Console.ReadLine();

            while (instructions != "END")
            {
                bool isCommandValid = InstructionsValidator(instructions, matrix);
                if (isCommandValid)
                {
                    string[] command = instructions.Split(" ").ToArray();
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);
                    string tempValue = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = tempValue;
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                instructions = Console.ReadLine();
            }
            

        }

        private static void PrintMatrix(string[,] matrix)
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

        private static bool InstructionsValidator(string instructions, string[,] matrix)
        {
            bool isValid=false;
            string[] command = instructions.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (
                    command.Length==5 &&
                    command[0]=="swap" &&
                    int.Parse(command[1])<matrix.GetLength(0)&&
                    int.Parse(command[2])<matrix.GetLength(1)&&
                    int.Parse(command[3])<matrix.GetLength(0)&&
                    int.Parse(command[4])<matrix.GetLength(1)
                )
            {
                isValid = true;
            }


            return isValid;
        }

        public static string[,] ReadMatrix()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            string[,] stringMatrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var currentCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    stringMatrix[i, j] = currentCol[j];
                }
            }
            return stringMatrix;
        }
    }
}
