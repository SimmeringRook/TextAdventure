﻿using Engine.Core.Creatures;

namespace Engine.Core.Items.Equipable
{
    public class Armor : Item, IEquipable
    {
        public EquipmentSlot EquipmentSlot { get; protected set; }

        public double EvasionModifier { get; set; }
        public double ParryModifier { get; set; }
        public double BlockModifier { get; set; }

        public Armor(int id, string name, string description, double evasionMod = 0, double parryMod = 0, double blockMod = 0) : base(id, name, description)
        {
            EvasionModifier = evasionMod;
            ParryModifier = parryMod;
            BlockModifier = blockMod;
        }

        public void Equip(Creature creature)
        {
            IEquipable currentlyEquipped = creature.Equipment[this.EquipmentSlot];
            UnEquip(currentlyEquipped, creature);
            creature.Equipment[this.EquipmentSlot] = this;
        }

        public void UnEquip(IEquipable itemToUnEquip, Creature creature)
        {
            if (itemToUnEquip != null)
            {
                creature.Equipment[itemToUnEquip.EquipmentSlot] = null;
                creature.Inventory.Add(itemToUnEquip as Item);
            }
        }
    }
}
