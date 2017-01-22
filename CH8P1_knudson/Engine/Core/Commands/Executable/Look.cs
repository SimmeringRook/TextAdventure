using Engine.Core.Creatures;

namespace Engine.Core.Commands.Executable
{
    public class Look : Command
    {
        public Look(Player player) : base(player)
        {
        }

        public override CommandResult Execute()
        {
            return new CommandResult(player.CurrentRoom.Description);
        }
    }
}
