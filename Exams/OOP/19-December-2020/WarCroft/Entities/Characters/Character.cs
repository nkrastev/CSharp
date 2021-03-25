using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {        
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public Bag Bag
        {
            get => this.bag;
            protected set => this.bag = value;
        }

        public double AbilityPoints
        {
            get => this.abilityPoints;
            protected set
            {                
                this.abilityPoints = value;
            }
        }
        public double Armor
        {
            get => this.armor;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("o	Armor – the current amount of armor left – can not be less than 0");
                }
                this.armor = value;
            }
        }
        public double BaseArmor
        {
            get => this.baseArmor;
            protected set
            {
                this.baseArmor = value;
            }
        }

        public double Health
        {
            get => this.health;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("o	Health (current health) should never be more than the BaseHealth or less than 0. ");
                }
                this.health = value;
            }
        }
        public double BaseHealth 
        {
            get => this.baseHealth;
            protected set
            {
                this.baseHealth = value;
            }
        }
        public string Name
        {
            get { return this.name; }
            protected set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            /*The character’s armor is reduced by the hit point amount, then if there are still hit points left, they take that amount of health damage.
            If the character’s health drops to zero, the character dies(IsAlive become false)
            Example: Health: 100, Armor: 30, Hit Points: 40  Health: 90, Armor: 0*/
            if (this.armor>=hitPoints)
            {
                this.armor -= hitPoints;
            }
            else if (this.armor<hitPoints)
            {
                hitPoints -= this.armor;
                this.armor = 0;
                if (this.health>hitPoints)
                {
                    this.health -= hitPoints;
                }
                else
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
            }
        }
        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
        }

        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}