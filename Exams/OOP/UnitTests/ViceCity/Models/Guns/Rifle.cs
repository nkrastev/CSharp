using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private int gunCapacity;
        public Rifle(string name)
            : base(name, 50, 500)
        {
            gunCapacity = 50;
        }

        public override int Fire()
        {
            //The rifle can shoot with 5 bullets
            int bulletsShooted = 0;

            if (this.BulletsPerBarrel >= 5)
            {
                this.BulletsPerBarrel -= 5;
                bulletsShooted = 5;
            }
            else if (this.BulletsPerBarrel == 0)
            {
                //reload
                if (this.TotalBullets > 0)
                {
                    //enought bullets for reload, check if there are for full barrel
                    if (gunCapacity <= this.TotalBullets)
                    {
                        this.BulletsPerBarrel = gunCapacity;
                        this.TotalBullets -= gunCapacity;
                    }
                    else
                    {
                        //not enought for full reload, fill barrel with left bullets in stock
                        this.BulletsPerBarrel = this.TotalBullets;
                        this.TotalBullets = 0;
                    }
                    this.BulletsPerBarrel -= 5;
                    bulletsShooted = 5;
                }
                else
                {
                    //not enought for reload, no bullets in barrel or in stock
                    bulletsShooted = 0;
                }
            }
            return bulletsShooted;
        }
    }
}
