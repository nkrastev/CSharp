using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05FootballTeamGenerator
{
    public class Engine
    {
        public void Run()
        {
            List<Team> listOfTeams = new List<Team>();

            while (true)
            {
                var command = Console.ReadLine();
                if (command=="END")
                {
                    break;
                }
                try
                {
                    var cmdArgs = command.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (cmdArgs[0] == "Team")
                    {
                        Team team = new Team(cmdArgs[1]);
                        listOfTeams.Add(team);
                    }
                    else if (cmdArgs[0] == "Add")
                    {                       
                        string nameOfTeam = cmdArgs[1];
                        if (listOfTeams.Any(x=>x.Name==nameOfTeam))
                        {
                            //team exist, continue creating player
                            Player player = new Player(
                                cmdArgs[2],
                                int.Parse(cmdArgs[3]),
                                int.Parse(cmdArgs[4]),
                                int.Parse(cmdArgs[5]),
                                int.Parse(cmdArgs[6]),
                                int.Parse(cmdArgs[7]));
                            //adding player to corresponding team
                            listOfTeams.Where(x => x.Name == nameOfTeam).FirstOrDefault().AddPlayer(player);                            
                        }
                        else
                        {
                            Console.WriteLine($"Team {nameOfTeam} does not exist.");
                        }
                    }
                    else if (cmdArgs[0]== "Remove")
                    {
                        var teamName = cmdArgs[1];
                        var playerName = cmdArgs[2];

                        if (listOfTeams.Any(x=>x.Name==teamName))
                        {
                            //team exist, check if player can be removed
                            if (!listOfTeams.Where(x => x.Name == teamName).FirstOrDefault().RemovePlayer(playerName))
                            {
                                Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                            }
                            else
                            {
                                listOfTeams.Where(x => x.Name == teamName).FirstOrDefault().RemovePlayer(playerName);
                            }
                        }

                    }
                    else if (cmdArgs[0]== "Rating")
                    {
                        var teamName = cmdArgs[1];
                        if (listOfTeams.Any(x=>x.Name==teamName))
                        {
                            //show stat
                            Console.WriteLine($"{teamName} - {listOfTeams.Where(x => x.Name == teamName).FirstOrDefault().Rating}");                            
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }            
            }
            //output
            //PrintData(listOfTeams);
        }

        public void PrintData(List<Team> list)
        {
            foreach (var team in list)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine(team.Rating);
            }
        }
    }
}
