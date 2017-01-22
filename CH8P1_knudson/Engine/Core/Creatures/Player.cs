﻿using Engine.Core.Items;
using Engine.Core.Items.Equipable;
using Engine.Core.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Creatures
{
    public class Player : Creature
    {
        public int Score { get; private set; }
        public Room CurrentRoom { get; private set; }
        public List<IItem> Inventory;
        public Dictionary<EquipmentSlot, Item> Equipment { get; private set; }
        public Player(int maxHP, string name, Dice damageDice) : base(maxHP, name, damageDice)
        {
            Inventory = new List<IItem>();
            Equipment = new Dictionary<EquipmentSlot, Item>()
            {
                { EquipmentSlot.Head, null },
                { EquipmentSlot.Chest, null },
                { EquipmentSlot.Legs, null },
                { EquipmentSlot.MainHand, null }
            };
            Score = 0;
        }

        #region Movement
        public void Move(Room nextDestination)
        {
            CurrentRoom = nextDestination;
        }
        #endregion

        #region Inventory Management
        public void RemoveItemFromInventory(IItem item)
        {
            Inventory.Remove(item);
        }

        public bool CheckIfItemIsEquipped(IItem itemToUnEquip)
        {
            Item itemToRemove = null;
            foreach (KeyValuePair<EquipmentSlot, Item> item in Equipment)
            {
                if (item.Value.Name.Equals(itemToUnEquip.GetFormalName()))
                    itemToRemove = item.Value;
            }
            return (itemToRemove != null);
        }
        #endregion

        public void AwardPoints(int points)
        {
            Score += points;
        }
    }
}