using Ex08CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex08CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAdder, IRemover
    {
        private List<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string element)
        {
            //An Add method - which adds an item to the start of the collection.
            this.collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            //•	A Remove method, which removes the last item in the collection.
            string returnElement = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            return returnElement;
        }
    }
}
