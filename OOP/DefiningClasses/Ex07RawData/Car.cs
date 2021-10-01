using System;
using System.Collections.Generic;
using System.Text;

namespace Ex07RawData
{
    public class Car
    {
        //fields
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        //constructor
        public Car (string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        //properties
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

    }
}
