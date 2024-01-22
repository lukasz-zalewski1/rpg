using System;
using System.Collections.Generic;

namespace VeganRPG
{
    class Enemy
    {
        // If enemy is boss, his quest and area will disappear right after winning fight
        public bool Boss { get; set; }

        public string Name { get; set; }

        public int Defense { get; set; }
        public Tuple<int, int> Damage { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int Experience { get; set; }
        public Tuple<int, int> Gold { get; set; }
        public List<Tuple<Item, int>> Loot { get; set; }

        public Enemy(string name, int health, Tuple<int, int> damage, int defense,
            int experience, Tuple<int, int> gold, List<Tuple<Item, int>> loot, bool boss = false)
        {
            Boss = boss;

            Name = name;

            MaxHealth = health;
            Health = health;
            Damage = damage;
            Defense = defense;

            Experience = experience;
            Gold = gold;
            Loot = loot;
        }

    }
}
