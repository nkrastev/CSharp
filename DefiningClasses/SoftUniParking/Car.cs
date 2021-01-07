using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        //fields
        private string make;
        private string model;
        private int horsepower;
        private string registrationnumber;

        //constructor
        public Car()
        {

        }
        public Car(string make, string model, int horsepower, string registrationnumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsepower;
            this.RegistrationNumber = registrationnumber;
        }


        //properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        //methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"HorsePower: {this.HorsePower}");
            sb.AppendLine($"RegistrationNumber: {this.RegistrationNumber}");
            return sb.ToString().Trim();
        }




    }
}
