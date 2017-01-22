using System;

namespace Engine.Core.Creatures
{
    public class Dice
    {
        public int NumberOfDie { get; private set; }
        public int NumberOfSides { get; private set; }

        private Random rng { get; set; }

        public Dice(int sides, int die = 1, int rngSeed = 0)
        {
            NumberOfSides = sides;
            NumberOfDie = die;

            if (rngSeed == 0)
                rng = new Random();
            else
                rng = new Random(rngSeed);
        }

        /// <summary>
        /// Roll the die
        /// </summary>
        /// <returns></returns>
        public int Roll()
        {
            return rng.Next(1, NumberOfSides + 1);
        }
    }
}
