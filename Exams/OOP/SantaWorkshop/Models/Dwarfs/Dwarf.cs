using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;
        private List<IInstrument> instruments;

        public Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.instruments = new List<IInstrument>();
        }

        public string Name 
        { 
            get => name; 
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }
                this.name = value;
            }
        }

        public int Energy
        {
            //TODO CHECK Property for possible errors
            get => energy;
            protected set
            {
                if (value<0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }                
            }
        }

        public ICollection<IInstrument> Instruments => this.Instruments;

        public void AddInstrument(IInstrument instrument)
        {
            this.instruments.Add(instrument);
        }

        public abstract void Work();        
    }
}
