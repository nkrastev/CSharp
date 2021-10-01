using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex10SoftUniCoursePlanning
{
    class Program
    {
        static void Main()
        {
            //input
            List<string> scheduleLessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] commands = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            //commands
            while (commands[0]!= "course start")
            {
                if (commands[0]== "Add")
                {
                    string lessonTitle = commands[1];
                    AddLesson(scheduleLessons, lessonTitle);                    
                }

                if (commands[0]== "Insert")
                {                    
                    string lessonTitle = commands[1];
                    int index = int.Parse(commands[2]);
                    InsertLesson(scheduleLessons, lessonTitle, index);
                }

                if (commands[0]== "Remove")
                {
                    string lessonTitle = commands[1];
                    RemoveLesson(scheduleLessons, lessonTitle);
                }

                if (commands[0]=="Swap")
                {
                    string lessonTitleFirst = commands[1];
                    string lessonTitleSecond = commands[2];
                    SwapLessons(scheduleLessons, lessonTitleFirst, lessonTitleSecond);
                }

                if (commands[0]== "Exercise")
                {
                    string exerciseTitle = commands[1];
                    AddExercise(scheduleLessons, exerciseTitle);
                }


                commands =Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            //output
            PrintSchedule(scheduleLessons);

        }

        private static List<string> AddExercise(List<string> scheduleLessons, string exerciseTitle)
        {
            int indexOfLesson = scheduleLessons.IndexOf(exerciseTitle);
            if (indexOfLesson == -1)
            {
                //no lesson, add lesson+ exercise
                scheduleLessons.Add(exerciseTitle);
                scheduleLessons.Add(exerciseTitle + "-Exercise");
            }
            else
            {
                //there is lesson, add exer. at next position
                scheduleLessons.Insert(indexOfLesson + 1, exerciseTitle + "-Exercise");
            }

            return scheduleLessons;
        }

        private static List<string> SwapLessons(List<string> scheduleLessons, string lessonTitleFirst, string lessonTitleSecond)
        {
            int indexOfFirstLesson = scheduleLessons.IndexOf(lessonTitleFirst);
            int indexOfSecondLesson = scheduleLessons.IndexOf(lessonTitleSecond);
            if (indexOfFirstLesson == -1 || indexOfSecondLesson==-1)
            {
                //one of the lessons cant be found in the list so swap unavailable                
            }
            else
            {
                //swapping exercises if exists
                if (scheduleLessons[indexOfFirstLesson+1]== lessonTitleFirst+"-Exercise" &&
                    scheduleLessons[indexOfSecondLesson + 1] == lessonTitleSecond + "-Exercise"
                    )
                {
                    //first and second lessons has exercise, so swap the ex also
                    scheduleLessons[indexOfFirstLesson + 1] = lessonTitleSecond + "-Exercise";
                    scheduleLessons[indexOfSecondLesson + 1] = lessonTitleFirst + "-Exercise";
                }
                //first lesson has ex, the second do not have
                if(scheduleLessons[indexOfFirstLesson + 1] == lessonTitleFirst + "-Exercise" &&
                   scheduleLessons[indexOfSecondLesson + 1] != lessonTitleSecond + "-Exercise")
                {
                    scheduleLessons.Insert(indexOfSecondLesson + 1, scheduleLessons[indexOfFirstLesson + 1]);
                    scheduleLessons.RemoveAt(indexOfFirstLesson + 1);
                }
                //second lesson has ex, the first one do not
                if (scheduleLessons[indexOfFirstLesson + 1] != lessonTitleFirst + "-Exercise" &&
                    scheduleLessons[indexOfSecondLesson + 1] == lessonTitleSecond + "-Exercise")
                {
                    scheduleLessons.Insert(indexOfFirstLesson + 1, scheduleLessons[indexOfSecondLesson + 1]);
                    scheduleLessons.RemoveAt(indexOfSecondLesson + 1);
                }


                    //swap the lessons
                    scheduleLessons[indexOfFirstLesson] = lessonTitleSecond;
                scheduleLessons[indexOfSecondLesson] = lessonTitleFirst;
            }
            

            return scheduleLessons;
        }

        private static List<string> RemoveLesson(List<string> scheduleLessons, string lessonTitle)
        {
            if (scheduleLessons.Exists(item => item == lessonTitle))
            {
                scheduleLessons.Remove(lessonTitle);
            }
            string exerciseTitle = lessonTitle + "-Exercise";
            if (scheduleLessons.Exists(item => item == exerciseTitle))
            {
                scheduleLessons.Remove(exerciseTitle);
            }
            return scheduleLessons;
        }

        private static List<string> InsertLesson(List<string> scheduleLessons, string lessonTitle, int index)
        {
            if (!scheduleLessons.Exists(item => item == lessonTitle) && index<scheduleLessons.Count && index>=0)
            {
                scheduleLessons.Insert(index, lessonTitle);
            }
            return scheduleLessons;
        }

        private static List<string> AddLesson(List<string> scheduleLessons, string lessonTitle)
        {
            if (!scheduleLessons.Exists(item=>item==lessonTitle))
            {
                scheduleLessons.Add(lessonTitle);
            }                      
            return scheduleLessons;
        }
        private static void PrintSchedule(List<string> scheduleLessons)
        {
            for (int i = 0; i < scheduleLessons.Count; i++)
            {
                Console.WriteLine($"{i+1}.{scheduleLessons[i]}");
            }
        }
    }
}
