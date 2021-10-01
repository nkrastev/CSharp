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
        public List<Person> PeopleInFamily { get;set; }

        //methods
        public void AddMember(Person person)
        {
            PeopleInFamily.Add(person);
        }
        public Person GetOldestMember()
        {
            return PeopleInFamily.OrderByDescending(a => a.Age).First();
        }

        internal List<Person> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
