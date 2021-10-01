using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack
    {
        //fields
        private const int initialCapacity = 2;
        private int[] items;
        private int count;

        //ctor
        public CustomStack()
        {
            this.items = new int[initialCapacity];
            this.count = 0;
        }
        //prop
        public int Count => this.count;

        //methods
        public int Pop()
        {
            if (this.count==0)
            {
                throw new ArgumentNullException("Stack is empty");
            }
            if (this.count<=this.items.Length /4)
            {
                this.Shrink();
            }            
            var item = this.items[--this.count];
            this.items[this.count] = default(int);
            return item;
        }
        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }
        public int Peek()
        {
            if (this.count == 0)
            {
                throw new ArgumentNullException("Stack is empty");
            }
            
            var item = this.items[this.count-1];            
            return item;
        }
        public void Push(int item)
        {
            if (this.count==this.items.Length)
            {
                Resize();
            }
            this.items[this.count++] = item;
        }
        private void Resize()
        {
            int[] temp = new int[this.items.Length * 2];
            Array.Copy(this.items, temp, this.items.Length);
            this.items = temp;
        }
        private void Shrink()
        {
            int newLenght = this.items.Length / 2;
            int[] temp = new int[newLenght];
            Array.Copy(this.items, temp, this.Count);
            this.items = temp;
        }
    }
}
