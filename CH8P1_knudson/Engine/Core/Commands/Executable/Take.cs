using Engine.Core.Creatures;
using Engine.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Commands.Executable
{
    public class Take : Command
    {
        private string itemToLootName;
        public Take(Player player, string itemToLootName) : base(player) 
        {
            this.itemToLootName = itemToLootName;
        }

        public override CommandResult Execute()
        {
            IItem itemToLoot = player.CurrentRoom.GetLootInRoom(itemToLootName);
            if (itemToLoot == null)
                return new CommandResult("There is no [" + itemToLootName + "] in this room.");

            player.Inventory.Add(itemToLoot);
            player.CurrentRoom.LootItem(itemToLoot);
            return new Commands.CommandResult("You pick up the [" + itemToLootName + "]");
        }
    }
}
