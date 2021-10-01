using System;
using System.Numerics;

namespace Ex09SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int workingDays = 0;
            BigInteger totalAmount = 0;

            while (startingYield>=100)
            {
                int currentlyExtracted = startingYield;
                currentlyExtracted -= 26; //workers
                startingYield -= 10;
                totalAmount += currentlyExtracted;
                workingDays++;
            }

            if (totalAmount>=26)
            {
                totalAmount -= 26; //an additional 26 after the mine has been exhausted
            }
            

            Console.WriteLine(workingDays);
            Console.WriteLine(totalAmount);
        }
    }
}
