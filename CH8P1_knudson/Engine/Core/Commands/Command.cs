using Engine.Core.Creatures;

namespace Engine.Core.Commands
{
    public abstract class Command : ICommandable
    {
        protected IAttackable player;

        public Command(IAttackable player)
        {
            this.player = player;
        }

        public abstract CommandResult Execute();
    }
}
