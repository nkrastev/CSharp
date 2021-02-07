using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var snakeRow = -1;
            var snakeCol = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row,col]=='S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            var foodEaten = 0;
            var snakeOutside = false;


            while (foodEaten<10)
            {
                var command = Console.ReadLine();

                //move up
                if (command=="up")
                {
                    if (isValid(matrix, command, snakeRow, snakeCol))
                    {
                        if (matrix[snakeRow-1, snakeCol]=='*')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow - 1, snakeCol] = 'S';
                            foodEaten++;
                            snakeRow--;
                        }
                        else if (matrix[snakeRow - 1, snakeCol] == '-' || matrix[snakeRow - 1, snakeCol] == '.')
                        {                            
                            matrix[snakeRow - 1, snakeCol] = 'S';
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow--;
                        }
                        else if (matrix[snakeRow - 1, snakeCol] == 'B')
                        {
                            matrix[snakeRow - 1, snakeCol] = '.';
                            matrix[snakeRow, snakeCol] = '.';
                            //transfer to the next B
                            snakeRow--;
                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    if (matrix[row,col]=='B')
                                    {
                                        matrix[row, col] = 'S';
                                        snakeRow = row;
                                        snakeCol = col;
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        snakeOutside = true;
                        break;
                    }
                }
                //move down
                if (command == "down")
                {
                    if (isValid(matrix, command, snakeRow, snakeCol))
                    {
                        if (matrix[snakeRow + 1, snakeCol] == '*')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow + 1, snakeCol] = 'S';
                            foodEaten++;
                            snakeRow++;
                        }
                        else if (matrix[snakeRow + 1, snakeCol] == '-' || matrix[snakeRow + 1, snakeCol] == '.')
                        {
                            matrix[snakeRow + 1, snakeCol] = 'S';
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow++;
                        }
                        else if (matrix[snakeRow + 1, snakeCol] == 'B')
                        {
                            matrix[snakeRow + 1, snakeCol] = '.';
                            matrix[snakeRow, snakeCol] = '.';
                            //transfer to the next B
                            snakeRow++;
                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        matrix[row, col] = 'S';
                                        snakeRow = row;
                                        snakeCol = col;
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        snakeOutside = true ;
                        break;
                    }
                }
                //left
                if (command == "left")
                {
                    if (isValid(matrix, command, snakeRow, snakeCol))
                    {
                        if (matrix[snakeRow , snakeCol-1] == '*')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow , snakeCol-1] = 'S';
                            foodEaten++;
                            snakeCol--;
                        }
                        else if (matrix[snakeRow, snakeCol-1] == '-' || matrix[snakeRow, snakeCol - 1] == '.')
                        {
                            matrix[snakeRow, snakeCol-1] = 'S';
                            matrix[snakeRow, snakeCol] = '.';
                            snakeCol--;
                        }
                        else if (matrix[snakeRow, snakeCol-1] == 'B')
                        {
                            matrix[snakeRow, snakeCol-1] = '.';
                            matrix[snakeRow, snakeCol] = '.';
                            //transfer to the next B
                            snakeCol--;
                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        matrix[row, col] = 'S';
                                        snakeRow = row;
                                        snakeCol = col;
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        snakeOutside = true;
                        break;
                    }
                }
                //right
                if (command == "right")
                {
                    if (isValid(matrix, command, snakeRow, snakeCol))
                    {
                        if (matrix[snakeRow, snakeCol + 1] == '*')
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, snakeCol + 1] = 'S';
                            foodEaten++;
                            snakeCol++;
                        }
                        else if (matrix[snakeRow, snakeCol + 1] == '-' || matrix[snakeRow, snakeCol + 1] == '.')
                        {
                            matrix[snakeRow, snakeCol + 1] = 'S';
                            matrix[snakeRow, snakeCol] = '.';
                            snakeCol++;
                        }
                        else if (matrix[snakeRow, snakeCol + 1] == 'B')
                        {
                            matrix[snakeRow, snakeCol + 1] = '.';
                            matrix[snakeRow, snakeCol] = '.';
                            //transfer to the next B
                            snakeCol++;
                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    if (matrix[row, col] == 'B')
                                    {
                                        matrix[row, col] = 'S';
                                        snakeRow = row;
                                        snakeCol = col;
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        snakeOutside = true;
                        break;
                    }
                }

                //Print(matrix);
                //Console.WriteLine($"Food {foodEaten}");

            }
            if (snakeOutside==true)
            {
                matrix[snakeRow, snakeCol] = '.';
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodEaten}");

            Print(matrix);
        }

        private static bool isValid(char[,] matrix, string direction, int snakeRow, int snakeCol)
        {
            bool movementIsPossible = false;
            if (direction=="up" && snakeRow-1>=0 && snakeRow-1<matrix.GetLength(0) )
            {
                movementIsPossible = true;
            }
            if (direction == "down" && snakeRow + 1 >= 0 && snakeRow + 1 < matrix.GetLength(0))
            {
                movementIsPossible = true;
            }
            if (direction == "left" && snakeCol -1 >= 0 && snakeCol - 1 < matrix.GetLength(0))
            {
                movementIsPossible = true;
            }
            if (direction == "right" && snakeCol + 1 >= 0 && snakeCol + 1 < matrix.GetLength(0))
            {
                movementIsPossible = true;
            }
            return movementIsPossible;
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
