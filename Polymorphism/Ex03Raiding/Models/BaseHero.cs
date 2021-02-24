using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03Raiding.Models
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {            
            this.Name = name;            
        }
        public string Name { get; set; }

        public string Type { get; set; }
        public int Power { get; set; }

        public abstract string CastAbility();
        
    }
}
