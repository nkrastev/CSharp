using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData.Models
{
    public class Car
    {

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, 
            double tire1Pressure, int tire1Age, 
            double tire2Pressure, int tire2Age, 
            double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age)
        {
            this.model = model;
            this.engine = new Engine(engineSpeed, enginePower);
            this.cargo = new Cargo(cargoWeight, cargoType);
            this.tires = new Tire[] 
            {
                new Tire(tire1Pressure, tire1Age),
                new Tire(tire2Pressure, tire2Age),
                new Tire(tire3Pressure, tire3Age),
                new Tire(tire4Pressure, tire4Age)
            };
        }

        public string model;

        public Engine engine;

        public Cargo cargo;

        public Tire[] tires;

    }
}
