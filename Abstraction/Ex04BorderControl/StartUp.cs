using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04BorderControl
{
    class StartUp
    {
        static void Main()
        {
            var command = Console.ReadLine();
            
            var list = new List<IIdentity>();

            while (command != "End")
            {
                var cmdAgrs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdAgrs.Length==3)
                {
                    //person
                    IIdentity item = new Person(cmdAgrs[0], int.Parse(cmdAgrs[1]), cmdAgrs[2]);
                    list.Add(item);                    
                }
                if (cmdAgrs.Length==2)
                {
                    //robot
                    IIdentity item = new Robot(cmdAgrs[0], cmdAgrs[1]);
                    list.Add(item);
                }
                command = Console.ReadLine();
            }

            var detained = Console.ReadLine();

            foreach (var item in list)
            {
                if (item.Id.EndsWith(detained))
                {
                    Console.WriteLine(item.Id);
                }                              
            }
        }
        
    }
}
