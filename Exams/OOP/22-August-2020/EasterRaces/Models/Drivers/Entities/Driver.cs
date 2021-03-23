using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;


        public Driver(string name)
        {
            this.Name = name;         
           
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {this.name} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public ICar Car
        {
            get => this.car;
            private set => this.car = value;
        }

        public int NumberOfWins
        {
            get => this.numberOfWins;
            private set => this.numberOfWins = value;
        }

        public bool CanParticipate
        {
            get => this.canParticipate;
            private set
            {
                //this.canParticipate = false;
                if (this.car != null)
                {
                    this.canParticipate = false;
                }
                else
                {
                    this.canParticipate = true;
                }
            }
        }

        public void AddCar(ICar car)
        {
            if (car==null)
            {
                throw new ArgumentException("Car cannot be null.");
            }
            this.Car = car;
            this.canParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
