using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {this.GetType().Name} cannot be less than 4 symbols.");
                }
                this.model = value;
            }
        }

        public virtual int HorsePower
        {
            get;protected set;
        }

        public virtual double CubicCentimeters
        {
            get;protected set;
        }

        public double CalculateRacePoints(int laps) => this.CubicCentimeters / this.HorsePower * laps *1.0;
    }
}
