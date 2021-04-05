using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<Decoration>
    {
        private List<Decoration> models;
        public DecorationRepository()
        {
            this.models = new List<Decoration>();
        }

        public IReadOnlyCollection<Decoration> Models => this.models.AsReadOnly();

        public void Add(Decoration model) => this.models.Add(model);

        public Decoration FindByType(string type) => this.models.FirstOrDefault(x => x.GetType().Name == type);      

        public bool Remove(Decoration model) => this.models.Remove(model);
    }
}
