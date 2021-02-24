using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name, string type) : base(name)
        {
          
            this.Name = name;
            this.Type = type;
            this.Power = 80;
        }
        public override string CastAbility() => $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";       
    }
}
