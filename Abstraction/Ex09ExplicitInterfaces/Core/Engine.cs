using Ex09ExplicitInterfaces.Interfaces;
using Ex09ExplicitInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex09ExplicitInterfaces
{
    public class Engine
    {
        public void Run()
        {
            //logic
            var input = Console.ReadLine();
            while (input!="End")
            {
                var cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Citizen citizen = new Citizen(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
                IPerson person = citizen;
                IResident resident = citizen;
                
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName()+person.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
