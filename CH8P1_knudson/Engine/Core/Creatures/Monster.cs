using Engine.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Creatures
{
    public class Monster : Creature
    {
        public int PointValue { get; private set; }
        public Monster(int pointValue, int maxHP, string name, Dice damageDice) : base(maxHP, name, damageDice)
        {
            PointValue = pointValue;
        }
    }
}
