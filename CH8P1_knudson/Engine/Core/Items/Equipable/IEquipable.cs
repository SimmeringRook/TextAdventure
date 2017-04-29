using Engine.Core.Creatures;

namespace Engine.Core.Items.Equipable
{
    public interface IEquipable
    {
        EquipmentSlot EquipmentSlot { get; }

        void Equip(Creature creature);

        void UnEquip(IEquipable currentlyEquipped, Creature creature);
    }
}
