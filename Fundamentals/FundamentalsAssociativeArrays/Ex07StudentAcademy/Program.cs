using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07StudentAcademy
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                string curStudent = Console.ReadLine();
                double curGrade = double.Parse(Console.ReadLine());

                AddingGrades(students, curStudent, curGrade);
            }

            CalculateAverageGrades(students);

            //filter average grade higher than or equal to 4.50
            students=students.Where(x => x.Value[x.Value.Count - 1] >= 4.5).ToDictionary(x => x.Key, x => x.Value);

            //Order the filtered students by average grade in descending order.
            students=students.OrderByDescending(x => x.Value[x.Value.Count - 1]).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {item.Value[item.Value.Count-1]:f2}");
            }



        }

        private static Dictionary<string, List<double>> CalculateAverageGrades(Dictionary<string, List<double>> students)
        {
            //we have students and list with all grades, for each student add to the last place of the list average grade
            foreach (var item in students)
            {
                //item.value is the list with all grades
                double sumOfGrades = 0;
                foreach (var listItem in item.Value)
                {
                    sumOfGrades += listItem;
                }
                double avrgGrade = sumOfGrades / item.Value.Count;
                // add avrgGrade to the last position of the list with grades
                students[item.Key].Add(avrgGrade);
            }
            return students;
        }

        private static Dictionary<string, List<double>> AddingGrades(Dictionary<string, List<double>> students, string curStudent, double curGrade)
        {
            if (students.ContainsKey(curStudent))
            {
                //just add grade to the list
                students[curStudent].Add(curGrade);
            }
            else
            {
                //create new student, create new list, add grade
                List<double> newGradesList = new List<double>();
                newGradesList.Add(curGrade);
                students.Add(curStudent, newGradesList);
            }

            return students;
        }
    }
}
