using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        //fields
        
        private int capacity;

        //constructor
        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }

        //prop
        public List<Car> Cars { get; set; }
        public int Capacity { get; }

        public int Count => this.Cars.Count;        

        //methods
        public string AddCar(Car car)
        {
            var status = string.Empty;
            if (this.Cars.Any(x=>x.RegistrationNumber == car.RegistrationNumber))
            {
                //car is at the parking
                status = "Car with that registration number, already exists!";
            }
            else if (this.Cars.Count >=this.Capacity)
            {
                //not enought free spots at parking
                status = "Parking is full!";
            }
            else
            {
                //park the car and add it to the list
                this.Cars.Add(car);
                status = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
            return status;
        }

        public string RemoveCar(string registrationPlate)
        {
            var status = string.Empty;
            if (this.Cars.Any(x => x.RegistrationNumber == registrationPlate))
            {
                //car is in the parking, remove it
                var index = this.Cars.FindIndex(x => x.RegistrationNumber == registrationPlate);
                this.Cars.RemoveAt(index);
                status = $"Successfully removed {registrationPlate}";
            }
            else
            {
                //no such car
                status = "Car with that registration number, doesn't exist!";
            }                       
            return status;
        }

        public Car GetCar(string registrationPlate)
        {
            Car resultCar = new Car();
            if (this.Cars.Any(x=>x.RegistrationNumber==registrationPlate))
            {
                var index = this.Cars.FindIndex(x => x.RegistrationNumber == registrationPlate);
                resultCar = this.Cars[index];
            }
            return resultCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> listOfPlates)
        {
            for (int i = 0; i < this.Cars.Count; i++)
            {
                if (listOfPlates.Contains(this.Cars[i].RegistrationNumber))
                {
                    //Console.WriteLine($"car removed with plate {this.Cars[i].RegistrationNumber}");
                    this.Cars.RemoveAt(i);
                    i--;
                }
            }
        }

    }
}
