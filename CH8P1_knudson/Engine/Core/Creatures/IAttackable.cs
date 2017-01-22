using Engine.Core.Combat;

namespace Engine.Core.Creatures
{
    //TODO: Obsolete?
    // Set up for dependency injection, but not use in that capacity
    public interface IAttackable
    {
        CombatResult Attack(Creature target);
    }
}
