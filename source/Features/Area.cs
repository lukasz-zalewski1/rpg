using System;
using System.Collections.Generic;
using System.Linq;

namespace VeganRPG
{
    class Area
    {
        readonly Random randomizer;

        public string Name {  get; set; }

        // Tuple with Enemy and chance to draw it from the list
        // Chance 10 means 1/10 chance
        // Chance 1 means 1/1 chance
        // Every area should contain one enemy with chance 1
        internal List<Tuple<Enemy, int>> Enemies { get; set; }

        public Area(string name, List<Tuple<Enemy, int>> enemies)
        {
            randomizer = new Random();

            Name = name;
            Enemies = enemies.OrderByDescending(x => x.Item2).ToList();
        }

        public Enemy LookForEnemy()
        {
            foreach (var enemy in Enemies)
            {
                if (randomizer.Next(enemy.Item2) == 0) return enemy.Item1;
            }

            return Enemies.Last().Item1;
        }      
    }
}
