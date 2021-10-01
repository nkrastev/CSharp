using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Models
{
    public class Seat : ICar
    {
        private string model;
        private string color;
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get => this.model; set => this.model=value; }
        public string Color { get => this.color; set => this.color=value; }
        
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
