using Engine.Core.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Creatures
{
    public interface IAttackable
    {
        CombatResult Attack(Creature target);
    }
}
