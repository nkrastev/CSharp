using System;
using System.Collections.Generic;
using System.Linq;

namespace ALab02AverageStudentGrades
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var grades = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var student = input[0];
                var grade = decimal.Parse(input[1]);

                if (grades.ContainsKey(student))
                {
                    grades[student].Add(grade);
                }
                else
                {
                    grades.Add(student, new List<decimal> {grade});
                }
            }

            foreach (var item in grades)
            {                
                Console.WriteLine($"{item.Key} -> {String.Join(" ", item.Value.Select(x => x.ToString("f2")))} (avg: {item.Value.Average():f2})");
            }
        }
    }
}
