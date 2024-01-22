using System;
using System.Collections.Generic;

namespace VeganRPG
{
    public partial class Game
    {
        string saveName;

        /// <summary>
        /// How much percentage of your experience is subtracted after lost fight.
        /// </summary>
        readonly int percentageExperiencePenalty;
        /// <summary>
        /// Percentage of health that player has after a lost fight
        /// </summary>
        readonly double runawayHealth = 0.25;

        readonly Random randomizer;

        readonly Player player;

        City city;

        List<Quest> activeQuests;
        List<Tuple<Enemy, int>> enemyTracker;

        public Game()
        {
            percentageExperiencePenalty = 3;

            randomizer = new Random();

            GenerateHelmets();
            GenerateArmors();
            GenerateLegs();
            GenerateBoots();
            GenerateWeapons();

            GenerateConsumables();
            GenerateQuestItems();

            GenerateItems();

            GenerateEnemies();

            GenerateAbilities();

            GenerateAreas();
      
            GenerateQuests();

            GenerateNpcs();

            GenerateCities();

            player = new Player(items);
            
            city = cities.Find(x => x.Name == "Farm");

            activeQuests = new List<Quest>();

            enemyTracker = new List<Tuple<Enemy, int>>();
        }

        static void ExitGame()
        {
            Console.Clear();

            Util.WriteLine("Exiting the game");

            Console.ReadKey();
        }

        // Auto creates an adventure with a random name (adventure[0-100000].sav)
        void NewGame()
        {
            saveName = "adventure";

            saveName += randomizer.Next(100000) + ".sav";

            Console.Clear();

            Util.WriteColorString("@15|During a trip outside of your @10|homeland@15|, you have found yourself " +
                                  "lost in an unkown @10|land\n");
            Util.WriteColorString("@15|From afar you can see some buildings, it looks like a @10|farm\n");
            Util.Write("You chose to go in that direction");

            Console.ReadKey();

            Console.Clear();
        }

        public void StartMenu()
        {
            while (true)
            {
                Console.Clear();

                Util.WriteColorString("@15|1. @4|New @15|game\n");
                Util.WriteColorString("@15|2. @4|Load @15|game");
                Util.WriteLine("\n\n0. Exit");

                var decision = Util.KeyboardKeyToInt(Console.ReadKey());

                if (decision == 0)
                {
                    ExitGame();

                    return;
                }
                else if (decision == 1)
                {
                    NewGame();
                    Menu();
                }
                else if (decision == 2)
                {
                    if(Load())
                    {
                        Menu();
                    }
                }             
            }          
        }

        public void Menu()
        {
            while (true)
            {
                // Checks if player has completed the last quest first, so the program can finish the game before the menu is displayed
                if (player.QuestsDone.Find(x => x.Name == "The End") != null)
                {
                    EndGame();             

                    break;
                }

                DisplayMainMenuOptions();

                var decision = Util.KeyboardKeyToInt(Console.ReadKey());

                if (decision == -2)
                {
                    ExitGameFromMainMenu();
                    return;
                }
                else if (decision == 1) city.People(player, activeQuests, enemyTracker);
                else if (decision == 2) GoOutside();
                else if (decision == 3) PlayerMenu();
                else if (decision == 4) QuestTracker();
                else if (decision == 5) Travel();
                else if (decision == 6) Save();
                else if (decision == 7) SaveNewName();
            }
        }

        /// <summary>
        /// Displays information that the game has ended and you have won.
        /// </summary>
        void EndGame()
        {
            Console.Clear();

            Util.WriteMulticolor("CONGRATULATIONS, YOU HAVE WON THE GAME !!!");
            Util.Write("\n\n");

            Util.WriteColorString("@4|Experience@15|: @4|" + player.Experience + "@15| / @4|" +
                                  player.ExperienceToLevel(player.Level) + "\n");
            Util.WriteColorString("@4|Level@15|: @4|" + player.Level + "\n\n");
            Util.WriteColorString("@6|Gold@15|: @6|" + player.Gold + "\n\n");
            Util.WriteColorString("@12|Health@15|: @12|" + player.Health + "@15| / @12|" +
                                  player.MaxHealth + "\n");
            Util.WriteColorString("@13|Damage@15|: @13|" + player.Damage.Item1 + "@15| - @13|" +
                                  player.Damage.Item2 + "\n");
            Util.WriteColorString("@5|Defense@15|: @5|" + player.Defense + "\n");

            Console.ReadKey();
        }

        void DisplayMainMenuOptions()
        {
            Console.Clear();

            Util.WriteColorString("@10|" + city.Name + "\n");
            Util.WriteColorString("@15|1. @9|People\n");
            Util.WriteLine("2. Go outside\n");

            Util.WriteColorString("@15|3. @2|Statistics @15|and @8|Equipment\n");
            Util.WriteColorString("@15|4. @12|Quest @15|tracker\n");

            // Displays additional option if the last quest in a city is finished
            if (city.EndQuest != null && player.QuestsDone.Find(x => x == city.EndQuest) != null)
            {
                Util.WriteColorString("@15|5. Travel to the next @10|city\n");
            }

            Util.WriteColorString("@15|\n6. @4|Save\n");
            Util.WriteColorString("@15|7. @4|Save @15|as\n");
            Util.WriteLine("\nE. Exit");
        }

        void ExitGameFromMainMenu()
        {
            while (true)
            {
                Console.Clear();

                Util.WriteColorString("@15|Should the game be @4|saved @15|before you close the current game?\n");
                Util.WriteColorString("@15|1. @4|Save\n");
                Util.Write("\n0. Exit");

                var decision = Util.KeyboardKeyToInt(Console.ReadKey());

                if (decision == 0)
                {
                    return;
                }
                else if (decision == 1)
                {
                    Save();
                    return;
                }
            }
        }

        /// <summary>
        /// Leaves the city to fight monsters.
        /// </summary>
        void GoOutside()
        {
            while (true)
            {
                if (player.QuestsDone.Find(x => x.Name == "The End") != null)
                    break;

                Enemy enemy = city.Outside(player, activeQuests);

                if (enemy != null)
                {
                    if (Fight(enemy))
                    {
                        if (enemy.Boss)
                        {
                            Quest bossQuest = null;

                            foreach (var quest in activeQuests)
                            {
                                if (quest.QuestEnemies.Find(x => x.Item1 == enemy) != null)
                                    bossQuest = quest;
                            }
                            if (bossQuest != null)
                            {
                                Console.Clear();

                                bossQuest.Finish(player, enemyTracker);
                                activeQuests.Remove(bossQuest);
                            }
                        }

                        continue;
                    }
                    else
                        break;
                }
                else
                    break;
            }
        }

        void PlayerMenu()
        {
            while (true)
            {
                DisplayPlayerMenuOptions();

                var decision = Util.KeyboardKeyToInt(Console.ReadKey());

                // Exit player menu
                if (decision == 0)      break;
                else if (decision == 1) player.ShowStatistics();
                else if (decision == 2) player.ShowItemStash();
                else if (decision == 3) PlayerMenuEquipItem();
                else if (decision == 4) PlayerMenuConsume();
                else if (decision == 5) AutoConsume();
            }
        }

        void DisplayPlayerMenuOptions()
        {
            Console.Clear();

            Util.WriteColorString("@15|1. @2|Statistics\n\n");
            Util.WriteColorString("@15|2. @8|Item @15|stash\n");
            Util.WriteColorString("@15|3. Equip @8|Item\n\n");
            Util.WriteColorString("@15|4. @14|Consume\n");
            Util.WriteColorString("@15|5. @14|Consume@15|, till full on @12|health\n");
            Util.WriteLine("\n0. Exit");
        }

        void PlayerMenuEquipItem()
        {
            while (true)
            {
                Console.Clear();

                Util.WriteColorString("@15|1. Equip @8|Helmet\n");
                Util.WriteColorString("@15|2. Equip @8|Armor\n");
                Util.WriteColorString("@15|3. Equip @8|Legs\n");
                Util.WriteColorString("@15|4. Equip @8|Boots\n");
                Util.WriteColorString("@15|5. Equip @8|Weapon\n");
                Util.WriteLine("\n0. Exit");

                var decision = Util.KeyboardKeyToInt(Console.ReadKey());

                if (decision == 0) break;
                else if (decision == 1) player.EquipItem(new Helmet().GetType());
                else if (decision == 2) player.EquipItem(new Armor().GetType());
                else if (decision == 3) player.EquipItem(new Legs().GetType());
                else if (decision == 4) player.EquipItem(new Boots().GetType());
                else if (decision == 5) player.EquipItem(new Weapon().GetType());
            }
        }

        void PlayerMenuConsume()
        {
            int site = 0;
            while (true)
            {
                site = Consume(site);

                if (site < 0)
                {
                    break;
                }
            }
        }

        void Travel()
        {
            if (city.EndQuest != null && player.QuestsDone.Find(x => x == city.EndQuest) != null)
            {
                city = city.NextCity;

                activeQuests = new List<Quest>();
                enemyTracker = new List<Tuple<Enemy, int>>();
            }
        }

        void QuestTracker()
        {
            Console.Clear();

            if (activeQuests.Count > 0)
            {
                foreach (var quest in activeQuests)
                {
                    quest.Info(player, enemyTracker);
                    Util.Write("\n\n");
                }
            }
            else
            {
                Util.WriteColorString("@15|You don't have any active @12|quest\n");
            }

            Console.ReadKey();
        }    
    }
}
