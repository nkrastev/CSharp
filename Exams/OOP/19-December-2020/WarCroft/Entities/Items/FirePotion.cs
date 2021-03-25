using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        public FirePotion() : 
            base(5)
        {
        }

        public void AffectCharacter(Character character)
        {
            //For an item to affect a character, the character needs to be alive.
            //The character’s health gets decreased by 20 points.If the character’s health drops to zero, the character dies(IsAlive  false).
            if (character.IsAlive)
            {
                character.Health -= 20;
                if (character.Health<=0)
                {
                    character.IsAlive = true;
                }
            }
        }
    }
}
