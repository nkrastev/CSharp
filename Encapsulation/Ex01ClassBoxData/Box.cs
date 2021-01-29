using System;
using System.Collections.Generic;
using System.Text;

namespace Ex01ClassBoxData
{
    public class Box
    {
        //fields
        private double length;
        private double width;
        private double height;

        //ctor      
        public Box(double length, double width, double height)
        {
            this.Height = height;
            this.Length = length;
            this.Width = width;
        }

        //prop
        public double Length
        {
            get => this.length;
            private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            } 
        }
        public double Width
        {
             get => this.width;
             private set
             {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        //methods
        public double SurfaceArea() => (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double Lateral() => (2 * this.Length * this.Height + 2 * this.Width* this.Height);

        public double Volume() => (this.Length * this.Width * this.Height);



    }
}
