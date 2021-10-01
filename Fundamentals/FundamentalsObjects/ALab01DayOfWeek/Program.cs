using System;
using System.Globalization;

namespace ALab01DayOfWeek
{
    class Program
    {
        static void Main()
        {
            //18-04-2016 > Monday
            
            DateTime dateObject = DateTime.ParseExact(Console.ReadLine(), "d-MM-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(dateObject.DayOfWeek);

            
        }
    }
}
