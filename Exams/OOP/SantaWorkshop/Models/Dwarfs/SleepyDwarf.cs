using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        public SleepyDwarf(string name)
            : base(name, 50)
        {
        }

        public override void Work()
        {
            this.Energy -= 15;
        }
    }
}
