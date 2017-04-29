﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core.Combat;

namespace Engine.Core.Creatures.Jobs
{
    public class DarkKnight : Creature, IAttackable
    {
        #region Stats
        private double _MainStat { get { return Vitality; } } //Allows me to easily tweak modifiers based off the job's main stat
        public double CurrentHP { get; private set; }
        public double MaxHP { get { return (BaseMaxHP + (BaseMaxHP * (_MainStat / 100))); } }
        public double Strength { get { return BaseStrength + (Level * 3); } }
        public double Vitality { get { return BaseVitality + (Level * 5); } }
        public double Dexterity { get { return BaseDexterity + (Level * 2); } }
        #endregion

        #region Combat Modifiers
        public double Damage { get { return JobModifiedStat(BaseDamage); } }
        public double Speed { get { return JobModifiedStat(BaseSpeed, 200); } }
        public double CritChance { get { return JobModifiedStat(BaseCritChance, 200); } }
        #endregion

        #region Defense Modifiers
        public double Evasion { get { return JobModifiedStat(BaseEvasion, 1000); } }
        public double Parry { get { return JobModifiedStat(BaseParry, 100); } }
        public double Block { get { return JobModifiedStat(BaseBlock, 200); } }
        #endregion

        private double JobModifiedStat(double baseStat, double jobModifier = 100)
        {
            //TODO, refactor to account for gear
            return (baseStat + (baseStat * (_MainStat / jobModifier)));
        }

        public DarkKnight(string name) : base(name)
        {
            CurrentHP = MaxHP;
        }

        public override void LevelUp()
        {
            base.LevelUp();
            CurrentHP = MaxHP;
        }

        public new bool IsAlive()
        {
            return (CurrentHP > 0);
        }

        public void TakeDamage(double damage)
        {
            CurrentHP -= damage;
        }

        public CombatResult Attack(IAttackable target)
        {
            CombatResult results = new CombatResult(this, target);

            if(CombatMap.IsCriticalHit(this as IAttackable))
            {
                double critDamage = this.Damage * 1.5;
                target.TakeDamage(critDamage);
            }
            else if (CombatMap.AttackEvaded(target))
            {

            }
            else if (CombatMap.AttackBlocked(target))
            {

            }
            else if (CombatMap.AttackParried(target))
            {

            }
            else
            {
                target.TakeDamage(this.Damage);
            }

            return results;
        }
    }
}