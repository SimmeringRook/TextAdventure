using Engine.Core.Combat;
using Engine.Core.Creatures;
using System.Collections.Generic;

namespace Engine.Core.Commands.Executable
{
    public class Attack : Command
    {
        private Monster currentTarget = null;
        public Attack(Player player, string targetName) : base(player)
        {
            if (!string.IsNullOrWhiteSpace(targetName))
                GetMonsterInRoomByName(targetName);
        }
        
        public override CommandResult Execute()
        {
            List<CombatResult> combatResults = new List<CombatResult>();

            if (currentTarget == null)
                GetNextAliveMonsterInRoom(out currentTarget);

            while (player.IsAlive() && currentTarget.IsAlive())
            {
                combatResults.Add(player.Attack(currentTarget));
                if (currentTarget.IsAlive())
                    combatResults.Add(currentTarget.Attack(player));
                else
                    player.AwardPoints(currentTarget.PointValue);
            }

            return new CommandResult(combatResults);
        }

        #region Helper Functions
        private void GetMonsterInRoomByName(string name)
        {
            foreach (Monster monster in player.CurrentRoom.MonstersInRoom)
                if (monster.Name.ToLower().Equals(name.ToLower()))
                    currentTarget = monster;
        }

        private bool GetNextAliveMonsterInRoom(out Monster aliveMonster)
        {
            bool monstersStillAlive = true;
            foreach (Monster monster in player.CurrentRoom.MonstersInRoom)
            {
                if (monster.IsAlive())
                {
                    aliveMonster = monster;
                    return monstersStillAlive;
                }
            }
            aliveMonster = null;
            return false;

        }
        #endregion
    }
}
