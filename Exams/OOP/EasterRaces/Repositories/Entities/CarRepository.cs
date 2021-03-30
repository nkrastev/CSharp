using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Contracts
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> carsRepository;
        public CarRepository()
        {
            this.carsRepository = new List<ICar>();
        }
        public void Add(ICar model)
        {
            carsRepository.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.carsRepository;
        }

        public ICar GetByName(string name)
        {
            return this.carsRepository.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(ICar model)
        {
            var isThereEntityForRemove = this.carsRepository.FirstOrDefault(x => x.Model == model.Model);

            if (isThereEntityForRemove!=null)
            {
                this.carsRepository.RemoveAll(x => x.Model == model.Model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
