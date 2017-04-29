using Engine.Core.Combat;

namespace Engine.Core.Creatures
{
    public class Creature
    {
        public string Name { get; private set; }

        //Stats
        public int Level { get; protected set; }

        //Base Stats
        protected double BaseMaxHP { get { return (Level * BaseVitality) + 100; } }
        protected double BaseStrength { get { return (Level * 5) + 10; } }
        protected double BaseVitality { get { return (Level * 5) + 10; } }
        protected double BaseDexterity { get { return (Level * 5) + 10; } }

        //Base Combat
        protected double BaseDamage { get { return (Level * 10); } }
        protected double BaseSpeed { get { return (Level * 100) / BaseDexterity; } }
        protected double BaseCritChance { get { return (Level * BaseStrength) / 100; } }

        //Base Defensive
        protected double BaseEvasion { get { return (Level * BaseDexterity) / 100; } }
        protected double BaseParry { get { return (Level * BaseDexterity) / 100; } }
        protected double BaseBlock { get { return (Level * BaseStrength) / 100; } }

        public Creature(string name)
        {
            Name = name;
            Level = 1;
        }

        public Creature(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public virtual void LevelUp()
        {
            Level++;
        }

        public virtual bool IsAlive()
        {
            return true;
        }
    }
}
