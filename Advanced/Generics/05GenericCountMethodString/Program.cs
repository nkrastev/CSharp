using System;

namespace _05GenericCountMethodString
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var customList = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                customList.AddToList(Console.ReadLine());
            }

            //value of the element for comparison
            var element = Console.ReadLine();

            Console.WriteLine(customList.BiggerElements(element));
        }
    }
}
