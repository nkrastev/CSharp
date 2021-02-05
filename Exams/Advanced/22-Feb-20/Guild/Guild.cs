using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        //fields
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        //prop
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return this.roster.Count; } }

        //methods
        public void AddPlayer(Player player)
        {
            if (roster.Count < this.Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.Find(x => x.Name == name);
            if (player != null)
            {
                roster.Remove(player);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PromotePlayer(string name)
        {
            //promote (set his rank to "Member") the first player with the given name. If the player is already a "Member", do nothing
            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Name == name)
                {
                    if (roster[i].Rank != "Member")
                    {
                        roster[i].Rank = "Member";
                    }
                }
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var item in roster)
            {
                sb.AppendLine(item.ToString());   
            }
            return sb.ToString().TrimEnd();
        }

        public void DemotePlayer(string name)
        {
            //demote (set his rank to "Trial") the first player with the given name. If the player is already a "Trial",  do nothing
            for (int i = 0; i < roster.Count; i++)
            {
                if (roster[i].Name==name)
                {
                    if (roster[i].Rank != "Trial")
                    {
                        roster[i].Rank = "Trial";
                    }
                }                
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {            
            var arr = roster.Where(x => x.Class == @class).ToArray();
            roster = roster.Where(x => x.Class != @class).ToList();
            return arr.ToArray();
        }
    }
}
