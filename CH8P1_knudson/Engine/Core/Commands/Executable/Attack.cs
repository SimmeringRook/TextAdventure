using Engine.Core.Combat;
using Engine.Core.Creatures;
using Engine.Core.Creatures.Enemies;
using System.Collections.Generic;

namespace Engine.Core.Commands.Executable
{
    public class Attack : Command
    {
        private IAttackable currentTarget = null;
        public Attack(IAttackable player, string targetName) : base(player)
        {
            if (!string.IsNullOrWhiteSpace(targetName))
                GetMonsterInRoomByName(targetName);
        }
        
        public override CommandResult Execute()
        {
            List<CombatResult> combatResults = new List<CombatResult>();
            
            if (currentTarget == null)
                GetNextAliveMonsterInRoom(out currentTarget);

            IAttackable goesFirst = (currentTarget.Speed < player.Speed) ? currentTarget : player;
            IAttackable goesNext = (currentTarget.Speed >= player.Speed) ? currentTarget : player;

            combatResults.Add(goesFirst.Attack(goesNext));
            if (goesNext.IsAlive())
                combatResults.Add(goesNext.Attack(goesFirst));

            if (currentTarget.IsAlive() == false)
            {
                int pointsToAward = (currentTarget.GetType() == typeof(Monster)) ? (currentTarget as Monster).PointValue : (currentTarget as EliteMonster).PointValue;
                (player as Player).AwardPoints(pointsToAward);
            }
                
            return new CommandResult(combatResults);
        }

        #region Helper Functions
        private void GetMonsterInRoomByName(string name)
        {
            foreach (IAttackable monster in (player as Player).CurrentRoom.MonstersInRoom)
            {
                Creature monsterAsCreature = monster as Creature;
                if (monsterAsCreature.Name.ToLower().Equals(name.ToLower()))
                    currentTarget = monster as IAttackable;
            }  
        }

        private bool GetNextAliveMonsterInRoom(out IAttackable aliveMonster)
        {
            foreach (IAttackable monster in (player as Player).CurrentRoom.MonstersInRoom)
            {
                if (monster.IsAlive())
                {
                    aliveMonster = monster;
                    return true;
                }
            }

            aliveMonster = null;
            return false;

        }
        #endregion
    }
}
