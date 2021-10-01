using System;
using System.Collections.Generic;
using System.Linq;

namespace Mo01Ranking
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> contestsCheck = new Dictionary<string, string>();

            // username > contest > points
            Dictionary<string, Dictionary<string, int>> userSubmissions = new Dictionary<string, Dictionary<string, int>>();
            
            ContestsInputRead(contestsCheck);

            SubmissionsInputRead(userSubmissions, contestsCheck);

            GetBestCandidate(userSubmissions);

            //order by Name
            userSubmissions = userSubmissions
                .OrderBy(x => x.Key)                
                .ToDictionary(x => x.Key, x => x.Value);
            
            Console.WriteLine("Ranking:");

            //output
            foreach (var item in userSubmissions)
            {
                Console.WriteLine($"{item.Key}");
                // create temp dict for output
                Dictionary<string, int> currentPoints = new Dictionary<string, int>();
                currentPoints = item.Value;
                currentPoints = currentPoints.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                foreach (var pt in currentPoints)
                {
                    Console.WriteLine($"#  {pt.Key} -> {pt.Value}");
                }
            }

        }

        private static void GetBestCandidate(Dictionary<string, Dictionary<string, int>> userSubmissions)
        {
            Dictionary<string, int> usersWithTotalPoints = new Dictionary<string, int>();

            foreach (var item in userSubmissions)
            {
                Dictionary<string,int> temp = item.Value;
                int points = 0;
                foreach (var x in temp)
                {
                    points += x.Value;
                }

                // item.Value is dictionary

                if (usersWithTotalPoints.ContainsKey(item.Key))
                {
                    usersWithTotalPoints[item.Key] += points;
                }
                else
                {
                    //add new user
                    usersWithTotalPoints.Add(item.Key, points);
                }
            }

            usersWithTotalPoints=usersWithTotalPoints.OrderByDescending(x => x.Value).Take(1).ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var item in usersWithTotalPoints)
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value} points.");
            }

        }

        private static Dictionary<string, Dictionary<string, int>> SubmissionsInputRead
            (
            Dictionary<string, Dictionary<string, int>> userSubmissions, 
            Dictionary<string, string> contestsCheck
            )
        {
            string input = Console.ReadLine();

            while (input!= "end of submissions")
            {
                string[] submissionItem = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string contest = submissionItem[0];
                string password = submissionItem[1];
                string username = submissionItem[2];
                int points = int.Parse(submissionItem[3]);


                //check if contest is valid
                if (contestsCheck.ContainsKey(contest))
                {
                    if (contestsCheck[contest]==password)
                    {
                        //add submission to the big dictionary

                        if (userSubmissions.ContainsKey(username))
                        {
                            //there is such user, check for submissions for the current contest
                            if (userSubmissions[username].ContainsKey(contest))
                            {
                                //user has been completes the current contest, check for points
                                if (userSubmissions[username][contest]<points)
                                {
                                    userSubmissions[username][contest] = points;
                                }
                            }
                            else
                            {
                                // user has not been completed the current contest
                                Dictionary<string, int> newSub = new Dictionary<string, int>();
                                newSub.Add(contest, points);
                                userSubmissions[username].Add(contest, points);
                            }                                                       
                        }
                        else
                        {
                            //no such user, add user and submission
                            Dictionary<string, int> newSub = new Dictionary<string, int>();
                            newSub.Add(contest, points);
                            userSubmissions.Add(username, newSub);
                        }


                        
                        
                    }
                }


                input = Console.ReadLine();
            }

            return userSubmissions;
        }

        private static Dictionary<string,string> ContestsInputRead(Dictionary<string, string> contestsCheck)
        {
            //“{contest}:{password for contest}” until you receive “end of contests”. 
            string input = Console.ReadLine();
            while (input!= "end of contests")
            {
                string[] data = input.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string contest = data[0];
                string password = data[1];
                if (!contestsCheck.ContainsKey(contest))
                {
                    contestsCheck.Add(contest, password);
                }                
                input = Console.ReadLine();
            }
            return contestsCheck;
        }
    }
}
