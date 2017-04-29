﻿using Engine.Core.Creatures;

namespace Engine.Core.Items.Equipable
{
    public class Weapon : Item, IEquipable
    {
        public EquipmentSlot EquipmentSlot { get { return EquipmentSlot.MainHand; } }
        public double AttackModifier { get; private set; }
        public Weapon(int id, string name, string description, double attackModifier = 0) : base(id, name, description)
        {
            AttackModifier = attackModifier;
        }

        public EquipmentSlot GetEquipmentSlot()
        {
            return EquipmentSlot;
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