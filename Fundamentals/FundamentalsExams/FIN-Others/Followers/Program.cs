using System;
using System.Collections.Generic;
using System.Linq;

namespace Followers
{
    class Program
    {
        static void Main()
        {
            List<Follower> list = new List<Follower>();
            var command = Console.ReadLine();
            while (command!= "Log out")
            {
                var cmdArgs = command.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdArgs[0]== "New follower")
                {
                    AddFollower(list, cmdArgs[1]);
                }
                if (cmdArgs[0]== "Like")
                {
                    LikeFollower(list, cmdArgs[1], cmdArgs[2]);
                }
                if (cmdArgs[0]== "Comment")
                {
                    CommentFollower(list, cmdArgs[1]);
                }
                if (cmdArgs[0]== "Blocked")
                {
                    BlockFollower(list, cmdArgs[1]);
                }
                command = Console.ReadLine();
            }
            PrintOutput(list);
        }

        private static void PrintOutput(List<Follower> list)
        {
            Console.WriteLine($"{list.Count} followers");
            list = list.OrderByDescending(x => x.Likes).ThenBy(x => x.Name).ToList();
            foreach (Follower item in list)
            {
                Console.WriteLine($"{item.Name}: {item.Likes+item.Comments}");
            }
        }

        private static List<Follower> BlockFollower(List<Follower> list, string v)
        {
            var username = v;
            var isExist = false;
            foreach (Follower item in list)
            {
                if (item.Name == username)
                {
                    list.Remove(item);                    
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                Console.WriteLine($"{username} doesn't exist.");
            }
            return list;
        }

        private static List<Follower> CommentFollower(List<Follower> list, string v)
        {
            var username = v;
            var isExist = false;
            foreach (Follower item in list)
            {
                if (item.Name == username)
                {
                    item.Comments += 1;
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                Follower newFollower = new Follower(username, 0, 1);
                list.Add(newFollower);
            }
            return list;
        }

        private static List<Follower> LikeFollower(List<Follower> list, string v1, string v2)
        {
            var username = v1;
            var countLikes = int.Parse(v2);
            var isExist = false;
            foreach (Follower item in list)
            {
                if (item.Name == username)
                {
                    item.Likes += countLikes;
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                Follower newFollower = new Follower(username, countLikes,0);
                list.Add(newFollower);
            }
            return list;
        }

        private static List<Follower> AddFollower(List<Follower> list, string v)
        {
            string username = v;
            var isExist = false;
            foreach (Follower item in list)
            {
                if (item.Name == username)
                {
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                Follower newFollower = new Follower(username, 0, 0);
                list.Add(newFollower);
            }
            return list;
        }
    }
}
