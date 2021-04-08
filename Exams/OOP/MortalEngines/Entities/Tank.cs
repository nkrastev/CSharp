using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double INIT_HEALTHPOINTS = 100;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, INIT_HEALTHPOINTS)
        {
            this.DefenseMode = true;

        }

        public bool DefenseMode
        {
            get;
            private set;
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            var mode = (this.DefenseMode) ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Defense: {mode}";
        }
    }
}
