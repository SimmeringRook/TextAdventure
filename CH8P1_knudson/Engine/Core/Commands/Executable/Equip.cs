using Engine.Core.Creatures;
using Engine.Core.Items;
using Engine.Core.Items.Equipable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Commands.Executable
{
    public class Equip : Command
    {
        private IItem itemToEquip;
        public Equip(Player player, string itemToEquipName) : base(player)
        {
            itemToEquip = null;
            foreach (IItem item in World.World.MasterItemList)
            {
                if (item.GetFormalName().ToLower().Equals(itemToEquipName.ToLower()))
                    itemToEquip = item;
            }
        }

        public override CommandResult Execute()
        {
            if (itemToEquip == null)
                return new CommandResult("No item exists with that name.");

            if (itemToEquip.GetEquipmentSlot() == EquipmentSlot.Empty)
                return new Commands.CommandResult("That item is not equipable.");

            itemToEquip.Equip(player);
            player.RemoveItemFromInventory(itemToEquip);
            return new Commands.CommandResult("You equip the [" + itemToEquip.GetFormalName() + "].");
        }
    }
}
