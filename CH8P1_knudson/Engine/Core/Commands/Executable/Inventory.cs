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

        private List<string> CreateShortInventoryList()
        {
            List<string> itemsByCount = new List<string>()
            {
                "You have [" + (player.Job as Creature).Inventory.Count + "] items in your bag:"
            };

            foreach (var item in (player.Job as Creature).Inventory)
            {
                string line = item.Key.Name;
                if (item.Value > 1)
                    line += " x" + item.Value.ToString();
                itemsByCount.Add(line);
            }

            return itemsByCount;
        }
    }
}
