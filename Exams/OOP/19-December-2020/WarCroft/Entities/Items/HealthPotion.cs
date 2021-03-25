using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion() : 
            base(5)
        {
        }

        public void AffectCharacter(Character character)
        {
            //For an item to affect a character, the character needs to be alive.
            //The character’s health gets increased by 20 points.
            if (character.IsAlive)
            {
                character.Health += 20;
            }
        }
    }
}
