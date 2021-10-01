using System;

namespace Mo03LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Line 1
            double a1 = double.Parse(Console.ReadLine());
            double a2 = double.Parse(Console.ReadLine());
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            // Line 2
            double x1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double distanceLineA = LineLenght(a1, a2, b1, b2);
            double distanceLineB = LineLenght(x1, x2, y1, y2);

            if (distanceLineA>=distanceLineB)
            {
                double distPointA = CheckWhichPointIsCloserToCenter(a1, a2);
                double distPointB = CheckWhichPointIsCloserToCenter(b1, b2);
                if (distPointA<=distPointB)
                {
                    Console.WriteLine($"({a1}, {a2})({b1}, {b2})");
                }
                else
                {
                    Console.WriteLine($"({b1}, {b2})({a1}, {a2})");
                }
                
            }
            else
            {
                double distPointX = CheckWhichPointIsCloserToCenter(x1, x2);
                double distPointY = CheckWhichPointIsCloserToCenter(y1, y2);
                if (distPointX<=distPointY)
                {
                    Console.WriteLine($"({x1}, {x2})({y1}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({y1}, {y2})({x1}, {y2})");
                }
                
            }
        }

        static double LineLenght(double p1, double p2, double p3, double p4)
        {
            double distance = Math.Sqrt((p1 + p3) * (p1 + p3) + (p2 + p4) * (p2 + p4));
            return distance;
        }
        static double CheckWhichPointIsCloserToCenter(double x, double y)
        {            
            return Math.Sqrt(x * x + y * y);
        }
    }
}
