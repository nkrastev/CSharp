using System;
using System.Linq;

namespace Ex05SnakeMoves
{
    class Program
    {
        static void Main()
        {
            var dimensions = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var snake = Console.ReadLine();
            var rows = dimensions[0];
            var cols = dimensions[1];
            char[,] matrix = new char[rows,cols];
            var position = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row%2==0)
                {
                    //if even from first to start
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[position];
                        position++;
                        position = IndexRewinder(snake, position);
                    }
                }
                else
                {
                    //if odd backwards
                    for (int col = cols-1; col >=0; col--)
                    {
                        matrix[row, col] = snake[position];
                        position++;
                        position=IndexRewinder(snake, position);
                    }
                }
                
            }
            //output
            PrintMatrix(matrix);
                        
        }

        private static int IndexRewinder(string snake, int position)
        {           
            if (position>=snake.Length)
            {
                position = 0;
                return position;
            }
            else
            {
                return position;
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
