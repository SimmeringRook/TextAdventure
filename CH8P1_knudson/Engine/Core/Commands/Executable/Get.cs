using Engine.Core.Creatures;
using System;

namespace Engine.Core.Commands.Executable
{
    [Obsolete]
    public class Get : Command
    {
        public Get(Player player) : base(player)
        {
        }

        public override CommandResult Execute()
        {
            throw new NotImplementedException();
        }
    }
}
