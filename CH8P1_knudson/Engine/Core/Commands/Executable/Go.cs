using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core.Creatures;
using Engine.Core.World;

namespace Engine.Core.Commands.Executable
{
    public class Go : Command
    {
        private Direction directionToMove;

        public Go(Player player, Direction directionToMove) : base(player)
        {
            this.directionToMove = directionToMove;
        }

        public override CommandResult Execute()
        {
            Room destination = player.CurrentRoom.GetNeighbor(directionToMove);
            player.Move(destination);
            return new CommandResult("You move into the room to the [" + directionToMove.ToString() + "].");
        }
    }
}
