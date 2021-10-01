using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Judge 100/100 with no restriction to the age?!

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
    }
}