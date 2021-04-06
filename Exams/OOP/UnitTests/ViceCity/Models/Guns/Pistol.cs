using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int GUN_CAPACITY = 10;
        public Pistol(string name)
            : base(name, 10, 100)
        {

        }

        public override int Fire()
        {
            //The pistol shoots only one bullet.
            if (this.CanFire)
            {
                if (this.BulletsPerBarrel == 0)
                {
                    this.BulletsPerBarrel = GUN_CAPACITY;
                    this.TotalBullets -= GUN_CAPACITY;
                }
                this.BulletsPerBarrel -= 1;
                return 1;
            }
            return 0;
        }
    }
}
