using Engine.Core.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Combat
{
    internal static class CombatMap
    {
        private static Random rng = new Random();
        internal static bool IsCriticalHit(IAttackable attacker)
        {
            return (attacker.CritChance >= rng.Next(1, 101));
        }

        internal static bool AttackBlocked(IAttackable defender)
        {
            return (defender.Block >= rng.Next(1, 101));
        }

        internal static bool AttackEvaded(IAttackable defender)
        {
            return (defender.Evasion >= rng.Next(1, 101));
        }

        internal static bool AttackParried(IAttackable defender)
        {
            return (defender.Parry >= rng.Next(1, 101));
        }
    }
}
