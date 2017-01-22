using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Core.Creatures
{
    public class Dice
    {
        public int NumberOfDie { get; private set; }
        public int NumberOfSides { get; private set; }

        private Random rng { get; set; }

        public Dice(int sides)
        {
            NumberOfSides = sides;
            NumberOfDie = 1;
            rng = new Random();
        }

        public Dice(int sides, int rngSeed)
        {
            NumberOfSides = sides;
            NumberOfDie = 1;
            rng = new Random(rngSeed);
        }

        public Dice(int sides, int rngSeed, int die)
        {
            NumberOfSides = sides;
            NumberOfDie = die;
            rng = new Random(rngSeed);
        }

        public int Roll()
        {
            return rng.Next(1, NumberOfSides + 1);
        }
    }
}
