using Engine.Core.Creatures;
using Engine.Core.Items;
using Engine.Core.Items.Equipable;
using Engine.Core.World;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Engine.Database.Factories
{
    internal static class ItemFactory
    {
        #region Engine
        internal static List<Item> BuildMasterList()
        {
            List<Item> engineItems = new List<Item>();
            using (AdventureDatabaseEntities context = new AdventureDatabaseEntities())
            {
                context.Items.Load();
                context.Item_Weapon.Load();
                context.Item_Armor.Load();

                foreach (var dbItem in context.Items)
                {
                    var dbArmor = context.Item_Armor.SingleOrDefault(armor => armor.ItemID == dbItem.ItemID);
                    var dbWeapon = context.Item_Weapon.SingleOrDefault(weapon => weapon.ItemID == dbItem.ItemID);

                    if (dbArmor != null)
                        engineItems.Add(Create_Armor_From_Database(dbItem, dbArmor));
                    else if (dbWeapon != null)
                        engineItems.Add(Create_Weapon_From_Database(dbItem, dbWeapon));
                }
            }

            return engineItems;
        }

        #region Armor
        private static Armor Create_Armor_From_Database(Items dbItem, Item_Armor dbArmor)
        {
            switch (dbArmor.EquipmentSlot)
            {
                case "Head":
                    return new HeadArmor(dbItem.ItemID, dbItem.Name, dbItem.Description, dbArmor.EvasionModifer, dbArmor.BlockModifer);
                //case "Chest": //TODO Implement?
                //    break;    
                //case "Legs":
                //    break;
                default:
                    return new Armor(dbItem.ItemID, dbItem.Name, dbItem.Description, dbArmor.EvasionModifer, dbArmor.BlockModifer);
            }
        }
        #endregion
        #region Weapons
        private static Weapon Create_Weapon_From_Database(Items dbItem, Item_Weapon dbWeapon)
        {
            return new Weapon(dbItem.ItemID, dbItem.Name, dbItem.Description, dbWeapon.AttackModifer, dbWeapon.ParryModifer);
        }
        #endregion
        #endregion

        #region Creature
        internal static void GetEquipmentForCreature(Creature creature, int creatureInstanceID)
        {
            using (AdventureDatabaseEntities context = new AdventureDatabaseEntities())
            {
                context.Creature_Equipment.Load();
                var creatureEquipment = context.Creature_Equipment.Where(m => m.CreatureInstanceID == creatureInstanceID).ToList();

                foreach (var equip in creatureEquipment)
                {
                    IEquipable equipment = Instance.MasterItemList.SingleOrDefault(i => i.ID == equip.ItemID) as IEquipable;
                    if (equipment != null)
                        creature.Equipment.Add(equipment.EquipmentSlot, equipment);
                }
            }
        }

        internal static void GetInventoryForCreature(Creature creature, int creatureInstanceID)
        {
            using (AdventureDatabaseEntities context = new AdventureDatabaseEntities())
            {
                context.Creature_Inventory.Load();

                foreach (var monsterItem in context.Creature_Inventory.Where(m => m.CreatureInstanceID == creatureInstanceID))
                {
                    var item = Instance.MasterItemList.SingleOrDefault(i => i.ID == monsterItem.ItemID);
                    if (creature.Inventory.ContainsKey(item))
                        creature.Inventory[item]++;
                    else
                        creature.Inventory.Add(item, 1);
                }

            }
        }
        #endregion
    }
}
