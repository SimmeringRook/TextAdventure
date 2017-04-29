using Engine.Core.Creatures;

namespace Engine.Core.Commands
{
    public abstract class Command : ICommandable
    {
        protected Player player;

        public Command(Player player)
        {
            this.player = player;
        }

        public abstract CommandResult Execute();
    }
}
