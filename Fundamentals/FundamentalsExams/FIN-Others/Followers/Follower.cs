using System;
using System.Collections.Generic;
using System.Text;

namespace Followers
{
    public class Follower
    {
        //constructor
        public Follower(string name, int likes, int comments)
        {
            Name = name;
            Likes = likes;
            Comments = comments;
        }
        //properties
        public string Name { get; set; }
        public int Likes { get; set; }
        public int Comments { get; set; }
    }
}
