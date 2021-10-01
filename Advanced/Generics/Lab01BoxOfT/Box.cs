using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        //fields
        private Stack<T> data;        

        //constructor
        public Box()
        {
            this.Data = new Stack<T>();
        }
        //properties
        public Stack<T> Data 
        {
            get;
            set;
        }
        public int Count => this.Data.Count;

        //methods
        public void Add(T element)
        {
            this.Data.Push(element);            
        }
        public T Remove()
        {           
            return this.Data.Pop();
        }
    }
}
