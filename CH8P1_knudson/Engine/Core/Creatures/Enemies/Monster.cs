﻿using System.Collections.Generic;
using Engine.Core.Combat;
using Engine.Core.Items.Equipable;
using Engine.Core.Items;

namespace Engine.Core.Creatures.Enemies
{
    public class Monster : Creature, IAttackable
    {
        //TODO refactor to be more generic and not based off of DarkKnight
        #region Stats
        private double _MainStat { get; set; } //Allows me to easily tweak modifiers based off the job's main stat
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

        public Monster(string mainStat, string name, int level = 1) : base(name, level)
        {
            switch (mainStat)
            {
                case "Strength":
                    _MainStat = Strength;
                    break;
                case "Vitality":
                    _MainStat = Vitality;
                    break;
                case "Dexterity":
                    _MainStat = Dexterity;
                    break;
            }
            CurrentHP = MaxHP;   
        }

        internal Monster(string name, string mainStat, Dictionary<Item, int> inventory, Dictionary<EquipmentSlot, IEquipable> equipment) : base(name, inventory, equipment)
        {
            switch (mainStat)
            {
                case "Strength":
                    _MainStat = Strength;
                    break;
                case "Vitality":
                    _MainStat = Vitality;
                    break;
                case "Dexterity":
                    _MainStat = Dexterity;
                    break;
            }
            CurrentHP = MaxHP;
        }

        public int PointValue { get { return (Level * 50); } }

        public CombatResult Attack(IAttackable target)
        {
            CombatResult results = new CombatResult(this as Creature, target as Creature);

            if (CombatMap.IsCriticalHit(this as IAttackable))
            {
                double critDamage = this.Damage * 1.5;
                target.TakeDamage(critDamage);
                results.LogHit(critDamage, true);
            }
            else if (CombatMap.AttackEvaded(target))
            {
                results.LogDefended(evaded: true);
            }
            else if (CombatMap.AttackBlocked(target))
            {
                results.LogDefended(blocked: true);
            }
            else if (CombatMap.AttackParried(target))
            {
                results.LogDefended(parried: true);
            }
            else
            {
                target.TakeDamage(this.Damage);
                results.LogHit(this.Damage);
            }

            return results;
        }

        public void TakeDamage(double damage)
        {
            CurrentHP -= MaxHP;
        }

        public bool IsAlive()
        {
            return (CurrentHP > 0);
        }
    }
}
