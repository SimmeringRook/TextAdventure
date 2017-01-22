using Engine.Core.Creatures;

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
