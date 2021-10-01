using System;

namespace _06GenericCountMethodDouble
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var customList = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                customList.AddToList(double.Parse(Console.ReadLine()));
            }

            //value of the element for comparison
            var element = double.Parse(Console.ReadLine());

            Console.WriteLine(customList.BiggerElements(element));
        }
    }
}
