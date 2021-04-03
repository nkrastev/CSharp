using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> models;
        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => this.models.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model==null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
            this.models.Add(model);
        }

        public IPlayer FindByName(string name) => models.FirstOrDefault(x => x.Username == name);
       

        public bool Remove(IPlayer model)
        {
            var result = models.FirstOrDefault(x => x.Username == model.Username);
            if (result == null)
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
