using Engine.Core.Creatures;
using System;

namespace Engine.Core.Commands.Executable
{
    public class Open : Command
    {
        public Open(Player player) : base(player)
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
