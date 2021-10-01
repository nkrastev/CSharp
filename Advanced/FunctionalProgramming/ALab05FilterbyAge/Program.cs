using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab05FilterbyAge
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dictionary = ReadData(n);
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);
            
            PrintFilteredStudent(dictionary, tester, printer);                       

        }

        

        private static void PrintFilteredStudent(Dictionary<string, int> dictionary, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var item in dictionary)
            {
                if (tester(item.Value))
                {
                    printer(item);
                }
            }
            
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            if (format=="name")
            {
                return n=> Console.WriteLine($"{n.Key}");
            }
            else if (format=="age")
            {
                return n => Console.WriteLine($"{n.Value}");
            }
            else
            {
                return n => Console.WriteLine($"{n.Key} - {n.Value}");
            }

        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }

        private static Dictionary<string, int> ReadData(int n)
        {
            var data = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ").ToArray();
                data.Add(input[0], int.Parse(input[1]));
            }
            return data;
        }
    }
}
