using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> pool;
		public WarController()
		{
			this.party = new List<Character>();
			this.pool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			//•	characterType – string•	name – string
			string characterType = args[0];
			string name = args[1];

            if (characterType!="Priest" && characterType!="Warrior")
            {
				throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

			Character character = null;
            if (characterType=="Priest")
            {
				character = new Priest(name);
            }
            else if (characterType=="Warrior")
            {
				character = new Warrior(name);
            }
			party.Add(character);
			return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
            if (itemName!="FirePotion" && itemName!="HealthPotion")
            {
				throw new ArgumentException($"Invalid item \"{itemName}\"!");
			}
			Item item = null;
            if (itemName== "FirePotion")
            {
				item = new FirePotion();
            }
            else if (itemName== "HealthPotion")
            {
				item = new HealthPotion();
            }
			pool.Add(item);
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
            if (party.Any(x=>x.Name==characterName))
            {
				throw new ArgumentException($"Character {characterName} not found!");
            }
            if (pool.Count==0)
            {
				throw new InvalidOperationException("No items left in pool!");
            }
			Item lastItem = pool[pool.Count - 1];
			Character character = party.Where(x => x.Name == characterName).FirstOrDefault();
			character.Bag.AddItem(lastItem);
			pool.RemoveAt(pool.Count - 1);
			return $"{characterName} picked up {pool[pool.Count-1].GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			//Makes the character with that name use an item with that name from their bag.
			if (party.Any(x => x.Name == characterName))
			{
				throw new ArgumentException($"Character {characterName} not found!");
			}
			Character character = party.Where(x => x.Name == characterName).FirstOrDefault();
			Item itemInTheBag = character.Bag.GetItem(itemName);
			character.UseItem(itemInTheBag);
			//if it use Item remove it from the bag???
			return $"{characterName} used {itemName}.";
		}

		public string GetStats()
		{
			//Returns info about all characters, sorted by whether they are alive (descending), then by their health (descending)
			party = party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health).ToList();
			StringBuilder sb = new StringBuilder();
            foreach (var item in party)
            {
				string labelAlive = "";
                if (item.IsAlive)
                {
					labelAlive = "Alive";
                }
                else
                {
					labelAlive = "Dead";
                }
				sb.AppendLine($"{item.Name} - HP: {item.Health}/{item.BaseHealth}, AP: {item.Armor}/{item.BaseArmor}, Status: {labelAlive}");
            }
			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];
			//Makes the attacker attack the receiver.
			if (party.Any(x => x.Name == attackerName))
			{
				throw new ArgumentException($"Character {attackerName} not found!");
			}
			if (party.Any(x => x.Name == receiverName))
			{
				throw new ArgumentException($"Character {receiverName} not found!");
			}
			Character attacker = party.Where(x => x.Name == attackerName).FirstOrDefault();
			Character receiver = party.Where(x => x.Name == receiverName).FirstOrDefault();
			
            if (attacker.GetType().Name != "Warrior")
            {
				throw new ArgumentException($"{attacker.Name} cannot attack!");
			}
			//attacher is Warrior
			Warrior warrior = (Warrior)attacker;
			warrior.Attack(receiver);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
				sb.AppendLine($"{receiver.Name} is dead!");
			}
			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];
			
			if (party.Any(x => x.Name == healerName))
			{
				throw new ArgumentException($"Character {healerName} not found!");
			}
			if (party.Any(x => x.Name == healingReceiverName))
			{
				throw new ArgumentException($"Character {healingReceiverName} not found!");
			}
			Character healer = party.Where(x => x.Name == healerName).FirstOrDefault();
			Character receiver = party.Where(x => x.Name == healingReceiverName).FirstOrDefault();

			if (healer.GetType().Name != "Priest")
			{
				throw new ArgumentException($"{healer.Name} cannot heal!");
			}

			Priest priest = (Priest)healer;
			priest.Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

		}
	}
}
