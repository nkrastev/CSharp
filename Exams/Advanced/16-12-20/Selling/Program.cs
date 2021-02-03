using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            //read matrix and find position of player
            var n = int.Parse(Console.ReadLine());
            var playerX = -1;
            var playerY = -1;
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row,col]=='S')
                    {
                        playerX = row;
                        playerY = col;
                    }
                }
            }

            var money = 0;
                        

            while (true)
            {
                //Console.WriteLine($"Player position {playerX} {playerY}");
                var command = Console.ReadLine();
                if (command== "up")
                {
                    if (playerX-1>=0)
                    {
                        //movement UP is possible
                        if (matrix[playerX-1, playerY]=='-')
                        {
                           
                            matrix[playerX - 1, playerY] = 'S';
                            matrix[playerX, playerY] = '-';
                            playerX -= 1;
                        }
                        else if (Char.IsDigit(matrix[playerX - 1, playerY]))
                        {
                            money += int.Parse(matrix[playerX - 1, playerY].ToString());                            
                            matrix[playerX - 1, playerY] = 'S';
                            matrix[playerX, playerY] = '-';
                            playerX -= 1;
                        }
                        else if (matrix[playerX - 1, playerY] == 'O')
                        {
                            matrix[playerX - 1, playerY] = '-';
                            matrix[playerX, playerY] = '-';
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';
                                        
                                        playerX = row;
                                        playerY = col;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        matrix[playerX, playerY] = '-';
                        break;                       
                    }
                }

                if (command == "down")
                {
                    if (playerX + 1 < n)
                    {
                        //movement UP is possible
                        if (matrix[playerX + 1, playerY] == '-')
                        {

                            matrix[playerX + 1, playerY] = 'S';
                            matrix[playerX, playerY] = '-';
                            playerX += 1;
                        }
                        else if (Char.IsDigit(matrix[playerX + 1, playerY]))
                        {
                            money += int.Parse(matrix[playerX + 1, playerY].ToString());
                            matrix[playerX + 1, playerY] = 'S';
                            matrix[playerX, playerY] = '-';
                            playerX += 1;
                        }
                        else if (matrix[playerX + 1, playerY] == 'O')
                        {
                            matrix[playerX + 1, playerY] = '-';
                            matrix[playerX, playerY] = '-';
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';

                                        playerX = row;
                                        playerY = col;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        matrix[playerX, playerY] = '-';
                        break;
                    }                    
                }

                if (command == "left")
                {
                    if (playerY - 1 >= 0)
                    {
                        
                        if (matrix[playerX, playerY-1] == '-')
                        {

                            matrix[playerX, playerY-1] = 'S';
                            matrix[playerX, playerY] = '-';
                            playerY -= 1;
                        }
                        else if (Char.IsDigit(matrix[playerX, playerY-1]))
                        {
                            money += int.Parse(matrix[playerX, playerY-1].ToString());
                            matrix[playerX, playerY-1] = 'S';
                            matrix[playerX, playerY] = '-';
                            playerY -= 1;
                        }
                        else if (matrix[playerX, playerY-1] == 'O')
                        {
                            matrix[playerX, playerY-1] = '-';
                            matrix[playerX, playerY] = '-';
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';

                                        playerX = row;
                                        playerY = col;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        matrix[playerX, playerY] = '-';
                        break;
                    }
                    
                }

                if (command == "right")
                {
                    if (playerY + 1 < n)
                    {

                        if (matrix[playerX, playerY + 1] == '-')
                        {

                            matrix[playerX, playerY + 1] = 'S';
                            matrix[playerX, playerY] = '-';
                            playerY += 1;
                        }
                        else if (Char.IsDigit(matrix[playerX, playerY + 1]))
                        {
                            money += int.Parse(matrix[playerX, playerY + 1].ToString());
                            matrix[playerX, playerY + 1] = 'S';
                            matrix[playerX, playerY] = '-';
                            playerY += 1;
                        }
                        else if (matrix[playerX, playerY + 1] == 'O')
                        {
                            matrix[playerX, playerY + 1] = '-';
                            matrix[playerX, playerY] = '-';
                            for (int row = 0; row < n; row++)
                            {
                                for (int col = 0; col < n; col++)
                                {
                                    if (matrix[row, col] == 'O')
                                    {
                                        matrix[row, col] = 'S';

                                        playerX = row;
                                        playerY = col;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        matrix[playerX, playerY] = '-';
                        break;
                    }

                }
                if (money>=50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    break;
                }
            }
            Console.WriteLine($"Money: {money}");
            PrintMatrix(matrix);
            
        }

        private static void PrintMatrix(char[,] matrix)
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
