using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05FootballTeamGenerator
{
    public class Team
    {
        private const string ERROR_EMPTYNAME = "A name should not be empty.";

        private string name;
        private double rating;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name 
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ERROR_EMPTYNAME);
                }
                this.name = value;
            }
        }
        
        public int Rating
        {
            get
            {
                if (players.Count>0)
                {
                    return (int)Math.Round((players.Sum(x => x.Stat) / players.Count));
                }
                else
                {
                    return 0;
                }
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public bool RemovePlayer(string playerName)
        {
            if (players.Any(x=>x.Name==playerName))
            {
                players.RemoveAll(x => x.Name == playerName);
                return true;
            }
            return false;
        }

    }
}
