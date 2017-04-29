using Engine.Core.Creatures;
using Engine.Core.Items;

namespace Engine.Core.Commands.Executable
{
    public class Drop : Command
    {
        private Item itemToDrop;
        public Drop(Player player, Item itemToDrop) : base(player)
        {
            this.itemToDrop = itemToDrop;
        }

        public override CommandResult Execute()
        {
            if (itemToDrop == null)
                return new CommandResult("You don't have any [" + itemToDrop.Name + "].");

            player.CurrentRoom.LootInRoom.Add(itemToDrop);
            (player.Job as Creature).Inventory.Remove(itemToDrop);
            return new CommandResult("You drop the [" + itemToDrop.Name + "] onto the floor.");
        }
    }
}
