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
                this.CheckAndThrowExeption(value, "Length");
                this.length = value;
            } 
        }
        public double Width
        {
             get => this.width;
             private set
             {
                this.CheckAndThrowExeption(value, "Width");                
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                this.CheckAndThrowExeption(value, "Height");
                this.height = value;
            }
        }
        

        //methods
        public double SurfaceArea() => (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double Lateral() => (2 * this.Length * this.Height + 2 * this.Width* this.Height);

        public double Volume() => (this.Length * this.Width * this.Height);

        private void CheckAndThrowExeption(double value, string parameter)
        {
            if (value<=0)
            {
                throw new ArgumentException($"{parameter} cannot be zero or negative.");
            }
        }



    }
}
