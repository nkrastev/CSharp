using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IRider, IRace, IMotorcycle
    {      
        //JUST FOR TEST PURPOSES
        private List<T> entities;
        public void Add(T model) => this.entities.Add(model);

        public IReadOnlyCollection<T> GetAll() => this.entities.AsReadOnly();
     
        public T GetByName(string name)
        {           
            Type typeParameterType = typeof(T);
            if (typeParameterType is IRider)
            {                            
                foreach (var item in entities as List<IRider>)
                {
                    if (item.Name==name) { return (T)item; }
                }
            }
            else if (typeParameterType is IRace)
            {
                foreach (var item in entities as List<IRace>)
                {
                    if (item.Name == name){ return (T)item; }
                }
            }
            else if (typeParameterType is IMotorcycle)
            {
                foreach (var item in entities as List<IMotorcycle>)
                {
                    if (item.Model == name) { return (T)item; }
                }
            }
            return default(T);    
        }

        public bool Remove(T model) => this.entities.Remove(model);
    }
}
