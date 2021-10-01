using System;

namespace Mo01DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = Console.ReadLine();

            while (inputCommand!="END")
            {
                int intResult;
                double doubleResult;
                bool boolResult;
                char charResult;

                bool isInteger = Int32.TryParse(inputCommand, out intResult);
                bool isDouble = double.TryParse(inputCommand, out doubleResult);
                bool isBoolean = bool.TryParse(inputCommand, out boolResult);
                bool isChar = char.TryParse(inputCommand, out charResult);


                if (isInteger)
                {
                    Console.WriteLine($"{intResult} is integer type");
                }
                else if (isDouble)
                {
                    Console.WriteLine($"{inputCommand} is floating point type");
                }
                else if(isBoolean)
                {
                    Console.WriteLine($"{inputCommand} is boolean type");
                }
                else if (isChar)
                {
                    Console.WriteLine($"{charResult} is character type");
                }
                else
                {
                    Console.WriteLine($"{inputCommand} is string type");
                }



                inputCommand = Console.ReadLine();
                

                

            }
        }

    }
}
