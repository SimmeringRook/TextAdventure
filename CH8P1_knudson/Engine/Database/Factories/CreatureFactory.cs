using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Engine.Core.Creatures;
using Engine.Core.Creatures.Enemies;

namespace Engine.Database.Factories
{
    internal static class CreatureFactory
    {
        #region Engine Objects

        internal static List<Creature> LoadMonstersForRoom(int seed, int roomID)
        {
            List<Creature> monsterForRoom = new List<Creature>();

            using(AdventureDatabaseEntities context = new AdventureDatabaseEntities())
            {
                context.CreatureTemplates.Load();
                context.Creatures.Load();

                var monsterTemplates = context.CreatureTemplates.Where(temp => 
                temp.JobName.Equals(Job.Monster.ToString())
                ).ToList();

                var monstersInRoom = context.Creatures.Where(c => c.Seed == seed && c.RoomID == roomID).ToList();

                foreach (var template in monsterTemplates)
                {
                    foreach (var monster in monstersInRoom)
                    {
                        Job job = (Job)Enum.Parse(typeof(Job), template.JobName);
                        monsterForRoom.Add(Load_Monster_From_Database(monster, job));
                    }
                }
            }

            return monsterForRoom;
        }

        internal static Creature Load_Monster_From_Database(Creatures creature, Job monsterJob)
        {
            Creature engineMonster = (monsterJob == Job.Monster) ?
                new Monster("Strength", creature.Name) as Creature:
                new EliteMonster("Strength", creature.Name) as Creature;

            Level_Creature(engineMonster, creature.Score);
            ItemFactory.GetInventoryForCreature(engineMonster, creature.CreatureInstanceID);
            ItemFactory.GetEquipmentForCreature(engineMonster, creature.CreatureInstanceID);

            return engineMonster;
        }

        private static void Level_Creature(Creature creature, int score)
        {
            for (int i = 0; i < (score % 100); i++)
                creature.LevelUp();
        }
        #endregion

        #region Database Objects

        #endregion
    }
}
