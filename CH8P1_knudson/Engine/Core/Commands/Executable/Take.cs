using Engine.Core.Creatures;
using Engine.Core.Items;
using System.Linq;

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
            Item itemToLoot = player.CurrentRoom.LootInRoom.SingleOrDefault(item => item.Name.Equals(itemToLootName));
            if (itemToLoot == null)
                return new CommandResult("There is no [" + itemToLootName + "] in this room.");

            var thePlayer = (player.Job as Creature);
            if (thePlayer.Inventory.ContainsKey(itemToLoot))
                thePlayer.Inventory[itemToLoot]++;
            else
                thePlayer.Inventory.Add(itemToLoot, 1);

            player.CurrentRoom.LootInRoom.Remove(itemToLoot);
            return new CommandResult("You pick up the [" + itemToLoot.Name + "]");
        }
    }
}
