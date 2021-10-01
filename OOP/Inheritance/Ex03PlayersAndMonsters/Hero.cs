using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        //fields
        private string username;
        private int level;

        //ctor
        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        //prop
        public string Username { get; set; }
        public int Level { get; set; }

        //methods
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
