using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Gun cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int BulletsCount
        {
            get => bulletsCount;
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException("Bullets cannot be below 0.");
                }
                this.bulletsCount = value;
            }
        }

        public abstract int Fire();        
    }
}
