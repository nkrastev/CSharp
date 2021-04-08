using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INIT_HEALTHPOINTS = 200;
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, INIT_HEALTHPOINTS)
        {
            this.AggressiveMode = true;
        }
        public bool AggressiveMode
        {
            get;
            private set;
        }

        public void ToggleAggressiveMode()
        {           
            if (this.AggressiveMode==true)
            {
                this.AggressiveMode = false;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            var mode = (this.AggressiveMode) ? "ON" : "OFF";
            return base.ToString()+Environment.NewLine+$" *Aggressive: {mode}";
        }
    }
}
