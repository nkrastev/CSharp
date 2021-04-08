using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private readonly IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Bag();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value<0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                this.oxygen = value;
            }
        }


        public bool CanBreath => this.Oxygen > 0;

        //o	A property of type Backpack???
        public IBag Bag => this.bag;

        public virtual void Breath()
        {
            this.oxygen -= 10;
            if (this.oxygen<=0)
            {
                this.oxygen = 0;                
            }
        }
    }
}
