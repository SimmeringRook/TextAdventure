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

        public void LogHit(double damage, bool critical = false)
        {
            StringBuilder result = new StringBuilder("[" + attacker.Name + "]");

            if (critical)
                result.Append(" critically");

            result.Append(" hits [" + defender.Name + "]");
            result.Append(" for <" + damage.ToString() + ">");

            if (critical)
                result.Append("!");
            else
                result.Append(".");

            Log.Add(result.ToString());
        }

        public void LogDefended(bool evaded = false, bool blocked = false, bool parried = false)
        {
            StringBuilder result = new StringBuilder("[" + defender.Name + "]");

            if (evaded)
                result.Append(" evaded ");
            else if (blocked)
                result.Append(" blocked ");
            else
                result.Append(" parried ");

            result.Append("the attack!");

            Log.Add(result.ToString());
        }
    }
}
