using System.Collections.Generic;
using System.Linq;
using System;

namespace VeganRPG
{
    public partial class Game
    {
        #region Abilities
        bool UseAbility(List<Ability> possibleAbilities, ref List<Ability> abilitiesInUse, ref AbilityEffects abilityEffectsCombined)
        {
            if (possibleAbilities.Count == 0)
            {
                DisplayAbilitiesCantUseInfo();

                return false;
            }

            int site = 0;
            int maxSite;

            while (true)
            {
                maxSite = (possibleAbilities.Count - 1) / 7;
                if (site > maxSite) site = maxSite;

                DisplayAbilitiesMenu(possibleAbilities, site, maxSite);

                int decision = Util.KeyboardKeyToInt(Console.ReadKey());

                Console.Clear();

                if (decision == 0) break;
                else if (site > 0 && decision == 8) site -= 1;
                else if (site < maxSite && decision == 9) site += 1;
                else if (decision > 0 && decision < 8)
                {
                    if (FinallyUseAbility(possibleAbilities, abilitiesInUse, ref abilityEffectsCombined, decision, site)) return true;
                }
            }

            return false;
        }

        void DisplayAbilitiesCantUseInfo()
        {
            Util.WriteColorString("@15|You can't use any @11|ability");

            Console.ReadKey();
        }

        void DisplayAbilitiesMenu(List<Ability> possibleAbilities, int site, int maxSite)
        {
            Console.Clear();

            DisplayAbilitiesMenuPlayerInfo();

            for (int i = 0; i < 7; ++i)
            {
                if (possibleAbilities.Count <= i + (site * 7)) break;

                Util.Write(i + 1 + ". ");
                possibleAbilities[i + (site * 7)].Info();
                Util.Write("\n");
            }

            if (site > 0) Util.WriteLine("8. Previous site");
            if (site < maxSite) Util.WriteLine("9. Next site");

            Util.WriteLine("\n0. Exit");
        }

        void DisplayAbilitiesMenuPlayerInfo()
        {
            Util.WriteLine("You");
            Util.WriteColorString("@12|Health@15|: @12|" + player.Health + "@15| / @12|" +
                                  player.MaxHealth + "\n");
            Util.WriteColorString("@13|Damage@15|: @13|" + player.Damage.Item1 + "@15| - @13|" +
                                  player.Damage.Item2 + "\n");
            Util.WriteColorString("@5|Defense@15|: @5|" + player.Defense + "\n");
            Util.WriteColorString("@11|Ability points@15|: @11|" + player.Ap + "@15| / @11|" +
                                  (player.Level * player.ApPerLevel) + "\n");
            Util.WriteColorString("@11|\nAbilities@15|:\n");
        }

        bool FinallyUseAbility(List<Ability> possibleAbilities, List<Ability> abilitiesInUse, ref AbilityEffects abilityEffectsCombined, int decision, int site)
        {
            if (decision + (site * 7) < possibleAbilities.Count + 1)
            {
                if (player.Ap < possibleAbilities[decision - 1 + (site * 7)].Cost)
                    DisplayNotEnoughApInfo();
                else
                {
                    Util.WriteColorString("@15|You used @11|" + possibleAbilities[decision - 1 + (site * 7)].Name +
                                          "@15| for @11|" + possibleAbilities[decision - 1 + (site * 7)].Cost +
                                          " ability points\n");

                    Console.ReadKey();

                    player.Ap -= possibleAbilities[decision - 1 + (site * 7)].Cost;

                    abilitiesInUse.Add(possibleAbilities[decision - 1 + (site * 7)]);

                    possibleAbilities[decision - 1 + (site * 7)].Use(ref abilityEffectsCombined);
                    possibleAbilities.Remove(possibleAbilities[decision - 1 + (site * 7)]);

                    return true;
                }
            }

            return false;
        }

        void DisplayNotEnoughApInfo()
        {
            Util.WriteColorString("@15|You don't have enough @11|ability points\n");

            Console.ReadKey();
        }
        #endregion Abilities

        #region Fight
        bool Fight(Enemy enemy)
        {
            bool won = false;

            Tuple<int, int> playerDamage = player.Damage;
            int playerDefense = player.Defense;

            Tuple<int, int> enemyDamage = enemy.Damage;
            int enemyDefense = enemy.Defense;
            Tuple<int, int> enemyGold = enemy.Gold;
            int enemyExperience = enemy.Experience;

            int maxTimesConsuming = (player.Level / 4) + 1;
            int maxTimesUsingAbility = (player.Level / 4) + 1;

            int timesConsumed = 0;
            int abilitiesUsed = 0;

            List<Ability> learntAbilities = abilities.Where(x => player.Level >= x.Level).
                Where(y => player.Level <= y.MaxLevel).ToList();
            List<Ability> abilitiesInUse = new List<Ability>();
            AbilityEffects abilityEffectsCombined = new AbilityEffects();

            won = FightInProgress(enemy, ref timesConsumed, maxTimesConsuming, ref abilitiesUsed,
                maxTimesUsingAbility, learntAbilities, abilitiesInUse, ref abilityEffectsCombined,
                playerDefense, playerDamage, enemyDefense, enemyDamage, enemyGold, enemyExperience);

            RestorePlayersStatsAfterFight(playerDamage, playerDefense, enemy, enemyDamage, enemyDefense, enemyGold, enemyExperience);

            return won;
        }

        bool FightInProgress(Enemy enemy, ref int timesConsumed, int maxTimesConsuming,
            ref int abilitiesUsed, int maxTimesUsingAbility, List<Ability> learntAbilities,
            List<Ability> abilitiesInUse, ref AbilityEffects abilityEffectsCombined,
            int playerDefense, Tuple<int, int> playerDamage,
            int enemyDefense, Tuple<int, int> enemyDamage, Tuple<int, int> enemyGold, int enemyExperience)
        {
            while (true)
            {
                DisplayFightMenu(enemy, timesConsumed, maxTimesConsuming, abilitiesUsed, maxTimesUsingAbility, learntAbilities);

                var decision = Util.KeyboardKeyToInt(Console.ReadKey());

                Util.Write("\n\n");

                if (decision == 1) PlayerHitEnemy(enemy);
                else if (decision == 2 && timesConsumed < maxTimesConsuming && player.Consumables.Count > 0)
                {
                    FightConsume(ref timesConsumed);
                    continue;
                }
                else if (decision == 3 && abilitiesUsed < maxTimesUsingAbility && learntAbilities.Count > 0)
                {
                    FightUseAbility(learntAbilities, abilitiesInUse, ref abilityEffectsCombined, ref abilitiesUsed,
                        playerDefense, playerDamage, enemy, enemyDefense, enemyDamage, enemyGold, enemyExperience);
                    continue;
                }
                else continue;

                if (enemy.Health <= 0)
                {
                    PlayerWinningAward(enemy);
                    return true;
                }

                EnemyHitPlayer(enemy);

                if (player.Health <= 0)
                {
                    PlayerLosingPenalty(enemy);

                    return false;
                }

                Console.ReadKey();

                ApplyAllAbilitiesEffects(abilitiesInUse, ref abilityEffectsCombined, playerDefense, playerDamage,
                    enemy, enemyDefense, enemyDamage, enemyGold, enemyExperience);
            }
        }

        void DisplayFightMenu(Enemy enemy, int timesConsumed, int maxTimesConsuming, int abilitiesUsed, int maxTimesUsingAbility, List<Ability> learntAbilities)
        {
            Console.Clear();

            DisplayFightPlayerInfo();
            DisplayFightEnemyInfo(enemy);

            Util.WriteLine("\n\n1. Hit");
            if (timesConsumed < maxTimesConsuming && player.Consumables.Count > 0)
                Util.WriteColorString("@15|2. @14|Consume\n");
            if (abilitiesUsed < maxTimesUsingAbility && learntAbilities.Count > 0)
                Util.WriteColorString("@15|3. Use @11|ability\n");
        }

        void DisplayFightPlayerInfo()
        {
            Util.WriteLine("You");
            Util.WriteColorString("@12|Health@15|: @12|" + player.Health + "@15| / @12|" +
                                  player.MaxHealth + "\n");
            Util.WriteColorString("@13|Damage@15|: @13|" + player.Damage.Item1 + "@15| - @13|" +
                                  player.Damage.Item2 + "\n");
            Util.WriteColorString("@5|Defense@15|: @5|" + player.Defense + "\n");
            Util.WriteColorString("@11|Ability points@15|: @11|" + player.Ap + "@15| / @11|" +
                                  (player.Level * player.ApPerLevel) + "\n\n");
        }

        void DisplayFightEnemyInfo(Enemy enemy)
        {
            Util.WriteColorString("@9|" + enemy.Name + "\n");
            Util.WriteColorString("@12|Health@15|: @12|" + enemy.Health + "@15| / @12|" +
                                  enemy.MaxHealth + "\n");
            Util.WriteColorString("@13|Damage@15|: @13|" + enemy.Damage.Item1 + "@15| - @13|" +
                                  enemy.Damage.Item2 + "\n");
            Util.WriteColorString("@5|Defense@15|: @5|" + enemy.Defense + "\n");
        }

        void FightConsume(ref int timesConsumed)
        {
            if (Consume() >= 0) timesConsumed += 1;
        }

        void FightUseAbility(List<Ability> learntAbilities, List<Ability> abilitiesInUse, ref AbilityEffects abilityEffectsCombined,
            ref int abilitiesUsed, int playerDefense, Tuple<int, int> playerDamage,
            Enemy enemy, int enemyDefense, Tuple<int, int> enemyDamage, Tuple<int, int> enemyGold, int enemyExperience)
        {
            if (UseAbility(learntAbilities, ref abilitiesInUse, ref abilityEffectsCombined))
            {
                abilitiesUsed += 1;

                abilityEffectsCombined.ApplyEffects(player, playerDefense, playerDamage,
                        enemy, enemyDefense, enemyDamage, enemyGold, enemyExperience);
            }
        }

        void ApplyAllAbilitiesEffects(List<Ability> abilitiesInUse, ref AbilityEffects abilityEffectsCombined,
            int playerDefense, Tuple<int, int> playerDamage,
            Enemy enemy, int enemyDefense, Tuple<int, int> enemyDamage, Tuple<int, int> enemyGold, int enemyExperience)
        {
            foreach (var ability in abilitiesInUse)
            {
                if (ability.Turns > 0)
                {
                    ability.Turns -= 1;

                    if (ability.Turns == 0)
                    {
                        ability.Stop(ref abilityEffectsCombined);

                        abilityEffectsCombined.ApplyEffects(player, playerDefense, playerDamage,
                            enemy, enemyDefense, enemyDamage, enemyGold, enemyExperience);
                    }
                }
            }
        }

        void RestorePlayersStatsAfterFight(Tuple<int, int> playerDamage, int playerDefense,
            Enemy enemy, Tuple<int, int> enemyDamage, int enemyDefense, Tuple<int, int> enemyGold, int enemyExperience)
        {
            player.Damage = playerDamage;
            player.Defense = playerDefense;

            enemy.Health = enemy.MaxHealth;

            enemy.Damage = enemyDamage;
            enemy.Defense = enemyDefense;
            enemy.Gold = enemyGold;
            enemy.Experience = enemyExperience;

            foreach (var ability in abilities)
            {
                ability.Turns = ability.TurnsConst;
            }
        }

        void PlayerHitEnemy(Enemy enemy)
        {
            int enemyDefense = enemy.Defense;

            // Enemy defense can't get lower than -90
            if (enemyDefense < -90)
                enemyDefense = -90;

            double defense = 100.0 / (100.0 + enemyDefense);
            int damage;

            if (player.Damage.Item1 < player.Damage.Item2)
                damage = Convert.ToInt32(randomizer.Next(player.Damage.Item1, player.Damage.Item2 + 1) * defense);
            else
                damage = Convert.ToInt32(randomizer.Next(player.Damage.Item2, player.Damage.Item1 + 1) * defense);

            if (enemy.Health - damage > enemy.MaxHealth)
                enemy.Health = enemy.MaxHealth;
            else
                enemy.Health -= damage;

            Util.WriteColorString("@15|You did @13|" + damage + " damage @15|to @9|" + enemy.Name + "\n");
        }

        void EnemyHitPlayer(Enemy enemy)
        {
            int playerDefense = player.Defense;

            // Player's defense can't be lower than -90
            if (playerDefense < -90) playerDefense = -90;

            double defense = 100.0 / (100.0 + playerDefense);
            int damage;

            if (enemy.Damage.Item1 < enemy.Damage.Item2)
                damage = Convert.ToInt32(randomizer.Next(enemy.Damage.Item1, enemy.Damage.Item2 + 1) * defense);
            else
                damage = Convert.ToInt32(randomizer.Next(enemy.Damage.Item2, enemy.Damage.Item1 + 1) * defense);

            if (player.Health - damage > player.MaxHealth)
                player.Health = player.MaxHealth;
            else
                player.Health -= damage;

            Util.WriteColorString("@9|" + enemy.Name + " @15|did @13|" + damage + " damage @15|to you\n");
        }
        #endregion Fight

        #region WonFight
        void PlayerWinningAward(Enemy enemy)
        {
            PlayerWinningAwardExperience(enemy);
            int gold = PlayerWinningAwardGold(enemy);
            List<Item> loot = PlayerWinningAwardLoot(enemy);

            PlayerWinningAwardUpdateKillTracker(enemy);

            PlayerWinningAwardDisplayAwards(enemy, gold, loot);

            PlayerWinningAwardCalculateStats();

            PlayerWinningAwardDisplayExit();

        }

        void PlayerWinningAwardExperience(Enemy enemy)
        {
            player.Experience += enemy.Experience;
        }

        int PlayerWinningAwardGold(Enemy enemy)
        {
            int gold = randomizer.Next(enemy.Gold.Item1, enemy.Gold.Item2 + 1);
            player.Gold += gold;

            return gold;
        }

        List<Item> PlayerWinningAwardLoot(Enemy enemy)
        {
            List<Item> loot = new List<Item>();

            PlayerWinningAwardGenerateLoot(enemy, loot);
            PlayerWinningAwardAddLootToItemStash(loot);
            PlayerWinningAwardAddConsumables(loot);
            PlayerWinningAwardAddQuestItems(loot);

            return loot;
        }

        void PlayerWinningAwardGenerateLoot(Enemy enemy, List<Item> loot)
        {
            int number;
            foreach (var item in enemy.Loot)
            {
                number = randomizer.Next(0, item.Item2);

                if (number == 0)
                {
                    loot.Add(item.Item1);
                }
            }
        }

        void PlayerWinningAwardAddLootToItemStash(List<Item> loot)
        {
            player.ItemStash.AddRange(loot.Where(x => x is not Consumable && x is not QuestItem));
        }

        void PlayerWinningAwardAddConsumables(List<Item> loot)
        {
            List<Consumable> consumablesLooted = loot.Where(x => x is Consumable).Cast<Consumable>().ToList();
            foreach (var item in consumablesLooted)
            {
                if (player.Consumables.Contains(item))
                {
                    player.Consumables.Find(x => x == item).Count += 1;
                }
                else
                {
                    item.Count = 1;
                    player.Consumables.Add(item);
                }
            }
        }

        void PlayerWinningAwardAddQuestItems(List<Item> loot)
        {
            List<QuestItem> questItemsLooted = loot.Where(x => x is QuestItem).Cast<QuestItem>().ToList();
            QuestItem questItem;
            foreach (var item in questItemsLooted)
            {
                loot.Remove(item);

                foreach (var quest in activeQuests)
                {
                    if (quest.QuestItems.Count > 0)
                    {
                        if (quest.QuestItems.Exists(x => x.Item1 == item))
                        {
                            if (player.QuestItems.Contains(item))
                            {
                                questItem = player.QuestItems.Find(x => x == item);

                                if (questItem.Count < quest.QuestItems.Find(x => x.Item1 == questItem).Item2)
                                {
                                    loot.Add(item);
                                    questItem.Count += 1;
                                }
                            }
                            else
                            {
                                loot.Add(item);
                                item.Count = 1;
                                player.QuestItems.Add(item);
                            }
                        }
                    }
                }
            }
        }

        void PlayerWinningAwardUpdateKillTracker(Enemy enemy)
        {
            if (activeQuests.Count > 0)
            {
                Tuple<Enemy, int> trackedEnemy;

                trackedEnemy = enemyTracker.Find(x => x.Item1 == enemy);

                if (trackedEnemy != null)
                {
                    enemyTracker[enemyTracker.FindIndex(x => x.Item1 == enemy)] = new Tuple<Enemy, int>(enemy, trackedEnemy.Item2 + 1);
                }
            }
        }

        void PlayerWinningAwardDisplayAwards(Enemy enemy, int gold, List<Item> loot)
        {
            Util.WriteColorString("@15|\nYou won figth against @9|" + enemy.Name + "\n");
            Util.WriteColorString("@15|You earned @4|" + enemy.Experience + " experience\n");
            Util.WriteColorString("@15|You gained @6|" + gold + " gold\n");

            if (loot.Count > 0)
                Util.WriteColorString("@15|You @8|looted@15|:\n");
            foreach (var item in loot)
            {
                item.Info();
            }
        }

        void PlayerWinningAwardCalculateStats()
        {
            if (player.CalculateStats())
            {
                Util.WriteColorString("@15|\nYou advanced to @4|level " + player.Level + "\n");
                Util.WriteColorString("@15|You have regained your @12|health\n");

                player.Health = player.MaxHealth;
            }
        }

        void PlayerWinningAwardDisplayExit()
        {
            Util.WriteLine("\n0. Exit");

            while (true)
            {
                int decision = Util.KeyboardKeyToInt(Console.ReadKey());

                if (decision == 0) break;
            }
        }
        #endregion WonFight

        #region LostFight
        void PlayerLosingPenalty(Enemy enemy)
        {
            int lostExperience = PlayerLosingPenaltyCalculateExperienceLoss();

            PlayerLosingPenaltyDisplayLostFightInfo(enemy, lostExperience);

            PlayerLosingPenaltyCalculateStats();

            PlayerLosingPenaltyDisplayExit();
        }

        int PlayerLosingPenaltyCalculateExperienceLoss()
        {
            int lostExperience = Convert.ToInt32(player.Experience / 100.0 * percentageExperiencePenalty);

            player.Experience -= lostExperience;
            player.Health = Convert.ToInt32(player.MaxHealth * runawayHealth);

            return lostExperience;
        }

        void PlayerLosingPenaltyDisplayLostFightInfo(Enemy enemy, int lostExperience)
        {
            Util.WriteColorString("@9|\n" + enemy.Name + " @15|defeated you\n");
            Util.WriteColorString("@15|You ran away with little to no @12|health\n");
            Util.WriteColorString("@15|\nYou lost @4|" + lostExperience + " experience\n");
        }

        void PlayerLosingPenaltyCalculateStats()
        {
            if (player.CalculateStats())
            {
                Util.WriteColorString("@15|\nYou dropped to @4|level " + player.Level + "\n");
            }
        }

        void PlayerLosingPenaltyDisplayExit()
        {
            Util.WriteLine("0. Exit");

            while (true)
            {
                int decision = Util.KeyboardKeyToInt(Console.ReadKey());

                if (decision == 0)
                {
                    break;
                }
            }
        }
        #endregion LostFight
    }
}
