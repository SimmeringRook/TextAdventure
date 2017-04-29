using Engine.Core.Combat;
using Engine.Core.Items;
using Engine.Core.Items.Equipable;
using System.Collections.Generic;

namespace Engine.Core.Creatures
{
    public class Creature
    {
        public string Name { get; private set; }
        public int Level { get; protected set; }

        #region Base Stats
        protected double BaseMaxHP { get { return (Level * BaseVitality) + 100; } }
        protected double BaseStrength { get { return (Level * 5) + 10; } }
        protected double BaseVitality { get { return (Level * 5) + 10; } }
        protected double BaseDexterity { get { return (Level * 5) + 10; } }
        #endregion

        #region Offensive Stats
        protected double BaseDamage { get { return (Level * 10); } }
        protected double BaseSpeed { get { return (Level * 100) / BaseDexterity; } }
        protected double BaseCritChance { get { return (Level * BaseStrength) / 100; } }
        #endregion

        #region Defensive Stats
        protected double BaseEvasion { get { return (Level * BaseDexterity) / 100; } }
        protected double BaseParry { get { return (Level * BaseDexterity) / 100; } }
        protected double BaseBlock { get { return (Level * BaseStrength) / 100; } }
        #endregion

        #region Inventory
        public List<Item> Inventory;
        public Dictionary<EquipmentSlot, IEquipable> Equipment { get; private set; }
        #endregion
        public Creature(string name, List<Item> inventory = null, Dictionary<EquipmentSlot, IEquipable> equipment = null)
        {
            Name = name;
            Level = 1;

            Inventory = (inventory != null) ? inventory : new List<Item>();
            Equipment = (equipment != null) ? equipment : new Dictionary<EquipmentSlot, IEquipable>()
            {
                { EquipmentSlot.Head, null },
                { EquipmentSlot.Chest, null },
                { EquipmentSlot.Legs, null },
                { EquipmentSlot.MainHand, null }
            };
        }

        public Creature(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public virtual void LevelUp()
        {
            Level++;
        }
    }
}
