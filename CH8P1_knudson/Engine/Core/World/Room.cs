﻿using Engine.Core.Creatures;
using Engine.Core.Items;
using System.Collections.Generic;

namespace Engine.Core.World
{
    public class Room
    {
        public string Description { get; private set; }
        public List<IAttackable> MonstersInRoom { get; private set; }
        private Dictionary<Direction, Room> neighbors { get; set; }
        public List<Item> LootInRoom { get; private set; }
        public Room()
        {
            this.LootInRoom = new List<Item>();
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
    }
}
