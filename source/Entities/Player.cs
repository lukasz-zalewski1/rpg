using System;
using System.Collections.Generic;
using System.Linq;

namespace VeganRPG
{
    public class Player
    {
        public int Level { get; set; }

        public int Experience { get; set; }
        public int Gold { get; set; }

        internal List<QuestItem> QuestItems { get; set; }
        internal List<Quest> QuestsDone { get; set; }

        internal List<Item> ItemStash { get; set; }
        internal List<Consumable> Consumables { get; set; }

        private readonly int healthPerLevel;
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public Tuple<int, int> Damage { get; set; }
        public int Defense { get; set; }

        public int Ap { get; set; }
        public int ApPerLevel { get; set; }

        public int ExperienceMultipler { get; set; }

        internal Helmet Helmet { get; set; }
        internal Armor Armor { get; set; }
        internal Legs Legs { get; set; }
        internal Boots Boots { get; set; }
        internal Weapon Weapon { get; set; }

        internal Player(List<Item> items)
        {
            ExperienceMultipler = 10;

            QuestsDone = new List<Quest>();

            healthPerLevel = 20;
            ApPerLevel = 5;

            Experience = 0;
            Level = 0;
            Gold = 0;

            Ap = 0;

            MaxHealth = healthPerLevel;
            Health = healthPerLevel;
            Damage = new Tuple<int, int>(0, 0);
            Defense = 0;

            ItemStash = new List<Item>();
            Consumables = new List<Consumable>();

            QuestItems = new List<QuestItem>();

            Weapon = (Weapon)items.Find(x => x.Name == "Hands");
            Helmet = (Helmet)items.Find(x => x.Name == "Head");
            Armor = (Armor)items.Find(x => x.Name == "Torso");
            Legs = (Legs)items.Find(x => x.Name == "Legs");
            Boots = (Boots)items.Find(x => x.Name == "Feet");

            CalculateStats();
        }

        public bool CalculateStats()
        {
            bool levelUp = CalculateLvl();

            if (levelUp)
            {
                if (Ap + ApPerLevel > Level * ApPerLevel)   Ap = Level * ApPerLevel;
                else                                        Ap += ApPerLevel;
            }

            MaxHealth = (Level + 1) * healthPerLevel + Helmet.Health + Armor.Health + Legs.Health + Boots.Health;
            Damage = Weapon.Damage;
            Defense = Helmet.Defense + Armor.Defense + Legs.Defense + Boots.Defense;

            return levelUp;
        }

        bool CalculateLvl()
        {
            if (Experience >= ExperienceToLevel(Level))
            {
                Level += 1;
                return true;
            }
            else if (Experience < ExperienceToLevel(Level - 1))
            {
                Level -= 1;
                return true;
            }

            return false;
        }

        public void ShowStatistics()
        {
            Console.Clear();

            Util.Write("Helmet: ");
            Helmet.Info();

            Util.Write("Armor: ");
            Armor.Info();

            Util.Write("Legs: ");
            Legs.Info();

            Util.Write("Boots: ");
            Boots.Info();

            Util.Write("Weapon: ");
            Weapon.Info();

            Util.WriteColorString("@4|Experience@15|: @4|" + Experience + " @15|" +
                                  "/ @4|" + ExperienceToLevel(Level) + "\n");
            Util.WriteColorString("@4|Level@15|: @4|" + Level + "\n\n");
            Util.WriteColorString("@6|Gold@15|: @6|" + Gold + "\n\n");
            Util.WriteColorString("@12|Health@15|: @12|" + Health + "@15| / @12|" +
                                  MaxHealth + "\n");
            Util.WriteColorString("@13|Damage@15|: @13|" + Damage.Item1 + "@15| - @13|" +
                                  Damage.Item2 + "\n");
            Util.WriteColorString("@5|Defense@15|: @5|" + Defense + "\n\n");
            Util.WriteColorString("@11|Ability points@15|: @11|" + Ap + "@15| / @11|" +
                                  Level * ApPerLevel + "\n\n");

            Console.ReadKey();
        }

        public void ShowItemStash()
        {
            Console.Clear();

            OrderItemStashList();

            Util.WriteColorString("@8|Item @15|stash:\n");

            foreach (var item in ItemStash)
            {
                item.Info();
            }

            Console.ReadKey();
        }

        public void EquipItem(Type type)
        {
            Item item = null;

            if (type == Helmet.GetType())       item = Helmet;
            else if (type == Armor.GetType())   item = Armor;
            else if (type == Legs.GetType())    item = Legs;
            else if (type == Boots.GetType())   item = Boots;
            else if (type == Weapon.GetType())  item = Weapon;
            else                                return;

            int site = 0;
            int maxSite = (ItemStash.Count - 1) / 7;

            while (true)
            {
                List<Item> items = ItemStash.Where(x => x.GetType() == type).OrderByDescending(x => x.Level).ToList();

                maxSite = (items.Count - 1) / 7;
                if (site > maxSite) site = maxSite;

                if (items.Count == 0)
                {
                    Util.WriteColorString("@15|You don't have any @8|" + type.Name.ToString() +
                                          "@15| in your stash");
                }

                EquipItemDisplayMenu(type, items, item, site, maxSite);
                if (EquipItemHandleInput(items, ref item, ref site, maxSite)) break;
                
                CalculateStats();
            }
        }

        private void EquipItemDisplayMenu(Type type, List<Item> items, Item item, int site, int maxSite)
        {
            Console.Clear();

            Util.WriteColorString("@4|Level@15|: @4|" + Level + "\n");

            Util.Write(type.Name.ToString() + ": ");
            item.Info(false);

            Util.WriteColorString("@8|\n\nItem @15|stash: " + (site + 1) + " / " + (maxSite + 1) + "\n");

            for (int i = 0; i < 7; ++i)
            {
                if (items.Count <= i + site * 7) break;

                Util.Write(i + 1 + ". ");
                items[i + site * 7].Info();
            }

            if (site > 0)       Util.WriteLine("8. Previous site");
            if (site < maxSite) Util.WriteLine("9. Next site");
            Util.WriteLine("\n0. Exit");
        }

        private bool EquipItemHandleInput(List<Item> items, ref Item item, ref int site, int maxSite)
        {
            int decision = Util.KeyboardKeyToInt(Console.ReadKey());

            if (decision == 0)                          return true;
            else if (site > 0 && decision == 8)         site -= 1;
            else if (site < maxSite && decision == 9)   site += 1;
            else if (decision > 0 && decision < 8)      EquipItemFinishEquiping(items, ref item, site, decision);

            if (item is Helmet helmet)      Helmet = helmet;
            else if (item is Armor armor)   Armor = armor;
            else if (item is Legs legs)     Legs = legs;
            else if (item is Boots boots)   Boots = boots;
            else if (item is Weapon weapon) Weapon = weapon;

            return false;
        }

        private void EquipItemFinishEquiping(List<Item> items, ref Item item, int site, int decision)
        {
            if (decision + site * 7 < items.Count + 1)
            {
                if (Level >= items[decision - 1 + site * 7].Level)
                {
                    ItemStash.Remove(items[decision - 1 + site * 7]);
                    if (!item.IsBase) ItemStash.Add(item);
                    item = items[decision - 1 + site * 7];

                    Console.Clear();

                    Util.WriteColorString("@15|You've equiped @8|" + item.Name + "\n");

                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();

                    Util.WriteColorString("@15|Your @4|level @15|is too low\n");

                    Console.ReadKey();
                }
            }
        }

        public int ExperienceToLevel(int level)
        {
            int expToAdvance;

            if (level == 0)      expToAdvance = 10 * ExperienceMultipler;
            else if (level == 1) expToAdvance = 20 * ExperienceMultipler;
            else
                expToAdvance = Convert.ToInt32((50 * Math.Pow(level + 1, 3) - 150 * Math.Pow(level + 1, 2) + 400 * (level + 1)) /
                    (30 / ExperienceMultipler));

            return expToAdvance;
        }

        internal void OrderQuestItemsList()
        {
            QuestItems = QuestItems.OrderBy(x => x.Name).ToList();
        }

        internal void OrderItemStashList()
        {
            ItemStash = ItemStash.OrderBy(x => x.GetType().Name).ThenByDescending(y => y.Level).ToList();
        }

        internal void OrderConsumablesList()
        {
            Consumables = Consumables.OrderByDescending(x => x.Level).ThenByDescending(y => y.Health).ToList();
        }
    }
}
