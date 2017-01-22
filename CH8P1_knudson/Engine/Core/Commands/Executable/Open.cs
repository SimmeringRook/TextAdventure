using Engine.Core.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
