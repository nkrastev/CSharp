using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03Telephony
{
    public class Engine
    {
        public void Run()
        {
            var inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var inputUrls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //calling
            foreach (var item in inputNumbers)
            {
                if (item.Length == 10)
                {
                    var phone = new Smartphone();
                    Console.WriteLine(phone.Call(item));
                }
                else
                {
                    var phone = new StationaryPhone();
                    Console.WriteLine(phone.Call(item));
                }
            }

            //browsing
            foreach (var item in inputUrls)
            {
                var smartphone = new Smartphone();
                Console.WriteLine(smartphone.Browse(item));
            }
        }
    }
}
