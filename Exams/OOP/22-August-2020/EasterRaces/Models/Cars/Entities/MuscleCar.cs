using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        public MuscleCar(string model, int horsePower) : 
            base(model, horsePower, 5000, 400,600)
        {
            //The cubic centimeters for this type of car are 5000. Minimum horsepower is 400 and maximum horsepower is 600.
            //what is MIN is bigger than MAX???
            if (400 > horsePower || 600 < horsePower)
            {
                throw new ArgumentException($"Invalid horse power: {horsePower}.");
            }
        }
    }
}
