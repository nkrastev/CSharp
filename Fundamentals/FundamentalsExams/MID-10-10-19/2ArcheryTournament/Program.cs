using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _2ArcheryTournament
{
    class Program
    {
        static void Main()
        {
            int[] targets = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int points = 0;

            string command = Console.ReadLine();

            while (command!= "Game over")
            {                
                if (command.StartsWith("Shoot"))
                {
                    //array splitted by @
                    string[] commandArr = command.Split("@", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    int startIndex = int.Parse(commandArr[1]);
                    int lenght = int.Parse(commandArr[2]);
                    if (commandArr[0]== "Shoot Left")
                    {
                        //shoot left
                        if (startIndex>=0 && startIndex<targets.Length )
                        {
                            //index is valid
                            int indexToShoot = startIndex - lenght;
                            while (indexToShoot<0)
                            {
                                int temp = indexToShoot;
                                indexToShoot = targets.Length + temp;                                
                            }
                            if (targets[indexToShoot]>=5)
                            {
                                targets[indexToShoot] -= 5;
                                points += 5;
                            }
                            else
                            {
                                points += targets[indexToShoot];
                                targets[indexToShoot] = 0;
                            }
                        }

                    }
                    if (commandArr[0] == "Shoot Right")
                    {
                        //shoot right
                        if (startIndex >= 0 && startIndex < targets.Length)
                        {
                            //index is valid Shoot Right@4@5
                            int indexToShoot = startIndex + lenght;
                            while (indexToShoot > targets.Length-1)
                            {
                                int temp = indexToShoot;
                                indexToShoot = temp-targets.Length;
                            }
                            if (targets[indexToShoot] >= 5)
                            {
                                targets[indexToShoot] -= 5;
                                points += 5;
                            }
                            else
                            {
                                points += targets[indexToShoot];
                                targets[indexToShoot] = 0;
                            }
                        }
                    }
                }

                if (command== "Reverse")
                {
                    Array.Reverse(targets);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" - ",targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
