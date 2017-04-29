using Engine.Core.Creatures;
using Engine.Core.Items;
using Engine.Core.Items.Equipable;
using Engine.Core.World;
using System.Linq;

namespace Engine.Core.Commands.Executable
{
    public class Equip : Command
    {
        private IEquipable itemToEquip;
        public Equip(Player player, string itemToEquipName) : base(player)
        {
            itemToEquip = Instance.MasterItemList.SingleOrDefault(item => item.Name.Equals(itemToEquipName)) as IEquipable;
        }

        public override CommandResult Execute()
        {
            if (itemToEquip == null)
                return new CommandResult("No item exists with that name.");

            if (itemToEquip.EquipmentSlot == EquipmentSlot.Empty)
                return new Commands.CommandResult("That item is not equipable.");

            itemToEquip.Equip(player.Job as Creature);
            (player.Job as Creature).Inventory.Remove(itemToEquip as Item);
            return new Commands.CommandResult("You equip the [" + (itemToEquip as Item).Name + "].");
        }
    }
}
