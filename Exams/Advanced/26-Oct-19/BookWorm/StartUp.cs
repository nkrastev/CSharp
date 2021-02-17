using System;

namespace BookWorm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var initialString = Console.ReadLine();
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size,size];

            var playerRow = -1;
            var playerCol = -1;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col]=='P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            var command = Console.ReadLine();

            while (command!="end")
            {
                //going up
                if (command=="up")
                {
                    if (playerRow>0)
                    {
                        //move is valid
                        if (Char.IsLetter(matrix[playerRow - 1, playerCol]))
                        {
                            initialString += matrix[playerRow - 1, playerCol].ToString();
                            matrix[playerRow - 1, playerCol] = 'P';
                            matrix[playerRow, playerCol] = '-';
                            playerRow--;
                        }
                        else
                        {
                            matrix[playerRow - 1, playerCol] = 'P';
                            matrix[playerRow, playerCol] = '-';
                            playerRow--;
                        }
                    }
                    else
                    {
                        //invalid movement, eat from the string if any
                        if (initialString.Length>0)
                        {
                            initialString = initialString.Remove(initialString.Length - 1);
                        }                        
                    }
                }
                //going down
                if (command == "down")
                {
                    if (playerRow < matrix.GetLength(0)-1)
                    {
                        //move is valid
                        if (Char.IsLetter(matrix[playerRow + 1, playerCol]))
                        {
                            initialString += matrix[playerRow + 1, playerCol].ToString();
                            matrix[playerRow + 1, playerCol] = 'P';
                            matrix[playerRow, playerCol] = '-';
                            playerRow++;
                        }
                        else
                        {
                            matrix[playerRow + 1, playerCol] = 'P';
                            matrix[playerRow, playerCol] = '-';
                            playerRow++;
                        }
                    }
                    else
                    {
                        //invalid movement, eat from the string if any
                        if (initialString.Length > 0)
                        {
                            initialString = initialString.Remove(initialString.Length - 1);
                        }
                    }
                }

                //going Left
                if (command == "left")
                {
                    if (playerCol > 0)
                    {
                        //move is valid
                        if (Char.IsLetter(matrix[playerRow, playerCol-1]))
                        {
                            initialString += matrix[playerRow, playerCol-1].ToString();
                            matrix[playerRow, playerCol-1] = 'P';
                            matrix[playerRow, playerCol] = '-';
                            playerCol--;
                        }
                        else
                        {
                            matrix[playerRow, playerCol-1] = 'P';
                            matrix[playerRow, playerCol] = '-';
                            playerCol--;
                        }
                    }
                    else
                    {
                        //invalid movement, eat from the string if any
                        if (initialString.Length > 0)
                        {
                            initialString = initialString.Remove(initialString.Length - 1);
                        }
                    }
                }

                //going Left
                if (command == "right")
                {
                    if (playerCol < matrix.GetLength(1)-1)
                    {
                        //move is valid
                        if (Char.IsLetter(matrix[playerRow, playerCol + 1]))
                        {
                            initialString += matrix[playerRow, playerCol + 1].ToString();
                            matrix[playerRow, playerCol + 1] = 'P';
                            matrix[playerRow, playerCol] = '-';
                            playerCol++;
                        }
                        else
                        {
                            matrix[playerRow, playerCol + 1] = 'P';
                            matrix[playerRow, playerCol] = '-';
                            playerCol++;
                        }
                    }
                    else
                    {
                        //invalid movement, eat from the string if any
                        if (initialString.Length > 0)
                        {
                            initialString = initialString.Remove(initialString.Length - 1);
                        }
                    }
                }
                //Console.WriteLine(initialString);
                //Print(matrix);
                //print current output                             
                command = Console.ReadLine();
            }
            Console.WriteLine(initialString);
            Print(matrix);

        }

        private static void Print(char[,] matrix)
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
