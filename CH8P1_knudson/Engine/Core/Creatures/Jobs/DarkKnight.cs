using Engine.Core.Combat;
using Engine.Core.Items.Equipable;

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
        public double Damage
        {
            get
            {
                return JobModifiedStat(BaseDamage) + ((Equipment[EquipmentSlot.MainHand] as Weapon).AttackModifier * Level);
            }
        }
        public double Speed { get { return JobModifiedStat(BaseSpeed, 200); } }
        public double CritChance { get { return JobModifiedStat(BaseCritChance, 200); } }
        #endregion

        #region Defense Modifiers
        public double Evasion { get { return JobModifiedStat(BaseEvasion, 1000) + _BonusEvasionFromEquipment; } }
        private double _BonusEvasionFromEquipment
        {
            get
            {
                double evasion = 0.0;
                foreach(var kvp in Equipment)
                    if (kvp.Value != null)
                        evasion += (kvp.Value as Armor).EvasionModifier;
                return evasion;
            }
        }
        public double Parry { get { return JobModifiedStat(BaseParry, 100) + _BonusParryFromEquipment; } }
        private double _BonusParryFromEquipment
        {
            get
            {
                return (Equipment[EquipmentSlot.MainHand] as Weapon).ParryModifier;
            }
        }
        public double Block { get { return JobModifiedStat(BaseBlock, 200) + _BonusBlockFromEquipment; } }
        private double _BonusBlockFromEquipment
        {
            get
            {
                double block = 0.0;
                foreach (var kvp in Equipment)
                    if (kvp.Value != null)
                        block += (kvp.Value as Armor).BlockModifier;
                return block;
            }
        }
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

        public bool IsAlive()
        {
            return (CurrentHP > 0);
        }

        public void TakeDamage(double damage)
        {
            CurrentHP -= damage;
        }

        public CombatResult Attack(IAttackable target)
        {
            CombatResult results = new CombatResult(this as Creature, target as Creature);

            if(CombatMap.IsCriticalHit(this as IAttackable))
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
    }
}
