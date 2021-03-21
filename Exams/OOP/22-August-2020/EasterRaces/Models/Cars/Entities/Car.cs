using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get => this.Model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length<4)
                {
                    throw new ArgumentException($"Model {this.Model} cannot be less than 4 symbols.");
                }
                this.Model = value;
            }
        }

        public int HorsePower
        {
            get => this.HorsePower;
            private set => this.HorsePower = value;
        }

        public double CubicCentimeters
        {
            get => this.CubicCentimeters;
            private set => this.CubicCentimeters = value;
        }

        public double CalculateRacePoints(int laps) => this.CubicCentimeters / this.HorsePower * laps;
        
    }
}
