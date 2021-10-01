using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05TeamworkProjects
{
    class Program
    {
        static void Main()
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<Team> listOfTeams = new List<Team>();
            List<string> membersList = new List<string>();            

            //input teams
            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] teamsInput = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
                // new instance of team object
                Team teamItem = new Team(teamsInput[0], teamsInput[1], membersList);

                Console.WriteLine($"Team {teamItem.Name} has been created by {teamItem.Creator}!");
                listOfTeams.Add(teamItem);
            }

            //input members
            string[] membersInput= Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (membersInput[0]!= "end of assignment")
            {
                string currentMemberName = membersInput[0];
                string currentMemberTeam = membersInput[1];

                //finding position in the object list where to insert current member to
                int positionOfTeam=listOfTeams.FindIndex(x => x.Name == currentMemberTeam);
                
                listOfTeams[positionOfTeam].Members.Add(currentMemberName);

                membersInput = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            //output
            foreach (Team item in listOfTeams)
            {
                Console.WriteLine("Team: "+item.Name+" > "+item.Creator+" members: "+String.Join("/",item.Members));
            }

            

        }
    }

    class Team
    {
        //constructor
        public Team(string teamName, string creator, List<string> members)
        {
            Name = teamName;
            Creator = creator;
            Members = members;
        }
        //properties
        public string Name { get; set; }
        public string Creator { get; set; }           
        public List<string> Members { get; set; }
    }

   
}
