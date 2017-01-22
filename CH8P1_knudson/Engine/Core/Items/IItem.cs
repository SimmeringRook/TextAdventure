using Engine.Core.Creatures;
using Engine.Core.Items.Equipable;
using Engine.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Items
{
    public interface IItem
    {
        EquipmentSlot GetEquipmentSlot();

        void Equip(Player player);

        void UnEquip(IItem currentlyEquipped, Player player);

        string GetFormalName();

    }
}
