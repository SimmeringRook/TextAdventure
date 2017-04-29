using Engine.Core.Combat;

namespace Engine.Core.Creatures
{

    public interface IAttackable
    {
        #region Combat Modifiers
        double Damage { get; }
        double Speed { get; }
        double CritChance { get; }
        #endregion

        #region Defense Modifiers
        double Evasion { get; }
        double Parry { get; }
        double Block { get; }
        #endregion
        CombatResult Attack(IAttackable target);

        bool IsAlive();
        void TakeDamage(double damage);
    }
}
