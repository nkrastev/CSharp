using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count { get => this.data.Count; }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        //•	Method Remove(string name) – removes an entity by given hero name.
        public void Remove(string name)
        {
            int index = data.FindIndex(x => x.Name == name);
            if (index >= 0)
            {
                data.RemoveAt(index);                
            }
        }
        
        public Hero GetHeroWithHighestStrength() => data.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        public Hero GetHeroWithHighestAbility() => data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        public Hero GetHeroWithHighestIntelligence() => data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //Оverride ToString() – Print all the heroes.
            foreach (var h in data)
            {
                sb.AppendLine($"Hero: {h.Name} - {h.Level}lvl");
                sb.AppendLine($"Item:");
                sb.AppendLine($"    * Strength: {h.Item.Strength}");
                sb.AppendLine($"    * Ability: {h.Item.Ability}");
                sb.AppendLine($"    * Intelligence: {h.Item.Intelligence}");
            }            

            return sb.ToString().TrimEnd();
        }

    }
}
