using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05FootballTeamGenerator
{
    public class Player
    {
        private const string ERROR_EMPTYNAME = "A name should not be empty.";
        private const string ERROR_STATRANGE = "{0} should be between 0 and 100.";
        private string name;
        
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;

            if (endurance<0 || endurance>100)
            {
                throw new ArgumentException(String.Format(ERROR_STATRANGE, "Endurance"));
            }
            this.endurance = endurance;
            
            if (sprint < 0 || sprint > 100)
            {
                throw new ArgumentException(String.Format(ERROR_STATRANGE, "Sprint"));
            }
            this.sprint = sprint;

            if (dribble < 0 || dribble > 100)
            {
                throw new ArgumentException(String.Format(ERROR_STATRANGE, "Dribble"));
            }
            this.dribble = dribble;

            if (passing < 0 || passing > 100)
            {
                throw new ArgumentException(String.Format(ERROR_STATRANGE, "Passing"));
            }
            this.passing = passing;

            if (shooting < 0 || shooting > 100)
            {
                throw new ArgumentException(String.Format(ERROR_STATRANGE, "Shooting"));
            }
            this.shooting = shooting;

        }

        public string Name 
        {
            get=> this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ERROR_EMPTYNAME);
                }
                this.name = value;
            }
        }

        public double Stat
        {
            get => CalculateStat();
        }        

        private double CalculateStat() => (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0;
       
    }
}
