using Engine.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.World
{
    public static class WorldGenerator
    {
        public static World CreateNewWorld()
        {
            World worldBeingBuilt = new World();
            World.Intialize();

            List<Room> rooms = GenerateRooms(worldBeingBuilt);
            worldBeingBuilt.AssignRoomsToWorld(rooms);

            return worldBeingBuilt;
        }

        #region Room Generation
        private static List<Room> GenerateRooms(World worldBeingBuilt)
        {
            List<Room> rooms = new List<Room>();
            Random rngHelper = new Random();

            while (rooms.Count < 10)
            {
                Room currentRoom = null;

                //If there are no rooms, create an empty one to start the dungeon
                //Otherwise, randomly choose a room that has already been created to continue the dungeon
                if (rooms.Count < 1)
                    currentRoom = new Room();
                else
                    currentRoom = rooms[rngHelper.Next(0, rooms.Count)];

                //Decide if the room will contain loot on the floor
                if (rngHelper.Next(0, 4) % 2 == 0)
                    currentRoom.DropItemInRoom(World.MasterItemList[rngHelper.Next(0, World.MasterItemList.Count)]);

                //Determine the number of Neighbors that currentRoom will have (minimum 1, max 4)
                int numberOfNeighbors = rngHelper.Next(1, 5);
                //Create the neighbors
                for (int neighbor = 1; neighbor <= numberOfNeighbors; neighbor++)
                {
                    //TODO: prevent multiple neighbors in the same direction
                    Direction connectionToNeighbor = ConvertIntToDirection(rngHelper.Next(1, 5));
                    Room neighboringRoom = new Room();

                    //Determine neighboringRoom's chance at having loot - probabilty is 2 out of 5
                    if (rngHelper.Next(0, 10) <= 3)
                        neighboringRoom.DropItemInRoom(World.MasterItemList[rngHelper.Next(0, World.MasterItemList.Count)]);

                    //Link rooms to eachother
                    currentRoom.AssignNeighbor(neighboringRoom, connectionToNeighbor);
                    neighboringRoom.AssignNeighbor(currentRoom, GetOpposingDirection(connectionToNeighbor));


                    rooms.Add(neighboringRoom);
                }
                rooms.Add(currentRoom);
            }

            return rooms;
        }

        private static Direction ConvertIntToDirection(int i)
        {
            switch(i)
            {
                case 1:
                    return Direction.North;
                case 2:
                    return Direction.East;
                case 3:
                    return Direction.South;
                default:
                    return Direction.West;
            }
        }

        private static Direction GetOpposingDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return Direction.South;
                case Direction.South:
                    return Direction.North;
                case Direction.East:
                    return Direction.West;
                default:
                    return Direction.East;
            }
        }
        #endregion
    }
}
