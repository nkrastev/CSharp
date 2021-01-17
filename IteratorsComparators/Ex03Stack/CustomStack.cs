using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class CustomStack<T> :IEnumerable<T>
    {
        //fields
        private List<T> data;
        

        //ctor
        public CustomStack()
        {
            this.data = new List<T>();
        }       

        //prop, not in the task
        public int Count => this.data.Count;

        //methods
        public void Push(T item)
        {
            this.data.Add(item);
        }

        public T Pop()
        {
            T item;
            if (this.data.Count>0)
            {                
                item = this.data[data.Count - 1];
                this.data.RemoveAt(data.Count - 1);
                return item;
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.data.Count-1; i >= 0; i--)
            
                yield return this.data[i];
        }

        //old interface
        IEnumerator IEnumerable.GetEnumerator()=> GetEnumerator();        
    }
}
