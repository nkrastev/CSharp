using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        //fields
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        //prop
        public string Name { get; set; }
        public int Count { get => this.gladiators.Count; }

        //methods
        public void Add(Gladiator gladiator) => this.gladiators.Add(gladiator);       

        public void Remove(string name)// – removes an gladiator by given name
        {
            Gladiator gladiator = gladiators.Find(x => x.Name == name);
            // ? check if exist, remove by index
            gladiators.Remove(gladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()=> gladiators.OrderByDescending(x => x.GetStatPower()).FirstOrDefault();            
        public Gladiator GetGladitorWithHighestWeaponPower()=> gladiators.OrderByDescending(x => x.GetWeaponPower()).FirstOrDefault();            
        public Gladiator GetGladitorWithHighestTotalPower()=> gladiators.OrderByDescending(x => x.GetTotalPower()).FirstOrDefault();

        public override string ToString() => $"[{this.Name}] - [{this.Count}] gladiators are participating.";
    }
}
