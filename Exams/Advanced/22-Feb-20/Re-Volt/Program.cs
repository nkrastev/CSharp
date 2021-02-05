using System;

namespace ReVolt
{
    class Program
    {
        static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var commandsCount = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix(matrixSize);

            //start moving in the matrix by commands
            for (int i = 0; i < commandsCount; i++)
            {
                var cmd = Console.ReadLine();
                if (cmd=="up")
                {
                    MoveUp(matrix);                    
                }
                else if (cmd=="down")
                {
                    MoveDown(matrix);                    
                }
                else if (cmd=="left")
                {
                    MoveLeft(matrix);                    
                }
                else if (cmd=="right")
                {
                    MoveRight(matrix);                    
                }
                if (CheckIfWin(matrix))
                {
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    break;
                }
            }
            if (!CheckIfWin(matrix))
            {
                Console.WriteLine("Player lost!");
                PrintMatrix(matrix);
            }



        }

        private static char[,] MoveRight(char[,] matrix)
        {
            var playerRow = FindPlayerRow(matrix);
            var playerCol = FindPlayerCol(matrix);
            matrix[playerRow, playerCol] = '-';
            
            if (playerCol == matrix.GetLength(0) - 1)
            {
                playerCol = 0;
            }
            else
            {
                playerCol++;
            }            
            if (matrix[playerRow, playerCol] == 'T')
            {
                //Console.WriteLine("Trap, move to old coordinates left");
                if (playerCol ==0)
                {
                    playerCol =matrix.GetLength(0)-1;
                }
                else
                {
                    playerCol--;
                }
            }
            else if (matrix[playerRow, playerCol] == 'B')
            {
                //Console.WriteLine("Bonus, move again RIGHT");
                if (playerCol +1 ==matrix.GetLength(0))
                {
                    playerCol = 0;
                }
                else
                {
                    playerCol++;
                }
            }
            matrix[playerRow, playerCol] = 'f';
            //PrintMatrix(matrix);
            return matrix;
        }

        private static char[,] MoveLeft(char[,] matrix)
        {
            var playerRow = FindPlayerRow(matrix);
            var playerCol = FindPlayerCol(matrix);
            matrix[playerRow, playerCol] = '-';
            //Console.WriteLine($"Start Position of Player is at Row {playerRow}, Col {playerCol}. Movement is LEFT");
            if (playerCol==0)
            {
                playerCol = matrix.GetLength(0)-1;
            }
            else
            {
                playerCol --;
            }
            //Console.WriteLine($"Player is at Row {playerRow}, Col {playerCol}");            
            if (matrix[playerRow, playerCol] == 'T')
            {
                //Console.WriteLine("Trap, move to old coordinates right");
                if (playerCol+1==matrix.GetLength(0))
                {
                    playerCol = 0;
                }
                else
                {
                    playerCol++;
                }
            }
            else if (matrix[playerRow, playerCol] == 'B')
            {
                //Console.WriteLine("Bonus, move again LEFT");
                if (playerCol == 0)
                {
                    playerCol = matrix.GetLength(0) - 1;
                }
                else
                {
                    playerCol--;
                }
            }
            matrix[playerRow, playerCol] = 'f';
            //PrintMatrix(matrix);
            return matrix;
        }

        private static char[,] MoveDown(char[,] matrix)
        {
            var playerRow = FindPlayerRow(matrix);
            var playerCol = FindPlayerCol(matrix);
            matrix[playerRow, playerCol] = '-';
            //Console.WriteLine($"Start Position of Player is at Row {playerRow}, Col {playerCol}. Movement is UP");
            if (playerRow + 1 == matrix.GetLength(1))
            {
                playerRow = 0;                
            }
            else
            {
                playerRow += 1;
            }
            //Console.WriteLine($"Player is at Row {playerRow}, Col {playerCol}");            
            if (matrix[playerRow, playerCol] == 'T')
            {
                //Console.WriteLine("Trap, move to old coordinates down");
                if (playerRow - 1 == matrix.GetLength(1))
                {
                    playerRow = 0;
                }
                else
                {
                    playerRow--;
                }
            }
            else if (matrix[playerRow, playerCol] == 'B')
            {
                //Console.WriteLine("Bonus, move again down");
                if (playerRow + 1 ==matrix.GetLength(1))
                {
                    playerRow = 0;
                }
                else
                {
                    playerRow += 1;
                }
            }
            matrix[playerRow, playerCol] = 'f';
            //PrintMatrix(matrix);
            return matrix;
        }

        private static char[,] MoveUp(char[,] matrix)
        {
            var playerRow = FindPlayerRow(matrix);
            var playerCol = FindPlayerCol(matrix);
            matrix[playerRow, playerCol] = '-';
            //Console.WriteLine($"Start Position of Player is at Row {playerRow}, Col {playerCol}. Movement is UP");
            if (playerRow-1<0)
            {
                playerRow = matrix.GetLength(1) - 1;                
            }
            else
            {
                playerRow -= 1;                
            }            
            //Console.WriteLine($"Player is at Row {playerRow}, Col {playerCol}");            
            if (matrix[playerRow, playerCol]=='T')
            {
                //Console.WriteLine("Trap, move to old coordinates down");
                if (playerRow+1==matrix.GetLength(1))
                {
                    playerRow = matrix.GetLength(1) - 1;
                }
                else
                {
                    playerRow++;
                }                
            }
            else if (matrix[playerRow, playerCol] == 'B')
            {
                //Console.WriteLine("Bonus, move again up");
                if (playerRow - 1 < 0)
                {
                    playerRow = matrix.GetLength(1) - 1;
                }
                else
                {
                    playerRow -= 1;
                }                
            }
            matrix[playerRow, playerCol] = 'f';
            //PrintMatrix(matrix);
            return matrix;
        }

        private static int FindPlayerRow(char[,] matrix)
        {
            var x = 0;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    if (matrix[row,col]=='f')
                    {
                        x = row;
                        break;
                    }
                }
            }
            return x;
        }

        private static int FindPlayerCol(char[,] matrix)
        {
            var y = 0;
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        y = col;
                        break;
                    }
                }
            }
            return y;
        }

        private static char[,] ReadMatrix(int n)
        {            
            var matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine(); ;
            }
        }

        private static bool CheckIfWin(char[,] matrix)
        {
            bool isWon = true;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'F')
                    {
                        isWon = false;
                        break;
                    }
                }
                if (isWon == false)
                {
                    break;
                }
            }
            return isWon;
        }
    }
}
