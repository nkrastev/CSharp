using System;
using System.Collections.Generic;
using System.Text;
using Cars.Contracts;

namespace Cars.Models
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;
        public Tesla(string model, string color, int battery)
        {
            this.Battery = battery;
            this.Color = color;
            this.Model = model;            
        }

        public int Battery { get => this.battery; set => this.battery=value; }
        public string Model { get => this.model; set => this.model = value; }
        public string Color { get => this.color; set => this.color = value; }


        public string Start()
        {
            return "Breaaak!";
        }

        public string Stop()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Seat {this.Model}");
            sb.AppendLine($"Engine start");
            sb.AppendLine(this.Start());
            return sb.ToString().TrimEnd();
        }
    }
}
