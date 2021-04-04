using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {            
            var terrorists = players.Where(x => x.GetType().Name == "Terrorist").ToList();
            var counterTerrorists = players.Where(x => x.GetType().Name == "CounterTerrorist").ToList();          

            while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive))
            {                
                //each terrorist shoot at whole CounterT collection and vice versa.. until one of the collection is full with bodies :D

                foreach (var terrorist in terrorists.Where(x => x.IsAlive))
                {
                    foreach (var counterTerrorist in counterTerrorists.Where(x => x.IsAlive))
                    {
                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());                        
                    }                    
                }
                foreach (var counterTerrorist in counterTerrorists.Where(x => x.IsAlive))
                {
                    foreach (var terrorist in terrorists.Where(x => x.IsAlive))
                    {
                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }                
            }

            if (terrorists.Any(x => !x.IsAlive))
            {
                return "Counter Terrorist wins!";
            }
            else
            {
                return "Terrorist wins!";
            }
            
        }
    }
}
