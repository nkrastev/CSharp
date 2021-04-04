using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<Present>
    {
        private List<Present> models;

        public PresentRepository()
        {
            this.models = new List<Present>();
        }
        public IReadOnlyCollection<Present> Models => this.models.AsReadOnly();

        public void Add(Present model) => this.models.Add(model);

        public Present FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);

        public bool Remove(Present model) => this.models.Remove(model);
    }
}
