using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            var test = new EqualityScale<string>("6", "6");
            Console.WriteLine(test.AreEqual());
        }
    }
}
