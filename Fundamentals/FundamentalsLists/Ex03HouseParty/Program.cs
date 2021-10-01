using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03HouseParty
{
    class Program
    {
        static void Main()
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guestsList = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                List<string> currentInput = Console.ReadLine().Split().ToList();

                if (currentInput[2] == "going!")
                {
                    if (guestsList.Contains(currentInput[0]) == true)
                    {
                        // is in the LIST
                        Console.WriteLine(currentInput[0] + " is already in the list!");
                    }
                    else
                    {
                        // is NOT in the LIST -> add it
                        guestsList.Add(currentInput[0]);
                    }                    
                }

                if (currentInput[2] == "not")
                {                    
                    if (guestsList.Contains(currentInput[0])==true)
                    {
                        ////NOT going and IN THE LIST -> remove it
                        guestsList.Remove(currentInput[0]);
                    }
                    else
                    {
                        // not going, not in the list, print info
                        Console.WriteLine(currentInput[0] + " is not in the list!");
                    }
                    
                }
                
            }

            //output
            for (int i = 0; i < guestsList.Count; i++)
            {
                Console.WriteLine(guestsList[i]);
            }


        }


    }
}
