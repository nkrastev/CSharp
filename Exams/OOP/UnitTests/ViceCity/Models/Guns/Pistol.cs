using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private int gunCapacity;
        public Pistol(string name) 
            : base(name, 10, 100)
        {
            gunCapacity = 10;
        }

        public override int Fire()
        {
            //The pistol shoots only one bullet.
            int bulletsShooted = 0;
            
            if (this.BulletsPerBarrel>=1)
            {
                this.BulletsPerBarrel -= 1;
                bulletsShooted = 1;
            }
            else if (this.BulletsPerBarrel==0)
            {
                //reload
                if (this.TotalBullets>0)
                {
                    //enought bullets for reload, check if there are for full barrel
                    if (gunCapacity<=this.TotalBullets)
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
                    this.BulletsPerBarrel -= 1;
                    bulletsShooted = 1;                    
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
