using System;

namespace _08Threeuple
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);            
            var first = new Threeuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
            Console.WriteLine(first);

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var boolean = input[2] == "drunk" ? true : false;
            var second = new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), boolean);
            Console.WriteLine(second);

            input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var third = new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(third);
        }
    }
}
