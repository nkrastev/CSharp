using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<Dwarf>
    {
        private List<Dwarf> models;

        public DwarfRepository()
        {
            this.models = new List<Dwarf>();
        }

        public IReadOnlyCollection<Dwarf> Models => this.models.AsReadOnly();        

        public void Add(Dwarf model)
        {
            this.models.Add(model);
        }

        public Dwarf FindByName(string name) => models.FirstOrDefault(x => x.Name == name);

        public bool Remove(Dwarf model) => models.Remove(model);
    }
}
