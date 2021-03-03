using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05BirthdayCelebrations
{
    class StartUp
    {
        static void Main()
        {
            var command = Console.ReadLine();

            var list = new List<IBirthdate>();

            while (command != "End")
            {
                var cmdAgrs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdAgrs.Length == 5)
                {
                    //person
                    IBirthdate item = new Citizen(cmdAgrs[1], int.Parse(cmdAgrs[2]), cmdAgrs[3], cmdAgrs[4]);
                    list.Add(item);
                }
                if (cmdAgrs.Length == 3 && cmdAgrs[0]=="Pet")
                {
                    //Pet
                    IBirthdate item = new Pet(cmdAgrs[1], cmdAgrs[2]);
                    list.Add(item);
                }
                command = Console.ReadLine();
            }

            var year = Console.ReadLine();

            foreach (var item in list)
            {                
                if (item.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }

        }
    }
}
