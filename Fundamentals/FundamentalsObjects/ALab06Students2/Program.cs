using System;
using System.Collections.Generic;

namespace ALab06Students2
{
    class Program
    {
        static void Main()
        {
            List<Student> studentsList = new List<Student>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] tempStudent = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string fName = tempStudent[0];
                string lName = tempStudent[1];
                int age = int.Parse(tempStudent[2]);
                string homeTown = tempStudent[3];

                Student newStudent = new Student
                {
                    FirstName = fName,
                    LastName = lName,
                    Age = age,
                    HomeTown = homeTown
                };

                bool ifStudentExist = false;
                //check if current student exist??? and overwrite if so
                foreach (Student item in studentsList)
                {
                    if (item.FirstName==fName && item.LastName==lName)
                    {
                        //overwrite
                        ifStudentExist = true;
                        item.Age = age;
                        item.HomeTown = homeTown;

                    }
                }

                if (ifStudentExist == false)
                {
                    studentsList.Add(newStudent);
                }


                
                
                command = Console.ReadLine();
            }

            string cityName = Console.ReadLine();

            Student.FilterStudents(cityName, studentsList);
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        public static void FilterStudents(string cityName, List<Student> studentsList)
        {
            foreach (Student item in studentsList)
            {
                if (item.HomeTown == cityName)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }

            }
        }
    }
}
