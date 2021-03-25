using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name) : 
            base(name, 100, 50, 40, new Satchel())
        {
            this.BaseHealth = 100;
            this.BaseArmor = 50;            
        }

        public void Attack(Character character)
        {                       
            if (character==this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            if (this.IsAlive && character.IsAlive)
            {
                character.TakeDamage(this.AbilityPoints);
            }

        }
    }
}
