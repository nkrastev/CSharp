using System;

namespace CoffeeShop
{
    class Program
    {
        static void Main()
        {
            int orders = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            for (int i = 0; i < orders; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int daysInMonth = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());
                double price = ((daysInMonth * capsulesCount) * pricePerCapsule);
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
                totalPrice += price;
            }
            Console.WriteLine($"Total: ${ totalPrice:f2}");
        }
    }
}
