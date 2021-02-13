using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        //fields
        private List<Person> data;

        //ctor
        public Repository()
        {
            this.data = new List<Person>();
        }
        //prop
        public int Count 
        {
            get => this.data.Count;             
        }

        //methods
        public void Add(Person person)
        {
            this.data.Add(person);
        }
        //•	Method Get(int id) – returns the entity with given ID
        public Person Get(int id) => this.data[id];

        //•	Method Update(int id, Person newPerson) – replaces the entity with the given id with the new entity. 
        //Returns false if the id doesn't exist, otherwise returns true.
        public bool Update(int id, Person newPerson)
        {
            bool isUpdated = false;
            if (id >= 0 && id < this.data.Count)
            {                
                this.data[id] = newPerson;
                isUpdated = true;
            }
            return isUpdated;
        }
        //•	Method Delete(id) – deletes an entity by given id. Return false if the id doesn't exist, otherwise return true.
        public bool Delete(int id)
        {
            bool isDeleted = false;

            if (id>=0 && id<this.data.Count)
            {
                isDeleted = true;
                data.RemoveAt(id);
            }
            return isDeleted;
        }

    }
}
