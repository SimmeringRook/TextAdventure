using Engine.Core.Creatures;
using Engine.Core.Items.Equipable;

namespace Engine.Core.Items
{
    /// <summary>
    /// Used to facilitate dependency injection when dealing with Items and the player
    /// </summary>
    public interface IItem
    {
        EquipmentSlot GetEquipmentSlot();

        void Equip(Player player);

        void UnEquip(IItem currentlyEquipped, Player player);

        string GetFormalName();

    }
}
