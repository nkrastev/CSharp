using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main()
        {
            //Enter a day number [1…7] and print the name (in English) or "Invalid day!"
            int n = int.Parse(Console.ReadLine());
            string[] weekDays = new string[7];
            weekDays[0] = "Monday";
            weekDays[1] = "Tuesday";
            weekDays[2] = "Wednesday";
            weekDays[3] = "Thursday";
            weekDays[4] = "Friday";
            weekDays[5] = "Saturday";
            weekDays[6] = "Sunday";

            if (n > 7 || n <= 0)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(weekDays[n - 1]);
            }
            
            

        }
    }
}
