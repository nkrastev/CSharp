using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex06Courses
{
    class Program
    {
        static void Main()
        {
            string[] command = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (command[0]!="end")
            {
                string courseName = command[0];
                string studentName = command[1];

                if (courses.ContainsKey(courseName))
                {
                    //there is such course, add student to the list
                    courses[courseName].Add(studentName);
                }
                else
                {
                    //course dosnt exist, add course and add student
                    List<string> newCourseStudents = new List<string>();
                    newCourseStudents.Add(studentName);
                    courses.Add(courseName, newCourseStudents);
                }

                command = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            //reorder Dictionary
            courses=courses.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            //output

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                //item.value is a List, reorder it
                item.Value.Sort();

                foreach (var students in item.Value)
                {
                    Console.WriteLine($"-- {students}");
                }
            }
        }
    }
}
