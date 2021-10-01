using System;
using System.Collections.Generic;
using System.Text;

namespace RoliTheCoder
{
    public class Event
    {
        //constructor
        public Event(int id, string name, List<string> participants)
        {
            Id = id;
            Name = name;
            Participants = participants;
        }
        //properties
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Participants { get; set; }
    }
}
