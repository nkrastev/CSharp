using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        public SportsCar(string model, int horsePower) :
            base(model, horsePower, 3000, 250, 450)
        {
            //The cubic centimeters for this type of car are 5000. Minimum horsepower is 400 and maximum horsepower is 600.
            //what is MIN is bigger than MAX???
            if (250 > horsePower || 450 < horsePower)
            {
                throw new ArgumentException($"Invalid horse power: {horsePower}.");
            }
        }
    }
    
}
