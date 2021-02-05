using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        //fields
        public Player(string name, string @class)
        {
            this.Name=name;
            this.Class=@class;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        //prop
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description{ get; set; }

        //method
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();            
            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");
            return sb.ToString().TrimEnd();
        }
    }
}
