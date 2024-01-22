using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace VeganRPG
{
    public partial class Game
    {
        #region Save / Load
        void SaveNewName()
        {
            Console.Clear();

            Util.WriteLine("Adventure name: ");

            string name = Console.ReadLine();

            Save(name);
        }

        void Save(string name = null, bool quick = false)
        {
            string save = "";

            SaveGameState(ref save);
            SavePlayerState(ref save);

            if (name != null)
                saveName = name + ".sav";

            File.WriteAllText(saveName, save);

            
            if (!quick)
            {
                Console.Clear();
                Util.WriteColorString("@15|Game @4|saved");
                Console.ReadKey();
            }     
        }

        void SaveGameState(ref string save)
        {
            SaveActiveQuests(ref save);
            SaveEnemyTracker(ref save);
            SaveCity(ref save);
        }

        void SaveActiveQuests(ref string save)
        {
            save += "ActiveQuests:";

            foreach (var quest in activeQuests)
            {
                save += quest.Name + ";";
            }

            save += "||\n";
        }

        void SaveEnemyTracker(ref string save)
        {
            save += "EnemyTracker:";

            foreach (var enemy in enemyTracker)
            {
                save += enemy.Item1.Name + "|" + enemy.Item2 + ";";
            }

            save += "||\n";
        }

        void SaveCity(ref string save)
        {
            save += "City:" + city.Name + "||\n";
        }

        void SavePlayerState(ref string save)
        {
            SavePlayerQuestsDone(ref save);

            SavePlayerItems(ref save);
            SavePlayerConsumables(ref save);
            SavePlayerQuestItems(ref save);

            SavePlayerEquipment(ref save);

            SavePlayerStats(ref save);
        }

        void SavePlayerQuestsDone(ref string save)
        {
            save += "QuestsDone:";

            foreach (var quest in player.QuestsDone)
            {
                save += quest.Name + ";";
            }

            save += "||\n";
        }

        void SavePlayerItems(ref string save)
        {
            save += "Items:";

            foreach (var item in player.ItemStash)
            {
                save += item.Name + ";";
            }

            save += "||\n";
        }

        void SavePlayerConsumables(ref string save)
        {
            save += "Consumables:";

            foreach (var item in player.Consumables)
            {
                save += item.Name + "|" + item.Count + ";";
            }

            save += "||\n";
        }

        void SavePlayerQuestItems(ref string save)
        {
            save += "QuestItems:";

            foreach (var item in player.QuestItems)
            {
                save += item.Name + "|" + item.Count + ";";
            }

            save += "||\n";
        }

        void SavePlayerEquipment(ref string save)
        {
            save += "Helmet:" + player.Helmet.Name + "||\n";
            save += "Armor:" + player.Armor.Name + "||\n";
            save += "Legs:" + player.Legs.Name + "||\n";
            save += "Boots:" + player.Boots.Name + "||\n";
            save += "Weapon:" + player.Weapon.Name + "||\n";
        }

        void SavePlayerStats(ref string save)
        {
            save += "Experience:" + player.Experience + "||\n";
            save += "Level:" + player.Level + "||\n";
            save += "Gold:" + player.Gold + "||\n";
            save += "Ap:" + player.Ap + "||\n";
            save += "MaxHealth:" + player.MaxHealth + "||\n";
            save += "Health:" + player.Health + "||\n";
            save += "Damage:" + player.Damage.Item1 + ";" + player.Damage.Item2 + "||\n";
            save += "Defense:" + player.Defense + "||\n";
        }

        bool Load()
        {
            Console.Clear();

            string save = "";

            var saves = Directory.GetFiles(".", "*.sav");

            if (saves.Length == 0)
            {
                Util.WriteLine("There are no saved adventures");
                Console.ReadKey();

                return false;
            }

            Util.WriteLine("Saved adventures: ");

            foreach (var file in saves)
            {
                Util.WriteLine((file.Replace(".sav", "")).Replace(".\\", ""), ConsoleColor.Blue);
            }

            Util.Write("\n");
            Util.WriteColorString("@15|Choose an adventure name to @4|load@15|: ");
            string name = Console.ReadLine();

            saveName = name + ".sav";

            if (File.Exists(saveName))
            {
                save = File.ReadAllText(saveName);

                save = save.Replace("\n", "");
                save = save.Trim();
                List<string> saveSplitted = save.Split("||").ToList();
                saveSplitted.RemoveAll(x => x == "");

                LoadGameState(saveSplitted);
                LoadPlayerState(saveSplitted);

                Console.Clear();

                Util.Write("Game ");
                Util.WriteLine("loaded", ConsoleColor.DarkRed);

                Console.ReadKey();

                return true;
            }
            else
            {
                Util.WriteLine("That adventure doesn't exist");

                Console.ReadKey();

                return false;
            }
        }

        static string LoadValue(List<string> saveSplitted, string heading)
        {
            string line = saveSplitted.Find(x => x.StartsWith(heading));

            line = line[(line.IndexOf(":") + 1)..];

            return line;
        }

        static List<string> LoadValueList(List<string> saveSplitted, string heading)
        {
            List<string> valueList = new List<string>();

            valueList = LoadValue(saveSplitted, heading).Split(";").ToList();
            valueList.RemoveAll(x => x == "");

            return valueList;
        }

        static List<Tuple<string, int>> LoadValueTupleList(List<string> saveSplitted, string heading)
        {
            List<Tuple<string, int>> valueTupleList = new List<Tuple<string, int>>();
            List<string> valueList = LoadValueList(saveSplitted, heading);

            List<string> tupleString;
            foreach (var value in valueList)
            {
                tupleString = value.Split("|").ToList();
                valueTupleList.Add(new Tuple<string, int>(tupleString[0], Convert.ToInt32(tupleString[1])));
            }

            return valueTupleList;
        }

        void LoadGameState(List<string> saveSplitted)
        {
            LoadActiveQuests(saveSplitted);
            LoadEnemyTracker(saveSplitted);
            LoadCity(saveSplitted);
        }

        void LoadActiveQuests(List<string> saveSplitted)
        {
            List<string> activeQuestsList = LoadValueList(saveSplitted, "ActiveQuests");

            activeQuests = new List<Quest>();
            foreach (var quest in activeQuestsList)
            {
                activeQuests.Add(quests.Find(x => x.Name == quest));
            }
        }

        void LoadEnemyTracker(List<string> saveSplitted)
        {
            List<Tuple<string, int>> enemyTrackerList = LoadValueTupleList(saveSplitted, "EnemyTracker");

            enemyTracker = new List<Tuple<Enemy, int>>();
            foreach (var enemy in enemyTrackerList)
            {
                enemyTracker.Add(new Tuple<Enemy, int>(enemies.Find(x => x.Name == enemy.Item1), enemy.Item2));
            }
        }

        void LoadCity(List<string> saveSplitted)
        {
            string cityString = LoadValue(saveSplitted, "City");

            city = cities.Find(x => x.Name == cityString);
        }

        void LoadPlayerState(List<string> saveSplitted)
        {
            LoadPlayerQuestsDone(saveSplitted);

            LoadPlayerItems(saveSplitted);
            LoadPlayerConsumables(saveSplitted);
            LoadPlayerQuestItems(saveSplitted);

            LoadPlayerEquipment(saveSplitted);

            LoadPlayerStats(saveSplitted);
        }

        void LoadPlayerQuestsDone(List<string> saveSplitted)
        {
            List<string> questsDoneList = LoadValueList(saveSplitted, "QuestsDone");

            player.QuestsDone = new List<Quest>();
            foreach (var quest in questsDoneList)
            {
                player.QuestsDone.Add(quests.Find(x => x.Name == quest));
            }
        }

        void LoadPlayerItems(List<string> saveSplitted)
        {
            List<string> itemsList = LoadValueList(saveSplitted, "Items");

            player.ItemStash = new List<Item>();
            foreach (var item in itemsList)
            {
                player.ItemStash.Add(items.Find(x => x.Name == item));
            }
        }

        void LoadPlayerConsumables(List<string> saveSplitted)
        {
            List<Tuple<string, int>> consumablesList = LoadValueTupleList(saveSplitted, "Consumables");

            player.Consumables = new List<Consumable>();
            Consumable consumable;
            foreach (var item in consumablesList)
            {
                consumable = consumables.Find(x => x.Name == item.Item1);
                consumable.Count = item.Item2;
                player.Consumables.Add(consumable);
            }
        }

        void LoadPlayerQuestItems(List<string> saveSplitted)
        {
            List<Tuple<string, int>> questItemsList = LoadValueTupleList(saveSplitted, "QuestItems");

            player.QuestItems = new List<QuestItem>();
            QuestItem questItem;
            foreach (var item in questItemsList)
            {
                questItem = questItems.Find(x => x.Name == item.Item1);
                questItem.Count = item.Item2;
                player.QuestItems.Add(questItem);
            }
        }

        void LoadPlayerEquipment(List<string> saveSplitted)
        {
            string helmetString = LoadValue(saveSplitted, "Helmet");
            string armorString = LoadValue(saveSplitted, "Armor");
            string legsString = LoadValue(saveSplitted, "Legs");
            string bootsString = LoadValue(saveSplitted, "Boots");
            string weaponString = LoadValue(saveSplitted, "Weapon");

            player.Helmet = (Helmet)items.Find(x => x.Name == helmetString);
            player.Armor = (Armor)items.Find(x => x.Name == armorString);
            player.Legs = (Legs)items.Find(x => x.Name == legsString);
            player.Boots = (Boots)items.Find(x => x.Name == bootsString);
            player.Weapon = (Weapon)items.Find(x => x.Name == weaponString);
        }

        void LoadPlayerStats(List<string> saveSplitted)
        {
            player.Experience = Convert.ToInt32(LoadValue(saveSplitted, "Experience"));
            player.Level = Convert.ToInt32(LoadValue(saveSplitted, "Level"));
            player.Gold = Convert.ToInt32(LoadValue(saveSplitted, "Gold"));
            player.Ap = Convert.ToInt32(LoadValue(saveSplitted, "Ap"));
            player.MaxHealth = Convert.ToInt32(LoadValue(saveSplitted, "MaxHealth"));
            player.Health = Convert.ToInt32(LoadValue(saveSplitted, "Health"));
            player.Defense = Convert.ToInt32(LoadValue(saveSplitted, "Defense"));

            List<string> damageList = LoadValueList(saveSplitted, "Damage");
            player.Damage = new Tuple<int, int>(Convert.ToInt32(damageList[0]), Convert.ToInt32(damageList[1]));
        }

        #endregion
    }
}
