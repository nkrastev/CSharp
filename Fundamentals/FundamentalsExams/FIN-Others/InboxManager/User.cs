using System;
using System.Collections.Generic;
using System.Text;

namespace InboxManager
{
    class User
    {
        //constructor
        public User(string username, List<string> emails)
        {
            Username = username;
            Emails = emails;
        }
        //properties
        public string Username { get; set; }
        public List<string> Emails { get; set; }
    }
}
