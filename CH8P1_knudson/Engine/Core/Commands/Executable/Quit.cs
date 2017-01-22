using Engine.Core.Creatures;
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
            CommandResult result = new CommandResult();

            return result;
            throw new NotImplementedException();
        }
    }
}
