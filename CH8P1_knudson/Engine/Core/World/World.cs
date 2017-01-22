using Engine.Core.Creatures;
using Engine.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.World
{
    public class World
    {
        private static World _instance;
        public static World Instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = WorldGenerator.CreateNewWorld();
                }
                return _instance;
            }

            private set
            {
                _instance = WorldGenerator.CreateNewWorld();
            }
        }

        public Player CurrentPlayer;
        public List<Room> Rooms { get; private set; }
        public static List<IItem> MasterItemList { get; private set; }

        public static void Intialize()
        {
            MasterItemList = new List<IItem>();
            //Read in Items
        }

        public void AssignRoomsToWorld(List<Room> rooms)
        {
            Rooms = rooms;
        }
    }
}
