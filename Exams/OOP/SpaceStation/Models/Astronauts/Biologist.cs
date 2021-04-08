using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {        
        private const double INIT_OXYGEN = 70;
        public Biologist(string name) 
            : base(name, INIT_OXYGEN)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= 15; // 10 from main class
            
            if (this.Oxygen<0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
