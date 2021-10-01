using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04Students
{
    class Program
    {
        static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> studentsList = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] currentStudent = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string firstName = currentStudent[0];
                string lastName = currentStudent[1];
                double grade = double.Parse(currentStudent[2]);
                
                // create new instance of object Student and add data to item
                Student studentItem = new Student(firstName, lastName, grade);

                // add current student to the list
                studentsList.Add(studentItem);
            }

            //reorder
            studentsList = studentsList.OrderByDescending(item => item.Grade).ToList();
            //output
            foreach (Student item in studentsList)
            {
                Console.WriteLine(item.ToString());
            }
        }        
    }

    class Student
    {
        //constructor
        public Student(string firstName, string lastName, double grade)
        {
            
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        
        //properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        //class methods
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }

    }
}
