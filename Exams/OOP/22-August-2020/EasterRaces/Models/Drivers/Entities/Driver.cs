using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {

        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.Name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {this.Name} cannot be less than 5 symbols.");
                }
                this.Name = value;
            }
        }

        public ICar Car
        {
            get => this.Car;
            private set => this.Car = value;
        }

        public int NumberOfWins
        {
            get => this.NumberOfWins;
            private set => this.NumberOfWins = value;
        }

        public bool CanParticipate
        {
            get => this.CanParticipate;
            private set
            {
                this.CanParticipate = false;
                //if (this.Car!=null)
                //{
                //    this.CanParticipate = false;
                //}
                //else
                //{
                //    this.CanParticipate = true;
                //}
            }
        }

        public void AddCar(ICar car)
        {
            if (car==null)
            {
                throw new ArgumentException("Car cannot be null.");
            }
            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
