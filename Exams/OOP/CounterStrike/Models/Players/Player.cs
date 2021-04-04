using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private bool isAlive;
        private IGun gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get => username;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                this.username = value;
            }
        }

        public int Health
        {
            get => health; 
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Player health cannot be below or equal to 0.");
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get => armor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player armor cannot be below 0.");
                }
                this.armor = value;
            }
        }

        public IGun Gun
        {
            get => this.gun;
            private set
            {
                if (value==null)
                {
                    throw new ArgumentException("Gun cannot be null or empty.");
                }
                this.gun = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (this.health>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void TakeDamage(int points)
        {          
            if (this.Armor>=points)
            {
                this.Armor -= points;
            }
            else if (this.Armor<points)
            {
                points -= this.Armor;
                this.Armor = 0;

                if (this.Health>points)
                {
                    this.Health -= points;
                }
                else
                {
                    this.Health = 0;
                    this.isAlive = false;
                }
            }
        }
    }
}
