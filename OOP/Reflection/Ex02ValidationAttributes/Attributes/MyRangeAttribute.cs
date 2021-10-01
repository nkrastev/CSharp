using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int min;
        private readonly int max;
        public MyRangeAttribute(int min, int max)
        {
            this.ValidateRange(min, max);
            this.min = min;
            this.max = max;
        }
        public override bool IsValid(object obj)
        {
            if (obj is Int32)
            {
                int value = (int)obj;
                if (value< this.min || value>this.max)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("Input is not INT");
            }
        }

        private void ValidateRange(int minValue, int maxValue)
        {
            if (minValue>maxValue)
            {
                throw new ArgumentException("Invalid Range");
            }
        }
    }
}
