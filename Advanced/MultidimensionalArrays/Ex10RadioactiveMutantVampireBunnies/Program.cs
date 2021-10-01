using System;
using System.Linq;

namespace Ex10RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main()
        {
            char[,] lair = ReadLair();
            var commands = Console.ReadLine();
            var positionPlayer = FindPlayer(lair); // format 3,4
            StartMoving(lair, commands, positionPlayer);
            
        }

        private static void StartMoving(char[,] lair, string commands, string positionPlayer)
        {
            var player = positionPlayer.Split(",").Select(int.Parse).ToArray();
            var playerRow = player[0];
            var playerCol = player[1];
            var escaped = false;
            var died = false;
            for (int i = 0; i < commands.Length; i++)
            {
                //player movement               
                if (commands[i]=='U')
                {
                    if (playerRow==0)
                    {
                        escaped = true;                        
                    }
                    else
                    {
                        lair[playerRow, playerCol] = '.';
                        playerRow -= 1;
                        if (lair[playerRow, playerCol] == 'B')
                        {
                            died = true;
                        }
                        else
                        {
                            lair[playerRow, playerCol] = 'P';
                        }
                    }
                }
                if (commands[i]=='D')
                {
                    if (playerRow+1==lair.GetLength(0))
                    {
                        escaped = true;
                    }
                    else
                    {
                        lair[playerRow, playerCol] = '.';
                        playerRow += 1;
                        if (lair[playerRow, playerCol] == 'B')
                        {
                            died = true;
                        }
                        else
                        {
                            lair[playerRow, playerCol] = 'P';
                        }
                    }
                }
                if (commands[i]=='L')
                {
                    if (playerCol==0)
                    {

                        escaped = true;
                    }
                    else
                    {
                        lair[playerRow, playerCol] = '.';
                        playerCol -= 1;
                        if (lair[playerRow, playerCol] == 'B')
                        {
                            died = true;
                        }
                        else
                        {
                            lair[playerRow, playerCol] = 'P';
                        }
                    }
                }
                if (commands[i]=='R')
                {
                    if (playerCol+1==lair.GetLength(1))
                    {
                        escaped = true;
                    }
                    else
                    {
                        lair[playerRow, playerCol] = '.';
                        playerCol += 1;
                        if (lair[playerRow, playerCol] == 'B')
                        {
                            died = true;
                        }
                        else
                        {
                            lair[playerRow, playerCol] = 'P';
                        }                        
                    }
                }
                //clone the rabits and check for player positions then check escaped and died values
                char[,] spread = new char [lair.GetLength(0),lair.GetLength(1)];
                
                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row,col]=='B')
                        {
                            if (row>=1)
                            {
                                spread[row - 1, col] = 'B'; //spread left
                            }
                            if (row<lair.GetLength(0)-1)
                            {
                                spread[row + 1, col] = 'B';//spread right
                            }
                            if (col>=1)
                            {
                                spread[row, col - 1] = 'B';//spread up
                            }
                            if (col<lair.GetLength(1)-1)
                            {
                                spread[row, col + 1] = 'B';//spread down
                            }
                            spread[row, col] = 'B';
                        }
                        else
                        {
                            if (spread[row, col]!='B')
                            {
                                spread[row, col] = '.';
                            }
                            
                        }
                    }
                }
                //spread is the new matrix with bunnies contamination

                //player moved, bunnies spread, check if died or escaped
                if (spread[playerRow,playerCol]=='B')
                {
                    died = true;
                    lair = spread;
                    break;
                }
                else
                {
                    //revert back spread to lair and set player position;
                    lair = spread;
                    lair[playerRow, playerCol] = 'P';
                }
                if (escaped)
                {
                    lair[playerRow, playerCol] = '.';
                    break;
                }
                
            }
            //print outpu
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row,col]);
                }
                Console.WriteLine();
            }
            if (died)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            if (escaped)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
        }

        private static string FindPlayer(char[,] lair)
        {
            var player = string.Empty;
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row,col]=='P')
                    {
                        player = row.ToString() + ',' + col;
                    }
                }
            }
            return player;
        }

        private static char[,] ReadLair()
        {
            var lairSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();           
            char[,] lair = new char[lairSize[0], lairSize[1]];
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                var currentCol = Console.ReadLine();
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    lair[i, j] = currentCol[j];
                }
            }
            return lair;
        }
    }
}
