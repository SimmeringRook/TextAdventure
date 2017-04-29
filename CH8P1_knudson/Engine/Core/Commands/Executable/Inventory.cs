using Engine.Core.Creatures;
using Engine.Core.Items;
using System.Collections.Generic;

namespace Engine.Core.Commands.Executable
{
    public class Inventory : Command
    {
        public Inventory(Player player) : base(player)
        {

        }

        public override CommandResult Execute()
        {
            return new CommandResult(CreateShortInventoryList());
        }

        //TODO Refactor?
        private List<string> CreateShortInventoryList()
        {
            Dictionary<Item, int> shortInventory = new Dictionary<Item, int>();

            foreach (Item item in (player.Job as Creature).Inventory)
            {
                if (shortInventory.ContainsKey(item))
                {
                    shortInventory[item] += 1;
                }
                else
                {
                    shortInventory.Add(item, 1);
                }
            }

            List<string> itemsByCount = new List<string>()
            {
                "You have [" + (player.Job as Creature).Inventory.Count + "] items in your bag:"
            };

            foreach (KeyValuePair<Item, int> droppable in shortInventory)
            {
                string line = droppable.Key.Name;
                if (droppable.Value > 1)
                    line += " x" + droppable.Value.ToString();
                itemsByCount.Add(line);
            }

            return itemsByCount;
        }
    }
}
