using Engine.Core.Combat;
using Engine.Core.Creatures;
using Engine.Core.Creatures.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;

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

            List<IAttackable> actionOrder = GetActionOrder();
            
            foreach (IAttackable attacker in actionOrder)
            {
                IAttackable defender = (attacker == player) ? currentTarget : player;
                if (attacker.IsAlive())
                    combatResults.Add(attacker.Attack(defender));

                if (currentTarget.IsAlive() == false)
                {
                    int pointsToAward = (currentTarget.GetType() == typeof(Monster)) ? (currentTarget as Monster).PointValue : (currentTarget as EliteMonster).PointValue;
                    (player as Player).AwardPoints(pointsToAward);
                    break;
                }
            }
             
            return new CommandResult(combatResults);
        }

        #region Helper Functions
        private List<IAttackable> GetActionOrder()
        {
            List<IAttackable> turnOrder = new List<IAttackable>();
            int numberOfActions = (int)Math.Ceiling(player.Speed / 10);
            for (int i = 0; i < numberOfActions; i++)
                turnOrder.Add(player);

            numberOfActions = (int)Math.Ceiling(currentTarget.Speed / 10);
            for (int i = 0; i < numberOfActions; i++)
                turnOrder.Add(currentTarget);

            turnOrder.OrderBy(attackable => attackable.Speed);

            return turnOrder;
        }
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
