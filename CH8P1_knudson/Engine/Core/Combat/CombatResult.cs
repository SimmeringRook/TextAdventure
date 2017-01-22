using Engine.Core.Creatures;
using System.Collections.Generic;
using System.Text;

namespace Engine.Core.Combat
{
    public class CombatResult
    {
        private Creature attacker;
        private Creature defender;
        public List<string> Log { get; private set; }

        public CombatResult(Creature attacker, Creature defender)
        {
            this.attacker = attacker;
            this.defender = defender;
        }

        public void RecordCombat (string record)
        {
            Log.Add(record);
        }

        public void LogHitOrMiss(int hitRoll)
        {
            StringBuilder result = new StringBuilder("[" + attacker.Name + "]");
            if (hitRoll > 10)
            {
                result.Append(" hits [" + defender.Name + "]");
            }
            else
            {
                result.Append(" misses [" + defender.Name + "]");
            }
            result.Append(" with [" + hitRoll.ToString() + "].");
            Log.Add(result.ToString());
        }

        public void LogDamage(int damageDealt, Dice damageDice)
        {
            StringBuilder log = new StringBuilder("[" + attacker.Name + "] deals [" + damageDealt.ToString() + "] damage to [" + defender.Name + "]");
            log.Append(" (" + damageDice.NumberOfDie + "d" + damageDice.NumberOfSides + ").");
            Log.Add(log.ToString());
        }
    }
}
