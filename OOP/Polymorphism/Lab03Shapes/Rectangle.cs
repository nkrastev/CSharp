using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

       

        public override double CalculateArea() => height * width;

        public override double CalculatePerimeter() => 2 * height + 2 * width;

        public override string Draw()
        {
            //къде в условието пише, че трябва да връща това като резултат???
            return $"{base.Draw()} {this.GetType().Name}";
        }
    }
}
