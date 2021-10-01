using System;

namespace CustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }        

        public int this[int index]
        {
            get
            {
                if (index>=this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (index>=this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.items[index] = value;
            }
        }

        //methods
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex>=this.Count || secondIndex>=this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }
        public int RemoveAt(int index)
        {
            if (index>=this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            int value = this.items[index];

            if (this.Count<=this.items.Length / 4)
            {
                this.Shrink();
            }
            this.Shift(index);
            return value;
        }
        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        public bool Contains(int item)
        {
            bool contains = false;
            for (int i = 0; i < this.Count; i++)
            {                
                if (this.items[i]==item)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }
        public void Insert(int index, int item)
        {
            if (index>this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            if (this.Count==this.items.Length)
            {
                this.Resize();
            }
            this.ShiftRight(index);
            this.items[index] = item;
            this.Count++;
        }
        private void ShiftRight(int index)
        {
            for (int i = this.Count-1; i >=index; i--)
            {
                this.items[i + 1] = this.items[i];
            }
        }        
        private void Shift(int index)
        {
            for (int i = index; i < this.Count-1; i++)
            {
                this.items[index] = this.items[index + 1];
            }
        }
        private void Shrink()
        {
            int newLenght = this.items.Length / 2;
            int[] temp = new int[newLenght];
            Array.Copy(this.items, temp, this.Count);
            this.items = temp;
        }
        private void Resize()
        {
            int[] temp = new int[this.items.Length * 2];            
            Array.Copy(this.items, temp, this.items.Length);
            this.items = temp;
        }        
    }
}
