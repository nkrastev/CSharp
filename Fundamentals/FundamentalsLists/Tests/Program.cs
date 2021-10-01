using System;
using System.Linq;

namespace TypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int reps = int.Parse(Console.ReadLine());
                string number = String.Empty;
                double firstnumber = 0;
                double secondnumber = 0;
                int sum = 0;

                

                for (int i = 0; i <= reps; i++)
                {                    
                    double[] items = Console.ReadLine().Split().Select(double.Parse).ToArray();

                    if (items.Length>1)
                    {
                        if (items[0] > items[1])
                        {
                            Console.WriteLine("succes");
                        }
                    }
                    else
                    {
                        Console.WriteLine("2nd number is missing from the string which is parsed to array");
                    }
                    


                }
            }
        }
    }
}