using System;

namespace _01GenericBoxofString
{
    public class Program
    {
        static void Main()
        {
            var numberOfStrings = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfStrings; i++)
            {
                Box<string> box = new Box<string>();
                box.Item = Console.ReadLine();
                Console.WriteLine(box.ToString());
            }
        }
    }
}
