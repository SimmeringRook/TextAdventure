using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core.World;
using Engine.Core.Items.Equipable;
using Engine.Core.Creatures;

namespace Engine.Core.Items
{
    public class Item : IItem
    {
        public EquipmentSlot EquipmentSlot { get; private set; }
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Item(int id, string name, EquipmentSlot slot = EquipmentSlot.Empty)
        {
            ID = id;
            Name = name;
            EquipmentSlot = slot;
        }

        public string GetFormalName()
        {
            return Name;
        }

        public EquipmentSlot GetEquipmentSlot()
        {
            return EquipmentSlot;
        }

        //TODO: This might need some refactoring
        public void Equip(Player player)
        {
            foreach (KeyValuePair<EquipmentSlot, Item> item in player.Equipment)
            {
                if (this.EquipmentSlot == item.Key)
                {
                    Item currentlyEquipped = player.Equipment[item.Key];
                    player.Equipment[item.Key] = this;
                    UnEquip(currentlyEquipped, player);
                    return;
                }
            }

            player.Equipment[this.EquipmentSlot] = this;
        }

        //TODO: Is this function necessary, or is everything else already be done elsewhere?
        public void UnEquip(IItem itemToUnEquip, Player player)
        {
            //If the item is actually equipped, remove it
            if (player.CheckIfItemIsEquipped(itemToUnEquip))
            {
                player.Equipment[itemToUnEquip.GetEquipmentSlot()] = null;
                player.Inventory.Add(itemToUnEquip);
            }
                
        }

        
    }
}
