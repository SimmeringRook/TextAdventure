using Engine.Core.Creatures;
using Engine.Core.World;
using System;

namespace Engine.Core.Commands.Executable
{
    public class Quit : Command
    {
        public Quit(Player player) : base(player)
        {

        }

        public override CommandResult Execute()
        {
            if (Instance.Save())
                return new CommandResult("The game has sucessfully been saved.");
            return new CommandResult("The game encountered an error while saving.");
        }
    }
}
