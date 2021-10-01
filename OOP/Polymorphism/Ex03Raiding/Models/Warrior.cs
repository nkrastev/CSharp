using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name, string type) : base(name)
        {
          
            this.Name = name;
            this.Type = type;
            this.Power = 100;
        }

        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
    }
}
