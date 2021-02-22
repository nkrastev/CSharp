using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            Shape rect = new Rectangle(5, 5);

            Console.WriteLine(rect.CalculateArea());
            Console.WriteLine(rect.CalculatePerimeter());
            Console.WriteLine(rect.Draw());

            Shape circle = new Circle(5);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());

        }
    }
}
