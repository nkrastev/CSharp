using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {       
            //Possible errors!!!

            while (astronauts.Any(x=>x.CanBreath))
            {                
                IAstronaut theExplorer = astronauts.FirstOrDefault(x => x.CanBreath);
                while (theExplorer.CanBreath)
                {
                    //collect items
                    while (planet.Items.Count>0)
                    {
                        var item = planet.Items.FirstOrDefault();
                        theExplorer.Bag.Items.Add(item);
                        theExplorer.Breath();
                        planet.Items.Remove(item);
                    }
                }
            }
        }
    }
}
