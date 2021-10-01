using System;

namespace Ex05DateModifier
{
    public class Program
    {
        static void Main()
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            Console.WriteLine(DateModifier.Calculate(firstDate, secondDate));            
        }
    }
}
