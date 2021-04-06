using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        public CivilPlayer(string name) 
            : base(name, 50)
        {
        }
    }
}
