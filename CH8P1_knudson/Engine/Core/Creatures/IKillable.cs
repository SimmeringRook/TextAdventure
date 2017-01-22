using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Creatures
{
    public interface IKillable
    {
        bool IsAlive();

        void TakeDamage(int damage);

    }
}
