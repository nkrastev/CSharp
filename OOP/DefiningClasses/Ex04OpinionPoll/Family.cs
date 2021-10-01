using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        //fields
        private List<Person> peopleInFamily { get; set; }

        //constructor 
        public Family()
        {
            PeopleInFamily = new List<Person>();
        }

        //properties
        public List<Person> PeopleInFamily { get; set; }

        //methods
        public void AddMember(Person person)
        {
            PeopleInFamily.Add(person);
        }
        public Person GetOldestMember()
        {
            return PeopleInFamily.OrderByDescending(a => a.Age).First();
        }

        public List<Person> GetOlderThan30()
        {
            return PeopleInFamily.Where(x => x.Age > 30).ToList();
        }
    }
}
