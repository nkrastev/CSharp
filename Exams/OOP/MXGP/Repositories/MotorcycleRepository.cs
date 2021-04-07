using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model) => this.motorcycles.Add(model);
        
        public IReadOnlyCollection<IMotorcycle> GetAll() => this.motorcycles.AsReadOnly();
        
        public IMotorcycle GetByName(string name) => this.motorcycles.FirstOrDefault(m => m.Model == name);

        public bool Remove(IMotorcycle model) => this.motorcycles.Remove(model);
    }
}
