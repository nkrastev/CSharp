using System;
using System.Collections.Generic;
using System.Text;

namespace Ex08CarSalesman
{
    public class Car
    {
        //fields
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        //constructor
        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        //properties
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public int Weight { get; set; }
        public string Color { get; set; }

        public string ToString()
        {
            
            var engineEfficiency = this.Engine.Efficiency == null ? "n/a" : this.Engine.Efficiency;
            var carColor = this.Color == "" ? "n/a" : this.Color;

            StringBuilder sb = new StringBuilder();
            sb.Append(this.Model+":\n");
            sb.Append($"  {this.Engine.Model}:\n");
            sb.Append($"    Power: {this.Engine.Power}\n");
            
            if (this.Engine.Displacement == 0)
            {
                sb.Append(@$"    Displacement: n/a");
                sb.Append("\n");
            }
            else
            {
                sb.Append($"    Displacement: {this.Engine.Displacement}\n");
            }
            sb.Append($"    Efficiency: {engineEfficiency}\n");
            if (this.Weight==0)
            {
                sb.Append(@$"  Weight: n/a");
                sb.Append("\n");
            }
            else
            {
                sb.Append($"  Weight: {this.Weight}\n");
            }
            
            sb.Append($"  Color: {carColor}");

            return sb.ToString();
            
        }
    }
}
