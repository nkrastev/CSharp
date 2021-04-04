using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Craft(IPresent present, IDwarf dwarf)
        {
        
            foreach (var instrument in dwarf.Instruments)
            {
                while (!instrument.IsBroken())
                {
                    present.GetCrafted();
                    dwarf.Work();
                    instrument.Use();

                    if (present.IsDone())
                    {
                        break;
                    }
                    if (dwarf.Energy == 0)
                    {
                        break;
                    }
                }

            }
        }
    }
}
