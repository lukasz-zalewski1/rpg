using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganRPG
{
    class Quest
    {
        string name;
        string description;

        List<Tuple<Enemy, int>> questEnemies;
        List<Tuple<QuestItem, int>> questItems;

        int goldReward;
        int experienceReward;
        List<Item> itemsReward;

        // True, if quest finish takes place outside NPC that gave it
        bool outsideFinish;

        public Quest(string name, string description, 
            List<Tuple<Enemy, int>> questEnemies, List<Tuple<QuestItem, int>> questItems, 
            int goldReward, int experienceReward, List<Item> itemsReward, bool outsideFinish = false)
        {
            Name = name;

            QuestEnemies = questEnemies;
            QuestItems = questItems;

            GoldReward = goldReward;
            ExperienceReward = experienceReward;
            ItemsReward = itemsReward;

            Description = description;

            OutsideFinish = outsideFinish;
        }

        public void Start(List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            activeQuests.Add(this);

            foreach (var enemy in questEnemies)
            {
                enemyTracker.Add(new Tuple<Enemy, int>(enemy.Item1, 0));
            }

            Util.WriteMulticolor("@15|You started \"@12|" + Name + "@15|\"\n");

            /*Util.Write("You started \"");
            Util.Write(Name + "", ConsoleColor.Red);
            Util.WriteLine("\"");*/
        }

        public void Finish(Player player, List<Tuple<Enemy, int>> enemyTracker)
        {
            foreach (var enemy in QuestEnemies)
            {
                if (enemyTracker.Find(x => x.Item1 == enemy.Item1) != null)
                {
                    enemyTracker.RemoveAll(x => x.Item1 == enemy.Item1);
                }
            }

            foreach (var item in QuestItems)
            {
                player.QuestItems.RemoveAll(x => x == item.Item1);
            }

            player.QuestsDone.Add(this);    

            Reward(player);
        }

        private void Reward(Player player)
        {
            Util.WriteColorString("@15|You completed @12|" + Name + "\n");

            /*Util.Write("You completed ");
            Util.WriteLine(Name, ConsoleColor.Red);*/

            if (GoldReward == 0 && ItemsReward.Count == 0 && ExperienceReward == 0)
            {
                Console.ReadKey();

                return;
            }

            Util.WriteLine("Reward: ");

            if (GoldReward > 0)
            {
                Util.WriteColorString("@6|" + GoldReward + " G\n");

                /*Util.WriteLine(GoldReward + " G", ConsoleColor.DarkYellow);*/

                player.Gold += GoldReward;
            }

            if (ExperienceReward > 0)
            {
                Util.WriteColorString("@4|" + ExperienceReward + " Experience\n");

                /*Util.WriteLine(ExperienceReward + " Experience", ConsoleColor.DarkRed);*/

                player.Experience += ExperienceReward;
            }
            
            if (itemsReward.Count > 0)
            {
                foreach (var item in itemsReward)
                {
                    if (item is Consumable consumable)
                    {
                        if (player.Consumables.Contains(item))
                        {
                            player.Consumables.Find(x => x == item).Count += 1;
                        }
                        else
                        {
                            player.Consumables.Add(consumable);
                        }
                    }
                    else
                    {
                        player.ItemStash.Add(item);
                    }

                    item.Info();
                }
            }

            Console.ReadKey();
        }

        public void Info(Player player, List<Tuple<Enemy, int>> enemyTracker)
        {
            Util.WriteColorString("@12|" + Name + "\n");

            /*Util.WriteLine(Name, ConsoleColor.Red);*/

            Util.WriteColorString(description);

            if (QuestEnemies.Count > 0)
            {
                Util.WriteLine("\nWin fights:");
                int enemyCount = 0;

                foreach (var enemy in QuestEnemies)
                {
                    if (enemyTracker.Find(x => x.Item1 == enemy.Item1) != null)
                    {
                        enemyCount = enemyTracker.Find(x => x.Item1 == enemy.Item1).Item2;
                    }

                    if (enemyCount > enemy.Item2)
                    {
                        enemyCount = enemy.Item2;
                    }

                    Util.WriteColorString("@9|" + enemy.Item1.Name + " @15|" + enemyCount + " / " +
                                          enemy.Item2 + "\n");

                    /*Util.Write(enemy.Item1.Name + " ", ConsoleColor.Blue);
                    Util.WriteLine(enemyCount + " / " + enemy.Item2);*/
                }
            }

            if (QuestItems.Count > 0)
            {
                Util.WriteLine("\nGet:");
                int itemCount = 0;

                foreach (var item in QuestItems)
                {
                    if (player.QuestItems.Contains(item.Item1))
                    {
                        itemCount = player.QuestItems.Find(x => x == item.Item1).Count;
                    }
                    else
                    {
                        itemCount = 0;
                    }

                    Util.WriteColorString("@12|" + item.Item1 + Name + " @15|" + itemCount +
                                          "@15| / " + item.Item2 + "\n");

                    /*Util.Write(item.Item1.Name + " ", ConsoleColor.Red);
                    Util.WriteLine(itemCount + " / " + item.Item2);*/
                }
            }
        }

        public bool CheckCompletion(Player player, List<Tuple<Enemy, int>> enemyTracker)
        {
            int itemCount = 0;
            bool completed = true;

            foreach (var questItem in QuestItems)
            {       
                if (player.QuestItems.Contains(questItem.Item1))
                {
                    itemCount = player.QuestItems.Find(x => x == questItem.Item1).Count;

                    if (itemCount < questItem.Item2)
                    {
                        completed = false;
                    }
                }
                else
                {
                    completed = false;
                }
            }

            foreach (var questEnemy in questEnemies)
            {
                var enemyTracked = enemyTracker.Find(x => x.Item1 == questEnemy.Item1);

                if (enemyTracked != null)
                {
                    if (enemyTracked.Item2 < questEnemy.Item2)
                    {
                        completed = false;
                    }
                }
            }

            return completed;
        }

        public int GoldReward { get => goldReward; set => goldReward = value; }
        internal List<Item> ItemsReward { get => itemsReward; set => itemsReward = value; }
        internal List<Tuple<Enemy, int>> QuestEnemies { get => questEnemies; set => questEnemies = value; }
        internal List<Tuple<QuestItem, int>> QuestItems { get => questItems; set => questItems = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public bool OutsideFinish { get => outsideFinish; set => outsideFinish = value; }
        public int ExperienceReward { get => experienceReward; set => experienceReward = value; }
    }
}
