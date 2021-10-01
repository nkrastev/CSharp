using System;

namespace Mo01DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculations(Console.ReadLine(), Console.ReadLine());

        }

        static void Calculations(string inputType, string inputValue)
        {
            if (inputType=="int")
            {
                Console.WriteLine(int.Parse(inputValue)*2);
            }
            if (inputType=="real")
            {                
                Console.WriteLine($"{double.Parse(inputValue) * 1.5:f2}");
            }
            if (inputType == "string")
            {
                Console.WriteLine($"${inputValue}$");
            }


        }
    }
}
