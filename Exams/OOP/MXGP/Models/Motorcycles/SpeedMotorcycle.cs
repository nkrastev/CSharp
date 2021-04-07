using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double CUBICS = 125;
        private const int MIN_HP = 50;
        private const int MAX_HP = 69;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower): base(model, horsePower, CUBICS)
        {
        }

        public new int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value > MAX_HP || value < MIN_HP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }

    }
}
