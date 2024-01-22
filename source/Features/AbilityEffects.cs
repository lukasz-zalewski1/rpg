using System;

namespace VeganRPG
{
    // Examples:
    // Ability causes player to do 3 times more damage, then
    // playerDmgMultipler should be set to 3 - 1 = 2, because 1 is basic value and it works additively
    //
    // Ability causes player to do 20 more damage, then
    // playerDmgMin, playerDmgMax should be set to 20

    class AbilityEffects
    {
        public double PlayerDefenseAdded { get; set; }
        public double PlayerDefenseMultipler { get; set; }

        public double PlayerDmgMin { get; set; }
        public double PlayerDmgMax { get; set; }
        public double PlayerDmgMultipler { get; set; }

        public double EnemyDefenseAdded { get; set; }
        public double EnemyDefenseMultipler { get; set; }

        public double EnemyDmgMin { get; set; }
        public double EnemyDmgMax { get; set; }
        public double EnemyDmgMultipler { get; set; }

        public double EnemyGoldMin { get; set; }
        public double EnemyGoldMax { get; set; }
        public double EnemyGoldMultipler { get; set; }

        public double EnemyExperienceAdded { get; set; }
        public double EnemyExperienceMultipler { get; set; }

        public AbilityEffects()
        {
            PlayerDefenseAdded = 0;
            PlayerDefenseMultipler = 1;

            PlayerDmgMin = 0;
            PlayerDmgMax = 0;
            PlayerDmgMultipler = 1;


            EnemyDefenseAdded = 0;
            EnemyDefenseMultipler = 1;

            EnemyDmgMin = 0;
            EnemyDmgMax = 0;
            EnemyDmgMultipler = 1;

            EnemyGoldMin = 0;
            EnemyGoldMax = 0;
            EnemyGoldMultipler = 1;

            EnemyExperienceAdded = 0;
            EnemyExperienceMultipler = 1;
        }

        public AbilityEffects(double playerDefenseAdded, double playerDefenseMultipler, 
            double playerDmgMin, double playerDmgMax, double playerDmgMultipler,
            double enemyDefenseAdded, double enemyDefenseMultipler, 
            double enemyDmgMin, double enemyDmgMax, double enemyDmgMultipler,
            double enemyGoldMin, double enemyGoldMax, double enemyGoldMultipler,
            double enemyExperienceAdded, double enemyExperienceMultipler)
        {
            PlayerDefenseAdded = playerDefenseAdded;
            PlayerDefenseMultipler = playerDefenseMultipler;

            PlayerDmgMin = playerDmgMin;
            PlayerDmgMax = playerDmgMax;
            PlayerDmgMultipler = playerDmgMultipler;


            EnemyDefenseAdded = enemyDefenseAdded;
            EnemyDefenseMultipler = enemyDefenseMultipler;

            EnemyDmgMin = enemyDmgMin;
            EnemyDmgMax = enemyDmgMax;
            EnemyDmgMultipler = enemyDmgMultipler;

            EnemyGoldMin = enemyGoldMin;
            EnemyGoldMax = enemyGoldMax;
            EnemyGoldMultipler = enemyGoldMultipler;

            EnemyExperienceAdded = enemyExperienceAdded;
            EnemyExperienceMultipler = enemyExperienceMultipler;
        }

        public void ApplyEffects(Player player, int basePlayerDefense, Tuple<int, int> basePlayerDamage,
            Enemy enemy, int baseEnemyDefense, Tuple<int, int> baseEnemyDamage,
            Tuple<int, int> baseEnemyGold, int baseEnemyExperience)
        {
            player.Defense = Convert.ToInt32((basePlayerDefense + PlayerDefenseAdded) * PlayerDefenseMultipler);

            player.Damage = new Tuple<int, int>(
                Convert.ToInt32((basePlayerDamage.Item1 + PlayerDmgMin) * PlayerDmgMultipler),
                Convert.ToInt32((basePlayerDamage.Item2 + PlayerDmgMax) * PlayerDmgMultipler));


            enemy.Defense = Convert.ToInt32((baseEnemyDefense + EnemyDefenseAdded) * EnemyDefenseMultipler);

            enemy.Damage = new Tuple<int, int>(
                Convert.ToInt32((baseEnemyDamage.Item1 + EnemyDmgMin) * EnemyDmgMultipler),
                Convert.ToInt32((baseEnemyDamage.Item2 + EnemyDmgMax) * EnemyDmgMultipler));

            enemy.Gold = new Tuple<int, int>(
                Convert.ToInt32((baseEnemyGold.Item1 + EnemyGoldMin) * EnemyGoldMultipler),
                Convert.ToInt32((baseEnemyGold.Item2 + EnemyGoldMax) * EnemyGoldMultipler));

            enemy.Experience = Convert.ToInt32((baseEnemyExperience + EnemyExperienceAdded) * EnemyExperienceMultipler);
        }
    }
}
