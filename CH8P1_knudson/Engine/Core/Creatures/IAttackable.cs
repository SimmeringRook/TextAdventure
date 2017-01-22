using Engine.Core.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Creatures
{
    //TODO: Obsolete?
    // Set up for dependency injection, but not use in that capacity
    public interface IAttackable
    {
        CombatResult Attack(Creature target);
    }
}
