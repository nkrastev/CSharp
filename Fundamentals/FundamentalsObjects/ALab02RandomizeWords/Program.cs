using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab02RandomizeWords
{
    class Program
    {
        static void Main()
        {
            List<string> inputList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            // create new instance for "randomizerObject"
            Random randomizorObject = new Random();
            

            for (int i = 0; i < inputList.Count; i++)
            {
                //generate random value for position and set to object
                int randomPosition=randomizorObject.Next(0, inputList.Count);
                //swap values
                string temp = inputList[i];
                inputList[i] = inputList[randomPosition];
                inputList[randomPosition] = temp;
            }

            //output
            Console.WriteLine(string.Join(Environment.NewLine, inputList));

        }
    }
}
