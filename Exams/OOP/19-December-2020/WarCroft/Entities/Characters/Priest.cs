using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name) : 
            base(name, 50, 25, 40, new Backpack())
        {
            //50 Base Health, 25 Base Armor, 40 Ability Points, and a Backpack as a bag.
            this.Name = name;
            this.BaseArmor = 25;
            this.BaseHealth = 50;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                //If this is true, the receiving character’s health increases by the healer’s ability points.
                character.Health += this.AbilityPoints;
            }
        }
    }
}
