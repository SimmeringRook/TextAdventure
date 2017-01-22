using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core.Combat;

namespace Engine.Core.Creatures
{
    public class Creature : IKillable, IAttackable
    {
        public int CurrentHP { get; private set; }
        public int MaxHP { get; private set; }
        public string Name { get; private set; }
        public Dice DamageDie { get; private set; }

        public Creature(int maxHP, string name, Dice damageDice)
        {
            CurrentHP = maxHP;
            MaxHP = maxHP;
            Name = name;
            DamageDie = damageDice;
        }

        public bool IsAlive()
        {
            return (CurrentHP > 0);
        }

        public void TakeDamage(int damage)
        {
            CurrentHP -= damage;
        }

        public CombatResult Attack(Creature target)
        {
            CombatResult results = new CombatResult(this, target);
            Dice hitDice = new Creatures.Dice(20);

            int hitRoll = hitDice.Roll();
            results.LogHitOrMiss(hitRoll);

            if (hitRoll > 10)
            {
                int damage = 0;
                for (int numberOfDie = 1; numberOfDie <= DamageDie.NumberOfDie; numberOfDie++)
                {
                    damage += DamageDie.Roll();
                }

                results.LogDamage(damage, DamageDie);
                target.TakeDamage(damage);
            }
            
            return results;
        }
    }
}
