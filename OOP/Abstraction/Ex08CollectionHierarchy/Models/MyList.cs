using Ex08CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex08CollectionHierarchy.Models
{
    public class MyList : IAdder, IRemover
    {
        private List<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }


        public int Add(string element)
        {
            //method, which adds an item to the start of the collection
            this.collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            //method, which removes the first element in the collection
            string returnElement = collection[0];
            collection.RemoveAt(0);
            return returnElement;
        }

        //Used property, which displays the number of elements currently in the collection. 
        public int Used
        {
            get => this.collection.Count;
        }
    }
}
