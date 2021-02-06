using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();

        }

        public int Capacity
        {
            get => this.capacity;
            set => this.capacity = value;
        }
        public int Count { get => this.students.Count; }


        public string RegisterStudent(Student student)
        {
            if (capacity > this.students.Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            int searchedStudentIndex = students.FindIndex(x => x.FirstName == firstName && x.LastName == lastName);
            if (searchedStudentIndex>=0)
            {
                students.RemoveAt(searchedStudentIndex);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            bool areThereEnrolledStudents = false;
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine($"Students:");
            foreach (var item in students)
            {
                if (item.Subject==subject)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                    areThereEnrolledStudents = true;
                }
            }

            if (areThereEnrolledStudents)
            {
                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }            
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student searchedStudent = new Student();

            foreach (var item in students)
            {
                if (item.FirstName==firstName && item.LastName==lastName)
                {
                    searchedStudent = item;
                }
            }
            return searchedStudent;
        }
    }
}
