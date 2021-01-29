using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");

            var lines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < lines; i++)
            {

                var cmdArgs = Console.ReadLine().Split();
                try
                {
                    var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));
                    team.AddPlayer(person);                    
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);

                }             
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");


        }
    }
}
