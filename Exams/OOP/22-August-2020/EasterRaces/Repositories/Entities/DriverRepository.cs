using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> driversRepository;
        public void Add(IDriver model)
        {
            driversRepository.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.driversRepository;
        }

        public IDriver GetByName(string name)
        {
            return this.driversRepository.Where(x => x.Name == name).FirstOrDefault();
        }

        public bool Remove(IDriver model)
        {
            var isThereEntityForRemove = this.driversRepository.Where(x => x.Name == model.Name).FirstOrDefault();

            if (isThereEntityForRemove != null)
            {
                this.driversRepository.RemoveAll(x => x.Name == model.Name);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
