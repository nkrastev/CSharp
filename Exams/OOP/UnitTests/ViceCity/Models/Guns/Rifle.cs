using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int GUN_CAPACITY = 50;
        public Rifle(string name)
            : base(name, 50, 500)
        {            
        }

        public override int Fire()
        {
            //The rifle can shoot with 5 bullets            
            if (this.CanFire)
            {
                if (this.BulletsPerBarrel == 0)
                {
                    this.BulletsPerBarrel = GUN_CAPACITY;
                    this.TotalBullets -= GUN_CAPACITY;
                }
                this.BulletsPerBarrel -= 5;
                return 5;
            }
            return 0;
        }
    }
}
