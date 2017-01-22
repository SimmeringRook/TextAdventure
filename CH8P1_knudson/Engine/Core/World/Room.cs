using Engine.Core.Creatures;
using Engine.Core.Items;
using System.Collections.Generic;

namespace Engine.Core.World
{
    public class Room
    {
        public string Description { get; private set; }
        public List<Monster> MonstersInRoom { get; private set; }
        private Dictionary<Direction, Room> neighbors { get; set; }
        public List<IItem> LootInRoom { get; private set; }
        public Room()
        {
            this.LootInRoom = new List<IItem>();
            neighbors = new Dictionary<Direction, Room>();
        }

        public Room GetNeighbor(Direction direction)
        {
            return neighbors[direction];
        }

        public void AssignNeighbor(Room neighbor, Direction direction)
        {
            neighbors.Add(direction, neighbor);
        }

        public IItem GetLootInRoom(string itemName)
        {
            IItem loot = null;
            foreach (IItem item in LootInRoom)
            {
                if (itemName.ToLower().Equals(item.GetFormalName().ToLower()))
                    loot = item;
            }
            return loot;
        }

        public void DropItemInRoom(IItem droppedItem)
        {
            LootInRoom.Add(droppedItem);
        }

        public void LootItem(IItem lootedItem)
        {
            LootInRoom.Remove(lootedItem);
        }
    }
}
