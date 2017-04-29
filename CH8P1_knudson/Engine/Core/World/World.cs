using Engine.Core.Creatures;
using Engine.Core.Items;
using System.Collections.Generic;

namespace Engine.Core.World
{
    public static class Instance
    {
        public static Player CurrentPlayer;
        public static List<Room> Rooms { get; private set; }
        public static List<Item> MasterItemList { get; private set; }

        public static void Intialize()
        {
            MasterItemList = new List<Item>();
            //Read in Items
        }

        public static void AssignRoomsToWorld(List<Room> rooms)
        {
            Rooms = rooms;
        }
    }
}
