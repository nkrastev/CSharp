using System;
namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            Person first = new Person();
            Person second = new Person(5);
            Person third = new Person("Pesho",7);

            Console.WriteLine(third.Age);
        }
    }
}
