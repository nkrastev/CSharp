using System;

namespace HelensAbduction
{
    class Program
    {
        static void Main()
        {
            var energy = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix();
            var findParis = Find(matrix, 'P');
            var findHelen = Find(matrix, 'H');
            var parisRow = findParis[0];
            var parisCol = findParis[1];
            var helenRow = findHelen[0];
            var helenCol = findHelen[1];

            bool success = false;

            while (true)
            {
                if (energy<=0)
                {
                    break;
                }
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);                
                //spawn enemy
                matrix[int.Parse(command[1]), int.Parse(command[2])] = 'S';
                //move Paris
                if (command[0]=="left")
                {
                    energy--;
                    if (parisRow==helenRow && parisCol-1==helenCol)
                    {
                        //Helen found, game over
                        success = true;
                        matrix[parisRow, parisCol] = '-';
                        matrix[helenRow, helenCol] = '-';
                        break;
                    }
                    else if (parisCol-1<0)
                    {
                        //goes outside, so remain at same position
                    }
                    else if (matrix[parisRow, parisCol - 1] =='S')
                    {
                        //fight with enemy
                        if (energy>2)
                        {
                            //defeat enemy
                            energy -= 2;
                            matrix[parisRow, parisCol - 1] = 'P';
                            matrix[parisRow, parisCol] = '-';
                            parisCol--;
                        }
                        else
                        {
                            //dies
                            matrix[parisRow, parisCol-1] = 'X';
                            matrix[parisRow, parisCol] = '-';
                            parisCol--;
                            break;
                        }
                    }
                    else
                    {
                        //regular move
                        matrix[parisRow, parisCol-1] = 'P';
                        matrix[parisRow, parisCol] = '-';
                        parisCol--;
                    }
                }

                if (command[0] == "right")
                {
                    energy--;
                    if (parisRow == helenRow && parisCol + 1 == helenCol)
                    {
                        //Helen found, game over
                        success = true;
                        matrix[parisRow, parisCol] = '-';
                        matrix[helenRow, helenCol] = '-';
                        break;
                    }
                    else if (parisCol + 1 == matrix.GetLength(1))
                    {
                        //goes outside, so remain at same position
                    }
                    else if (matrix[parisRow, parisCol + 1] == 'S')
                    {
                        //fight with enemy
                        if (energy > 2)
                        {
                            //defeat enemy
                            energy -= 2;
                            matrix[parisRow, parisCol + 1] = 'P';
                            matrix[parisRow, parisCol] = '-';
                            parisCol++;
                        }
                        else
                        {
                            //dies
                            matrix[parisRow, parisCol + 1] = 'X';
                            matrix[parisRow, parisCol] = '-';
                            parisCol++;
                            break;
                        }
                    }
                    else
                    {
                        //regular move
                        matrix[parisRow, parisCol + 1] = 'P';
                        matrix[parisRow, parisCol] = '-';
                        parisCol++;
                    }
                }

                if (command[0] == "up")
                {
                    energy--;
                    if (parisRow-1 == helenRow && parisCol == helenCol)
                    {
                        //Helen found, game over
                        success = true;
                        matrix[parisRow, parisCol] = '-';
                        matrix[helenRow, helenCol] = '-';
                        break;
                    }
                    else if (parisRow - 1 < 0)
                    {
                        //goes outside, so remain at same position
                    }
                    else if (matrix[parisRow-1, parisCol] == 'S')
                    {
                        //fight with enemy
                        if (energy > 2)
                        {
                            //defeat enemy
                            energy -= 2;
                            matrix[parisRow-1, parisCol] = 'P';
                            matrix[parisRow, parisCol] = '-';
                            parisRow--;
                        }
                        else
                        {
                            //dies
                            matrix[parisRow-1, parisCol] = 'X';
                            matrix[parisRow, parisCol] = '-';
                            parisRow--;
                            break;
                        }
                    }
                    else
                    {
                        //regular move
                        matrix[parisRow-1, parisCol] = 'P';
                        matrix[parisRow, parisCol] = '-';
                        parisRow--;
                    }
                }

                if (command[0] == "down")
                {
                    energy--;
                    if (parisRow + 1 == helenRow && parisCol == helenCol)
                    {
                        //Helen found, game over
                        success = true;
                        matrix[parisRow, parisCol] = '-';
                        matrix[helenRow, helenCol] = '-';
                        break;
                    }
                    else if (parisRow + 1 == matrix.GetLength(0))
                    {
                        //goes outside, so remain at same position
                    }
                    else if (matrix[parisRow + 1, parisCol] == 'S')
                    {
                        //fight with enemy
                        if (energy > 2)
                        {
                            //defeat enemy
                            energy -= 2;
                            matrix[parisRow + 1, parisCol] = 'P';
                            matrix[parisRow, parisCol] = '-';
                            parisRow++;
                        }
                        else
                        {
                            //dies
                            matrix[parisRow + 1, parisCol] = 'X';                            
                            matrix[parisRow, parisCol] = '-';
                            parisRow++;
                            break;
                        }
                    }
                    else
                    {
                        //regular move
                        matrix[parisRow + 1, parisCol] = 'P';
                        matrix[parisRow, parisCol] = '-';
                        parisRow++;
                    }
                }


                //condition for end
                if (energy<=0)
                {
                    matrix[parisRow, parisCol] = 'X';
                }
                
                //Print(matrix);
                //Console.WriteLine($"Energy: {energy}");
            }
            Console.WriteLine("-----------------");
            if (success)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            }
            else
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }
            Print(matrix);
        }


        private static int[] Find(char[,] matrix, char searched)
        {
            int[] positions = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]==searched)
                    {
                        positions[0] = row;
                        positions[1] = col;
                    }
                }
            }
            return positions;
        }

        private static char[,] ReadMatrix()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            return matrix;
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
