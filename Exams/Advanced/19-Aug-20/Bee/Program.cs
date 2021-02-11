using System;

namespace Bee
{
    class Program
    {
        static void Main()
        {
            var matrix = ReadMatrix();
            var command = Console.ReadLine();
            var getLost = false;
            var beeRow = GetBeeRow(matrix);
            var beeCol = GetBeeCol(matrix);
            var pollinatedFlowers = 0;

            

            while (command!="End")
            {                
                if (command=="up")
                {
                    if (beeRow - 1 >= 0)
                    {
                        //bee can move
                        if (matrix[beeRow-1, beeCol]=='f')
                        {
                            pollinatedFlowers++;                            
                        }                        
                        if (matrix[beeRow - 1, beeCol]=='O')
                        {
                            if (matrix[beeRow - 2, beeCol] == 'f')
                            {
                                pollinatedFlowers++;                                
                            }
                            matrix[beeRow - 1, beeCol] = 'B';
                            matrix[beeRow, beeCol] = '.';
                            beeRow -= 1;
                        }
                        matrix[beeRow - 1, beeCol] = 'B';
                        matrix[beeRow, beeCol] = '.';
                        beeRow -= 1;
                    }
                    else
                    {
                        matrix[beeRow, beeCol] = '.';
                        getLost = true; break;
                    }
                }
                if (command == "down")
                {
                    if (beeRow + 1 < matrix.GetLength(1))
                    {
                        //bee can move
                        if (matrix[beeRow + 1, beeCol] == 'f')
                        {
                            pollinatedFlowers++;
                        }
                        if (matrix[beeRow + 1, beeCol] == 'O')
                        {
                            if (matrix[beeRow + 2, beeCol] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            matrix[beeRow + 1, beeCol] = 'B';
                            matrix[beeRow, beeCol] = '.';
                            beeRow += 1;
                        }
                        matrix[beeRow + 1, beeCol] = 'B';
                        matrix[beeRow, beeCol] = '.';
                        beeRow += 1;
                    }
                    else
                    {
                        matrix[beeRow, beeCol] = '.';
                        getLost = true; break;
                    }
                }

                if (command == "left")
                {
                    if (beeCol - 1 >= 0)
                    {
                        //bee can move
                        if (matrix[beeRow, beeCol-1] == 'f')
                        {
                            pollinatedFlowers++;
                        }
                        if (matrix[beeRow, beeCol-1] == 'O')
                        {
                            if (matrix[beeRow, beeCol-2] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            matrix[beeRow, beeCol-1] = 'B';
                            matrix[beeRow, beeCol] = '.';
                            beeCol -= 1;
                        }
                        matrix[beeRow, beeCol-1] = 'B';
                        matrix[beeRow, beeCol] = '.';
                        beeCol -= 1;
                    }
                    else
                    {
                        matrix[beeRow, beeCol] = '.';
                        getLost = true; break;
                    }
                }

                if (command == "right")
                {
                    if (beeCol + 1 < matrix.GetLength(1))
                    {
                        //bee can move
                        if (matrix[beeRow, beeCol+1] == 'f')
                        {
                            pollinatedFlowers++;
                        }
                        if (matrix[beeRow, beeCol+1] == 'O')
                        {
                            if (matrix[beeRow, beeCol+2] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            matrix[beeRow, beeCol+1] = 'B';
                            matrix[beeRow, beeCol] = '.';
                            beeCol += 1;
                        }
                        matrix[beeRow, beeCol+1] = 'B';
                        matrix[beeRow, beeCol] = '.';
                        beeCol += 1;
                    }
                    else
                    {
                        matrix[beeRow, beeCol] = '.';
                        getLost = true; break;
                    }
                }
                               
                command = Console.ReadLine();
            }


            if (getLost)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (pollinatedFlowers>=5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinatedFlowers} flowers more");
            }
            PrintMatrix(matrix);
        }

        

        private static int GetBeeCol(char[,] matrix)
        {
            var beeCol = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beeCol = col;
                        break;
                    }
                }
            }
            return beeCol;
        }

        private static int GetBeeRow(char[,] matrix)
        {
            var beeRow = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]=='B')
                    {
                        beeRow = row;
                        break;
                    }
                }                
            }
            return beeRow;
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

        private static char[,] ReadMatrix()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size,size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            return matrix;
        }
    }
}
