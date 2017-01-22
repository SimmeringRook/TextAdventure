using Engine.Core.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Commands.Executable
{
    public class Score : Command
    {
        public Score(Player player) : base(player)
        {

        }

        public override CommandResult Execute()
        {
            return new CommandResult("Your current score is: [" + player.Score.ToString() +"]");
        }
    }
}
