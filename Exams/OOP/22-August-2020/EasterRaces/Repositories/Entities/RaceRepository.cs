using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> raceRepository;
        public void Add(IRace model)
        {
            raceRepository.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.raceRepository;
        }

        public IRace GetByName(string name)
        {
            return this.raceRepository.Where(x => x.Name == name).FirstOrDefault();
        }

        public bool Remove(IRace model)
        {
            var isThereEntityForRemove = this.raceRepository.Where(x => x.Name == model.Name).FirstOrDefault();

            if (isThereEntityForRemove != null)
            {
                this.raceRepository.RemoveAll(x => x.Name == model.Name);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
