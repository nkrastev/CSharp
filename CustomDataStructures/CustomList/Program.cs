using System;
using System.Collections.Generic;

namespace CustomList
{
    class Program
    {
        static void Main()
        {
            CustomList customList = new CustomList();

            customList.Add(10);
            customList.Add(20);
            customList.Add(30);

            customList.Insert(1, 0);

            int result = customList.RemoveAt(2);

            Console.WriteLine(result);
            
            //Console.WriteLine(customList[1]);

            //Console.WriteLine(String.Join(", ",customList));

        }
    }
}
