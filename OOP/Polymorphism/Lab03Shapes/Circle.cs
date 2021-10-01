using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }


        public override double CalculateArea() => Math.PI * radius * radius;

        public override double CalculatePerimeter() => Math.PI * 2 * radius;

        public override string Draw()
        {
            return $"{base.Draw()} {this.GetType().Name}";
        }
    
    }
}
