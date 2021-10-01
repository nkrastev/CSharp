using System;

namespace Mo02CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            //point 1
            double X1 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            //point 2
            double X2 = double.Parse(Console.ReadLine());
            double Y2 = double.Parse(Console.ReadLine());

            double distancePointA = DistanceCalculator(X1,Y1);
            double distancePointB = DistanceCalculator(X2,Y2);

            if (distancePointA<=distancePointB)
            {
                Console.WriteLine($"({X1}, {Y1})");
            }
            else
            {
                Console.WriteLine($"({X2}, {Y2})");
            }


        }

        static double DistanceCalculator(double x, double y)
        {
            double distance = Math.Sqrt(x * x + y * y);
            return distance;
        }
    }
}
