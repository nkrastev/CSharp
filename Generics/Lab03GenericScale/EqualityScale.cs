using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        //fields
        private T left;
        private T right;

        //ctor
        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        //prop
        public T Left { get; set; }
        public T Right { get; set; }

        //methods
        public bool AreEqual()
        {            
            if (this.Left.Equals(this.Right))
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

    }
}
