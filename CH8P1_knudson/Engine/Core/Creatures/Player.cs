using Engine.Core.World;

namespace Engine.Core.Creatures
{
    public class Player
    {
        public IAttackable Job { get; private set; }
        public int Score { get; private set; }

        public Player(IAttackable job)
        {
            Job = job;
            Score = 0;
        }

        #region Movement
        public Room CurrentRoom { get; private set; }

        public void Move(Room nextDestination)
        {
            CurrentRoom = nextDestination;
        }
        #endregion

        public void AwardPoints(int points)
        {
            Score += points;
            if (Score % 100 < (Job as Creature).Level)
                (Job as Creature).LevelUp();
        }
    }
}
