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
        public RaceRepository()
        {
            this.raceRepository = new List<IRace>();
        }
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
            return this.raceRepository.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace model)
        {
            var isThereEntityForRemove = this.raceRepository.FirstOrDefault(x => x.Name == model.Name);

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
