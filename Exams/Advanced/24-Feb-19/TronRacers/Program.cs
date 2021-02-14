using System;
using System.Linq;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadMatrix();
            Print(matrix);

            //starting positions of the players int[] with row, col
            var first = FindPlayer(matrix, 'f');
            var second = FindPlayer(matrix, 's');
            var isWinner = string.Empty;
           
            while (true)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                //move first player with first command
                if (commands[0]=="up")
                {
                    if (first[0]==0)
                    {
                        //player is on the top, will appear at the bottom
                        first[0] = matrix.GetLength(0) - 1;
                        if (matrix[first[0], first[1]] == '*')
                        {
                            matrix[first[0], first[1]] = 'f';
                        }
                        else if (matrix[first[0],first[1]]=='s')
                        {
                            matrix[first[0], first[1]] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        first[0]--;
                        if (matrix[first[0], first[1]] == '*')
                        {
                            matrix[first[0], first[1]] = 'f';
                        }
                        else if (matrix[first[0], first[1]] == 's')
                        {
                            matrix[first[0], first[1]] = 'x';
                            break;
                        }
                    }
                }
                if (commands[1]=="up")
                {
                    if (second[0] == 0)
                    {
                        //player is on the top, will appear at the bottom
                        second[0] = matrix.GetLength(0) - 1;
                        if (matrix[second[0], second[1]] == '*')
                        {
                            matrix[second[0], second[1]] = 's';
                        }
                        else if (matrix[second[0], second[1]] == 'f')
                        {
                            matrix[second[0], second[1]] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        second[0]--;
                        if (matrix[second[0], second[1]] == '*')
                        {
                            matrix[second[0], second[1]] = 's';
                        }
                        else if (matrix[second[0], second[1]] == 'f')
                        {
                            matrix[second[0], second[1]] = 'x';
                            break;
                        }
                    }
                }

                if (commands[0] == "down")
                {
                    if (first[0] == matrix.GetLength(0)-1)
                    {
                        //player is on the bottom, will appear at the top
                        first[0] = 0;
                        if (matrix[first[0], first[1]] == '*')
                        {
                            matrix[first[0], first[1]] = 'f';
                        }
                        else if (matrix[first[0], first[1]] == 's')
                        {
                            matrix[first[0], first[1]] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        first[0]++;
                        if (matrix[first[0], first[1]] == '*')
                        {
                            matrix[first[0], first[1]] = 'f';
                        }
                        else if (matrix[first[0], first[1]] == 's')
                        {
                            matrix[first[0], first[1]] = 'x';
                            break;
                        }
                    }
                }
                if (commands[1] == "down")
                {
                    if (second[0] == matrix.GetLength(0)-1)
                    {
                        //player is on the top, will appear at the bottom
                        second[0] = 0;
                        if (matrix[second[0], second[1]] == '*')
                        {
                            matrix[second[0], second[1]] = 's';
                        }
                        else if (matrix[second[0], second[1]] == 'f')
                        {
                            matrix[second[0], second[1]] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        second[0]++;
                        if (matrix[second[0], second[1]] == '*')
                        {
                            matrix[second[0], second[1]] = 's';
                        }
                        else if (matrix[second[0], second[1]] == 'f')
                        {
                            matrix[second[0], second[1]] = 'x';
                            break;
                        }
                    }
                }

                if (commands[0] == "left")
                {
                    if (first[1] == 0)
                    {
                        //player is on the left end, will appear at the right end
                        first[1] = matrix.GetLength(0) - 1;
                        if (matrix[first[0], first[1]] == '*')
                        {
                            matrix[first[0], first[1]] = 'f';
                        }
                        else if (matrix[first[0], first[1]] == 's')
                        {
                            matrix[first[0], first[1]] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        first[1]--;
                        if (matrix[first[0], first[1]] == '*')
                        {
                            matrix[first[0], first[1]] = 'f';
                        }
                        else if (matrix[first[0], first[1]] == 's')
                        {
                            matrix[first[0], first[1]] = 'x';
                            break;
                        }
                    }
                }
                if (commands[1] == "left")
                {
                    if (second[1] == 0)
                    {
                        //player is on the top, will appear at the bottom
                        second[1] = matrix.GetLength(0) - 1;
                        if (matrix[second[0], second[1]] == '*')
                        {
                            matrix[second[0], second[1]] = 's';
                        }
                        else if (matrix[second[0], second[1]] == 'f')
                        {
                            matrix[second[0], second[1]] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        second[1]--;
                        if (matrix[second[0], second[1]] == '*')
                        {
                            matrix[second[0], second[1]] = 's';
                        }
                        else if (matrix[second[0], second[1]] == 'f')
                        {
                            matrix[second[0], second[1]] = 'x';
                            break;
                        }
                    }
                }

                if (commands[0] == "right")
                {
                    if (first[1] == matrix.GetLength(1)-1)
                    {
                        //player is on the right end, will appear at the left end
                        first[1] = 0;
                        if (matrix[first[0], first[1]] == '*')
                        {
                            matrix[first[0], first[1]] = 'f';
                        }
                        else if (matrix[first[0], first[1]] == 's')
                        {
                            matrix[first[0], first[1]] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        first[1]++;
                        if (matrix[first[0], first[1]] == '*')
                        {
                            matrix[first[0], first[1]] = 'f';
                        }
                        else if (matrix[first[0], first[1]] == 's')
                        {
                            matrix[first[0], first[1]] = 'x';
                            break;
                        }
                    }
                }
                if (commands[1] == "right")
                {
                    if (second[1] == matrix.GetLength(1)-1)
                    {
                        //player is on the top, will appear at the bottom
                        second[1] = 0;
                        if (matrix[second[0], second[1]] == '*')
                        {
                            matrix[second[0], second[1]] = 's';
                        }
                        else if (matrix[second[0], second[1]] == 'f')
                        {
                            matrix[second[0], second[1]] = 'x';
                            break;
                        }
                    }
                    else
                    {
                        second[1]++;
                        if (matrix[second[0], second[1]] == '*')
                        {
                            matrix[second[0], second[1]] = 's';
                        }
                        else if (matrix[second[0], second[1]] == 'f')
                        {
                            matrix[second[0], second[1]] = 'x';
                            break;
                        }
                    }
                }

                
            }
            Print(matrix);
            


        }        

        private static int[] FindPlayer(char[,] matrix, char player)
        {
            var arr = new int[2];
            arr[0] = -1;
            arr[1] = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col]==player)
                    {
                        arr[0] = row;
                        arr[1] = col;
                    }
                }
            }
            return arr;
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]+" ");
                }
                Console.WriteLine();
            }
        }

        private static char[,] ReadMatrix()
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size, size];
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
