using Engine.Core.Creatures;
using Engine.Core.Items;

namespace Engine.Core.Commands.Executable
{
    public class Drop : Command
    {
        private IItem itemToDrop;
        public Drop(Player player, IItem itemToDrop) : base(player)
        {
            this.itemToDrop = itemToDrop;
        }

        public override CommandResult Execute()
        {
            if (itemToDrop == null)
                return new CommandResult();

            player.CurrentRoom.DropItemInRoom(itemToDrop);
            player.RemoveItemFromInventory(itemToDrop);
            return new CommandResult("You drop the [" + itemToDrop.GetFormalName() + "] onto the floor.");
        }
    }
}
