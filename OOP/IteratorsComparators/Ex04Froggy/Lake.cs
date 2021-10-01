using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake :IEnumerable <int>
    {
        //fields
        private List<int> stones;


        //ctor
        public Lake(params int[] stones)
        {
            this.stones = stones.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            int count = this.stones.Count;
            
            for (int i = 0; i < count; i+=2)
            {
                yield return this.stones[i];
            }

            int lastOdd = count - 1;
            if (lastOdd % 2==0)
            {
                lastOdd -= 1;
            }

            for (int i = lastOdd; i > 0 ; i-=2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
