using Ex08CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex08CollectionHierarchy.Models
{
    public class AddCollection : IAdder
    {
        //Add which adds an item to the end of the collection
        private List<string> collection;

        public AddCollection()
        {
            collection = new List<string>();
        }
        public int Add(string element)
        {
            this.collection.Add(element);
            return collection.Count - 1;
        }

        
        
    }
}
