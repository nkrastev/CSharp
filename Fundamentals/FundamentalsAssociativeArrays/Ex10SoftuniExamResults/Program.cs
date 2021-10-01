using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex10SoftuniExamResults
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, List<int>> usersWithPoints = new Dictionary<string, List<int>>();
            Dictionary<string, int> langSubmissions = new Dictionary<string, int>();
            List<string> bannedUsers = new List<string>();

            while (input!= "exam finished")
            {
                string[] inputSubmission = input.Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                if (inputSubmission[inputSubmission.Length-1]=="banned")
                {                    
                    bannedUsers.Add(inputSubmission[0]);
                }
                else
                {
                    //not banned command, but check if user is not banned before
                    string username = inputSubmission[0];
                    string language = inputSubmission[1];
                    int points = int.Parse(inputSubmission[2]);

                    if (!bannedUsers.Contains(username))
                    {
                        //user is not in the banned list, continue with submission
                        
                        if (!usersWithPoints.ContainsKey(username))
                        {
                            //first submission of the user
                            List<int> userPointsList = new List<int>();
                            userPointsList.Add(points);
                            usersWithPoints.Add(username, userPointsList);
                        }
                        else
                        {
                            //user already has submissions, add the new points to the list
                            usersWithPoints[username].Add(points);
                        }

                        //add language Submission
                        if (!langSubmissions.ContainsKey(language))
                        {
                            //no such lang submission, add one
                            langSubmissions.Add(language, 1);
                        }
                        else
                        {
                            //lang exists +1 submission
                            langSubmissions[language] += 1;
                        }
                    }
                }                                          
                input = Console.ReadLine();
            }
            //re order
            usersWithPoints = usersWithPoints
                .OrderByDescending(x => x.Value.Max())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            langSubmissions=langSubmissions
                .OrderByDescending(x=>x.Value)
                .ThenBy(x=>x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            //output
            Console.WriteLine("Results:");
            foreach (var item in usersWithPoints)
            {
                if (!bannedUsers.Contains(item.Key))
                {
                    Console.WriteLine($"{item.Key} | {item.Value.Max()}");
                }                
            }

            Console.WriteLine("Submissions:");
            foreach (var item in langSubmissions)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

           
            
        }
    }

   
}
