using Engine.Core.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Commands.Executable
{
    public class Get : Command
    {
        public Get(Player player) : base(player)
        {

        }

        public override CommandResult Execute()
        {
            throw new NotImplementedException();

            CommandResult result = new CommandResult();

            return result;
            
        }
    }
}
