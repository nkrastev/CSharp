using System;

namespace _02GenericBoxofInteger
{
    public class Program
    {
        static void Main()
        {
            var numberOfInts = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInts; i++)
            {
                Box<int> box = new Box<int>();
                box.Item = int.Parse(Console.ReadLine());
                Console.WriteLine(box.ToString());
            }
        }
    }
}
