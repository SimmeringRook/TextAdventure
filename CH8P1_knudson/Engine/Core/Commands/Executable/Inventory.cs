using Engine.Core.Creatures;
using Engine.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private List<string> CreateShortInventoryList()
        {
            Dictionary<IItem, int> shortInventory = new Dictionary<Items.IItem, int>();

            foreach (IItem droppable in player.Inventory)
            {
                if (shortInventory.ContainsKey(droppable))
                {
                    shortInventory[droppable] += 1;
                }
                else
                {
                    shortInventory.Add(droppable, 1);
                }
            }

            List<string> itemsByCount = new List<string>()
            {
                "You have [" + player.Inventory.Count + "] items in your bag:"
            };

            foreach (KeyValuePair<IItem, int> droppable in shortInventory)
            {
                string line = droppable.Key.GetFormalName();
                if (droppable.Value > 1)
                    line += " x" + droppable.Value.ToString();
                itemsByCount.Add(line);
            }

            return itemsByCount;
        }
    }
}
