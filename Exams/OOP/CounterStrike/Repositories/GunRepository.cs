using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();            
        }
        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();

        public void Add(IGun model)
        {
            if (model==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
            models.Add(model);
        }

        public IGun FindByName(string name) => models.FirstOrDefault(x => x.Name == name);        

        public bool Remove(IGun model)
        {            
            var result = models.FirstOrDefault(x => x.Name == model.Name);
            if (result==null)
            {
                return false;
            }
            else
            {
                models.Remove(model);
                return true;
            }
        }
    }
}
