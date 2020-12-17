using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex08Ranking
{
    class Program
    {
        static void Main()
        {
            var contests = ReadContests();            
            var students = ReadContestants(contests);


        }

        private static Dictionary<string, Dictionary<string, int>> ReadContestants(Dictionary<string,string> contests)
        {
            var students = new Dictionary<string, Dictionary<string, int>>();
            var command = Console.ReadLine();
            while (command!= "end of submissions")
            {
                var cmdArgs = command.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var course = cmdArgs[0];
                var password = cmdArgs[1];
                var username = cmdArgs[2];
                var score = int.Parse(cmdArgs[3]);

                if (IsContestValid(course,password,contests))
                {
                    //add score                    
                    //is user in dict
                    if (students.ContainsKey(username))
                    {
                        if (students[username].ContainsKey(course))
                        {
                            //check scores if better, replace
                            if (students[username][course]<score)
                            {
                                students[username][course] = score;
                            }
                        }
                        else
                        {
                            //student dosnt have this course, add it
                            students[username].Add(course, score);
                        }
                    }
                    else
                    {
                        //student doest exist, add it
                        Dictionary<string, int> newCourse = new Dictionary<string, int>();
                        newCourse.Add(course, score);
                        students.Add(username, newCourse);
                    }
                }
                else
                {
                    //contest is invalid                    
                }
                command = Console.ReadLine();
            }
            return students;
        }

        private static bool IsContestValid(string currentContest, string currentPassword, Dictionary<string, string> contests)
        {
            bool isValid = false;
            if (contests.ContainsKey(currentContest))
            {
                if (contests[currentContest].Contains(currentPassword))
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        private static Dictionary<string,string> ReadContests()
        {
            var data = new Dictionary<string, string>();
            var command = Console.ReadLine();
            while (command!= "end of contests")
            {
                var cmdArgs = command.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!data.ContainsKey(cmdArgs[0]))
                {
                    data.Add(cmdArgs[0], cmdArgs[1]);
                }
                command = Console.ReadLine();
            }
            return data;
        }
    }
}
