using System;
using System.Collections.Generic;

namespace VeganRPG
{
    public partial class Game
    {
        List<Helmet> helmets;
        List<Armor> armors;
        List<Legs> legs;
        List<Boots> boots;
        List<Weapon> weapons;
        List<Consumable> consumables;
        List<Item> items;

        List<Enemy> enemies;

        List<Ability> abilities;

        List<QuestItem> questItems;
        List<Quest> quests;

        List<Area> areas;

        List<NPC> npcs;

        List<City> cities;

        void GenerateHelmets()
        {
            helmets = new List<Helmet>()
            {
                #region Farm
                new Helmet(0, "Head", 0, 0, true),
                new Helmet(0, "Worn Leather Helmet", 5, 0),
                new Helmet(1, "Leather Helmet", 8, 0),
                new Helmet(5, "Quilted Helmet", 15, 3),
                new Helmet(8, "Worn Bronze Helmet", 35, 6),
                new Helmet(10, "Bronze Helmet", 50, 9),
                #endregion

                #region Amfurce
                new Helmet(14, "Artificial Leather Helmet", 110, 20),
                new Helmet(19, "Cruelty-Free Leather Helmet", 200, 25),
                new Helmet(22, "BIO Leather Helmet", 230, 38),
                new Helmet(26, "Empathy Helmet", 350, 75),
                new Helmet(30, "BIO Helmet of Flowing Water", 700, 150),
                #endregion
            };
        }

        void GenerateArmors()
        {
            armors = new List<Armor>
            {
                #region Farm
                new Armor(0, "Torso", 0, 0, true),
                new Armor(1, "Worn Leather Armor", 10, 0),
                new Armor(2, "Leather Armor", 22, 0),
                new Armor(6, "Quilted Armor", 40, 5),
                new Armor(10, "Worn Bronze Armor", 80, 12),
                new Armor(12, "Bronze Armor", 140, 20),
                #endregion

                #region Amfurce
                new Armor(16, "Artificial Leather Armor", 230, 40),
                new Armor(21, "Cruelty-Free Leather Armor", 350, 50),
                new Armor(24, "BIO Leather Armor", 400, 65),
                new Armor(28, "Empathy Armor", 600, 130),
                new Armor(30, "BIO Armor of Flowing Water", 1000, 200)
                #endregion
            };
        }

        void GenerateLegs()
        {
            legs = new List<Legs>()
            {
                #region Farm
                new Legs(0, "Legs", 0, 0, true),
                new Legs(1, "Worn Leather Legs", 8, 0),
                new Legs(2, "Leather Legs", 15, 0),
                new Legs(5, "Quilted Legs", 25, 4),
                new Legs(9, "Worn Bronze Legs", 55, 9),
                new Legs(11, "Bronze Legs", 75, 13),
                #endregion

                #region Amfurce
                new Legs(15, "Artificial Leather Legs", 120, 25),
                new Legs(20, "Cruelty-Free Leather Legs", 200, 30),
                new Legs(23, "BIO Leather Legs", 240, 42),
                new Legs(27, "Empathy Legs", 350, 80),
                new Legs(30, "BIO Legs of Flowing Water", 800, 150)
                #endregion
            };
        }

        void GenerateBoots()
        {
            boots = new List<Boots>
            {
                #region Farm
                new Boots(0, "Feet", 0, 0, true),
                new Boots(0, "Worn Leather Boots", 3, 0),
                new Boots(1, "Leather Boots", 6, 0),
                new Boots(4, "Quilted Boots", 12, 3),
                new Boots(7, "Worn Bronze Boots", 25, 7),
                new Boots(9, "Bronze Boots", 40, 8),
                #endregion

                #region Amfurce
                new Boots(13, "Artificial Leather Boots", 70, 15),
                new Boots(18, "Cruelty-Free Leather Boots", 130, 20),
                new Boots(21, "BIO Leather Boots", 150, 30),
                new Boots(25, "Empathy Boots", 230, 60),
                new Boots(30, "BIO Boots of Flowing Water", 500, 100)
                #endregion
            };
        }

        void GenerateWeapons()
        {
            weapons = new List<Weapon>
            {
                #region Farm
                new Weapon(0, "Hands", new Tuple<int, int>(1, 1), true),
                new Weapon(1, "Wooden Stick", new Tuple<int, int>(1, 2)),
                new Weapon(2, "Rock", new Tuple<int, int>(1, 3)),
                new Weapon(3, "Branch", new Tuple<int, int>(3, 4)),
                new Weapon(5, "Wooden Sword", new Tuple<int, int>(3, 9)),
                new Weapon(7, "Wooden Axe", new Tuple<int, int>(2, 13)),
                new Weapon(8, "Wooden Well Carved Sword", new Tuple<int, int>(6, 14)),
                new Weapon(10, "Used Bronze Sword", new Tuple<int, int>(15, 20)),
                new Weapon(11, "Bronze Sword", new Tuple<int, int>(15, 25)),
                new Weapon(13, "Bronze Axe", new Tuple<int, int>(8, 48)),
                #endregion

                #region Amfurce
                new Weapon(16, "BIO Wooden Stick", new Tuple<int, int>(30, 40)),
                new Weapon(19, "BIO Wooden Sword", new Tuple<int, int>(31, 51)),
                new Weapon(22, "BIO Wooden Axe", new Tuple<int, int>(25, 75)),
                new Weapon(25, "Empathy Sword", new Tuple<int, int>(50, 70)),
                new Weapon(30, "BIO Staff of Flowing Water", new Tuple<int, int>(100, 150)),
                new Weapon(30, "BIO Leather Ball", new Tuple<int, int>(500, 1000))
                #endregion
            };
        }

        void GenerateConsumables()
        {
            #region Farm
            consumables = new List<Consumable>();
            consumables.Add(new Consumable(0, "Grain of Rice", 1, 0));
            consumables.Add(new Consumable(0, "Tomato Seed", 1, 0));
            consumables.Add(new Consumable(0, "Pumpkin Seed", 2, 0));
            consumables.Add(new Consumable(0, "Chia Seed", 3, 0));
            consumables.Add(new Consumable(1, "Peanut", 6, 0));
            consumables.Add(new Consumable(1, "Walnut", 9, 0));
            consumables.Add(new Consumable(2, "Wheat", 17, 0));
            consumables.Add(new Consumable(2, "Millet", 22, 0));
            consumables.Add(new Consumable(3, "Rice", 30, 0));

            consumables.Add(new Consumable(2, "Tobacco Leaf", 0, 2));
            consumables.Add(new Consumable(4, "Apple Juice", 15, 3));

            consumables.Add(new Consumable(4, "Black Widow's Venom", 0, 20));
            consumables.Add(new Consumable(4, "Black Widow's Leg", 150, 0));

            consumables.Add(new Consumable(4, "White Beans", 35, 0));
            consumables.Add(new Consumable(5, "Kidney Beans", 50, 0));
            consumables.Add(new Consumable(6, "Black Beans", 80, 0));
            consumables.Add(new Consumable(6, "Banana", 40, 5));
            consumables.Add(new Consumable(6, "Crab Spider Leg", 0, 9));
            consumables.Add(new Consumable(6, "Orange Spider Venom", 75, 4));
            consumables.Add(new Consumable(6, "Bowl of Spider Soup", 250, 25));

            consumables.Add(new Consumable(7, "Tomato", 60, 5));
            consumables.Add(new Consumable(7, "Cucumber", 50, 7));
            consumables.Add(new Consumable(7, "Aubergine", 0, 13));
            consumables.Add(new Consumable(8, "Courgette", 160, 0));
            consumables.Add(new Consumable(9, "Apple", 175, 5));
            consumables.Add(new Consumable(10, "Pear", 280, 0));
            consumables.Add(new Consumable(10, "Truffles", 0, 28));

            consumables.Add(new Consumable(12, "Farmenstein", 400, 25));
            #endregion

            #region Amfurce
            consumables.Add(new Consumable(11, "Vegan Cheese Slice", 300, 0));
            consumables.Add(new Consumable(12, "Vegan Slice of Ham", 250, 10));
            consumables.Add(new Consumable(12, "Bread", 50, 35));
            consumables.Add(new Consumable(12, "Roll", 250, 15));
            consumables.Add(new Consumable(13, "Vegan Butter", 300, 15));
            consumables.Add(new Consumable(14, "Salt", 0, 45));
            consumables.Add(new Consumable(15, "Pepper", 0, 50));

            consumables.Add(new Consumable(16, "Vegan Sandwich", 750, 75));

            consumables.Add(new Consumable(17, "Orange", 600, 0));
            consumables.Add(new Consumable(18, "Grape", 500, 15));
            consumables.Add(new Consumable(18, "Tofu", 400, 30));
            consumables.Add(new Consumable(19, "Strawberry", 750, 0));
            consumables.Add(new Consumable(20, "Raspberry", 650, 15));
            consumables.Add(new Consumable(21, "Blueberry", 200, 65));
            consumables.Add(new Consumable(22, "Mushrooms", 800, 10));
            consumables.Add(new Consumable(22, "Smoked Paprika", 0, 95));
            consumables.Add(new Consumable(23, "Soy Milk", 1000, 0));
            consumables.Add(new Consumable(23, "Rice Milk", 500, 50));
            consumables.Add(new Consumable(24, "Oat Milk", 250, 85));
            consumables.Add(new Consumable(25, "Cashew Milk", 1200, 0));
            consumables.Add(new Consumable(25, "Almond Milk", 600, 60));
            consumables.Add(new Consumable(26, "Seitan", 900, 40));
            consumables.Add(new Consumable(27, "Soy Protein", 400, 100));

            consumables.Add(new Consumable(25, "Tempeh Stir Fry", 2000, 150));
            consumables.Add(new Consumable(30, "BIO Tofu", 3000, 200));
            #endregion
        }

        void GenerateItems()
        {
            items = new List<Item>();

            items.AddRange(helmets);
            items.AddRange(armors);
            items.AddRange(legs);
            items.AddRange(boots);
            items.AddRange(weapons);

            items.AddRange(consumables);
            items.AddRange(questItems);
        }

        void GenerateEnemies()
        {
            #region Farm
            List<Tuple<Item, int>> antLoot = new List<Tuple<Item, int>>
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Grain of Rice"), 2),
                new Tuple<Item, int>(items.Find(x => x.Name == "Tomato Seed"), 3)
            };
            Enemy ant = new Enemy("Ant", 3, new Tuple<int, int>(0, 1), -60,
                1, new Tuple<int, int>(0, 0), antLoot);

            List<Tuple<Item, int>> bugLoot = new List<Tuple<Item, int>>
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Grain of Rice"), 2),
                new Tuple<Item, int>(items.Find(x => x.Name == "Tomato Seed"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Pumpkin Seed"), 4)
            };
            Enemy bug = new Enemy("Bug", 5, new Tuple<int, int>(0, 1), -60,
                2, new Tuple<int, int>(0, 0), bugLoot);

            List<Tuple<Item, int>> spiderLoot = new List<Tuple<Item, int>>
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Spider's Web"), 1),
                new Tuple<Item, int>(items.Find(x => x.Name == "Spider's Leg"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "Tomato Seed"), 2),
                new Tuple<Item, int>(items.Find(x => x.Name == "Pumpkin Seed"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Chia Seed"), 5)
            };
            Enemy spider = new Enemy("Spider", 8, new Tuple<int, int>(0, 1), -60,
                3, new Tuple<int, int>(0, 0), spiderLoot);

            List<Tuple<Item, int>> cockroachLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Pumpkin Seed"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Chia Seed"), 3)
            };
            Enemy cockroach = new Enemy("Cockroach", 9, new Tuple<int, int>(0, 2), -60,
                5, new Tuple<int, int>(0, 1), cockroachLoot);


            List<Tuple<Item, int>> mantisLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Mantis' Antennae"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "Peanut"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Tobacco Leaf"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Wheat"), 10)
            };
            Enemy mantis = new Enemy("Mantis", 11, new Tuple<int, int>(1, 1), -50,
                6, new Tuple<int, int>(0, 1), mantisLoot);

            List<Tuple<Item, int>> frogLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Frog's Venom"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "Peanut"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Walnut"), 3),
                 new Tuple<Item, int>(items.Find(x => x.Name == "Millet"), 6),

                new Tuple<Item, int>(items.Find(x => x.Name == "Wooden Stick"), 11),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Leather Boots"), 15),
            };
            Enemy frog = new Enemy("Frog", 20, new Tuple<int, int>(1, 2), -50,
                8, new Tuple<int, int>(0, 2), frogLoot);

            List<Tuple<Item, int>> snakeLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Snake's Venom"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "Walnut"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Tobacco Leaf"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Wheat"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Rice"), 6),

                new Tuple<Item, int>(items.Find(x => x.Name == "Wooden Stick"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Leather Legs"), 8),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Leather Armor"), 10),
                new Tuple<Item, int>(items.Find(x => x.Name == "Rock"), 13),
            };
            Enemy snake = new Enemy("Snake", 35, new Tuple<int, int>(1, 3), -50,
                13, new Tuple<int, int>(0, 4), snakeLoot);


            List<Tuple<Item, int>> blackWidowLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Black Widow's Venom"), 1),
                new Tuple<Item, int>(items.Find(x => x.Name == "Black Widow's Leg"), 1),
            };
            Enemy blackWidow = new Enemy("Black Widow", 175, new Tuple<int, int>(2, 4), -30,
                250, new Tuple<int, int>(0, 0), blackWidowLoot, true);


            List<Tuple<Item, int>> bloodSpiderLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Blood Spider's Blood"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "White Beans"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Kidney Beans"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Black Beans"), 14),

                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Leather Helmet"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Leather Armor"), 8),
            };
            Enemy bloodSpider = new Enemy("Blood Spider", 60, new Tuple<int, int>(1, 4), -40,
                25, new Tuple<int, int>(0, 7), bloodSpiderLoot);

            List<Tuple<Item, int>> tarantulaLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Tarantula's Egg"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "White Beans"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Kidney Beans"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Black Beans"), 12),

                new Tuple<Item, int>(items.Find(x => x.Name == "Leather Boots"), 8),
                new Tuple<Item, int>(items.Find(x => x.Name == "Leather Helmet"), 8),
                new Tuple<Item, int>(items.Find(x => x.Name == "Leather Legs"), 10),
                new Tuple<Item, int>(items.Find(x => x.Name == "Quilted Helmet"), 13),
            };
            Enemy tarantula = new Enemy("Tarantula", 90, new Tuple<int, int>(2, 5), -40,
                40, new Tuple<int, int>(0, 7), tarantulaLoot);

            List<Tuple<Item, int>> bananaSpiderLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Banana"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Kidney Beans"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Black Beans"), 10),

                new Tuple<Item, int>(items.Find(x => x.Name == "Leather Armor"), 7),
                new Tuple<Item, int>(items.Find(x => x.Name == "Leather Legs"), 7),
                new Tuple<Item, int>(items.Find(x => x.Name == "Quilted Boots"), 8),
            };
            Enemy bananaSpider = new Enemy("Banana Spider", 125, new Tuple<int, int>(2, 5), -30,
                70, new Tuple<int, int>(5, 15), bananaSpiderLoot);

            List<Tuple<Item, int>> crabSpiderLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Crab Spider's Eye"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "Crab Spider Leg"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "White Beans"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Black Beans"), 6),

                new Tuple<Item, int>(items.Find(x => x.Name == "Quilted Boots"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Quilted Helmet"), 5),
            };
            Enemy crabSpider = new Enemy("Crab Spider", 95, new Tuple<int, int>(4, 12), -50,
                80, new Tuple<int, int>(0, 5), crabSpiderLoot);

            List<Tuple<Item, int>> orangeSpiderLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Orange Blob"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "Orange Spider Venom"), 2),
                new Tuple<Item, int>(items.Find(x => x.Name == "Black Beans"), 4),

                new Tuple<Item, int>(items.Find(x => x.Name == "Wooden Sword"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Quilted Legs"), 4)
            };
            Enemy orangeSpider = new Enemy("Orange Spider", 125, new Tuple<int, int>(2, 5), -15,
                100, new Tuple<int, int>(0, 8), orangeSpiderLoot);


            List<Tuple<Item, int>> squirrelLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Tomato"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cucumber"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Aubergine"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Courgette"), 9),

                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Boots"), 7),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Helmet"), 10),
            };
            Enemy squirrel = new Enemy("Squirrel", 200, new Tuple<int, int>(3, 6), 0,
                160, new Tuple<int, int>(5, 15), squirrelLoot);

            List<Tuple<Item, int>> owlLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Tomato"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cucumber"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Aubergine"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Courgette"), 10),

                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Boots"), 7),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Helmet"), 10),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Legs"), 12),
            };
            Enemy owl = new Enemy("Owl", 150, new Tuple<int, int>(0, 12), 20,
                200, new Tuple<int, int>(5, 25), squirrelLoot);

            List<Tuple<Item, int>> hedgeHogLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Apple"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Pear"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Truffles"), 6),

                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Boots"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Helmet"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Legs"), 11),
                new Tuple<Item, int>(items.Find(x => x.Name == "Wooden Well Carved Sword"), 11),
            };
            Enemy hedgeHog = new Enemy("Hedge Hog", 250, new Tuple<int, int>(1, 7), 75,
                300, new Tuple<int, int>(2, 10), hedgeHogLoot);

            List<Tuple<Item, int>> foxLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Fox's Tail"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "Aubergine"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Courgette"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Truffles"), 5),

                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Legs"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Armor"), 8),
                new Tuple<Item, int>(items.Find(x => x.Name == "Wooden Well Carved Sword"), 6),
            };
            Enemy fox = new Enemy("Fox", 250, new Tuple<int, int>(4, 13), 0,
                400, new Tuple<int, int>(10, 20), foxLoot);

            List<Tuple<Item, int>> wolfLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Wolf's Paw"), 1),

                new Tuple<Item, int>(items.Find(x => x.Name == "Aubergine"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Pear"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Truffles"), 5),

                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Legs"), 2),
                new Tuple<Item, int>(items.Find(x => x.Name == "Worn Bronze Armor"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Used Bronze Sword"), 5),
            };
            Enemy wolf = new Enemy("Wolf", 300, new Tuple<int, int>(6, 14), 20,
                600, new Tuple<int, int>(10, 25), wolfLoot);

            List<Tuple<Item, int>> witchLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Bronze Axe"), 1)
            };
            Enemy witch = new Enemy("Witch", 1750, new Tuple<int, int>(0, 40), 25,
                4000, new Tuple<int, int>(0, 0), witchLoot, true);
            #endregion

            #region Amfurce
            List<Tuple<Item, int>> baconThoLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Apple"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Aubergine"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Courgette"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Pear"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Truffles"), 4),
            };
            Enemy baconTho = new Enemy("Bacon Tho", 700, new Tuple<int, int>(5, 20), 0,
                650, new Tuple<int, int>(0, 25), baconThoLoot);

            List<Tuple<Item, int>> plantFeelingsLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Pear"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Cheese Slice"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Slice of Ham"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Roll"), 5),
            };
            Enemy plantFeelings = new Enemy("Plant Feelings", 600, new Tuple<int, int>(10, 25), 10,
                800, new Tuple<int, int>(0, 30), plantFeelingsLoot);

            List<Tuple<Item, int>> proteinDeficiencyLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Cheese Slice"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Roll"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Butter"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Salt"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Pepper"), 5),
            };
            Enemy proteinDeficiency = new Enemy("Protein Deficiency", 800, new Tuple<int, int>(10, 20), 40,
                1000, new Tuple<int, int>(0, 40), proteinDeficiencyLoot);

            Enemy pastYou = new Enemy("Past You", 1000, new Tuple<int, int>(10, 10), 0,
                1000, new Tuple<int, int>(0, 0), new List<Tuple<Item, int>>(), true);

            List<Tuple<Item, int>> viciousMeatEaterLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Tempeh"), 2),

                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Cheese Slice"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Slice of Ham"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Roll"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Butter"), 5),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Boots"), 18),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Helmet"), 28),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Legs"), 40)
            };
            Enemy viciousMeatEater = new Enemy("Vicious Meat Eater", 750, new Tuple<int, int>(20, 40), -20,
                700, new Tuple<int, int>(20, 50), viciousMeatEaterLoot);

            List<Tuple<Item, int>> sharkFinLoverLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Tempeh"), 2),

                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Cheese Slice"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Slice of Ham"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Roll"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Butter"), 4),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Boots"), 15),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Helmet"), 24),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Legs"), 36),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Armor"), 36),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Sword"), 40)
            };
            Enemy sharkFinLover = new Enemy("Shark Fin Lover", 900, new Tuple<int, int>(30, 50), -10,
                900, new Tuple<int, int>(30, 60), sharkFinLoverLoot);

            List<Tuple<Item, int>> obeseHamburgerEaterLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Tempeh"), 2),

                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Cheese Slice"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Slice of Ham"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Roll"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Vegan Butter"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Orange"), 7),
                new Tuple<Item, int>(items.Find(x => x.Name == "Grape"), 7),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Boots"), 12),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Helmet"), 20),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Legs"), 30),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Armor"), 30),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Sword"), 30),
            };
            Enemy obeseHamburgerEater = new Enemy("Obese Hamburger Eater", 1300, new Tuple<int, int>(30, 55), -20,
                1100, new Tuple<int, int>(30, 60), obeseHamburgerEaterLoot);

            List<Tuple<Item, int>> patientWithHypertensionLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Pak Choi"), 2),

                new Tuple<Item, int>(items.Find(x => x.Name == "Orange"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Grape"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Tofu"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Strawberry"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Raspberry"), 6),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Boots"), 12),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Helmet"), 22),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Legs"), 28),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Armor"), 28),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Sword"), 28),
            };
            Enemy patienWithHypertension = new Enemy("Patient with Hypertension", 1100, new Tuple<int, int>(45, 45), 0,
                1000, new Tuple<int, int>(30, 50), patientWithHypertensionLoot);

            List<Tuple<Item, int>> madmanLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Pak Choi"), 2),

                new Tuple<Item, int>(items.Find(x => x.Name == "Mushrooms"), 2),
                new Tuple<Item, int>(items.Find(x => x.Name == "Orange"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Grape"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Tofu"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Strawberry"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Raspberry"), 6),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Boots"), 10),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Helmet"), 14),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Legs"), 16),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Armor"), 16),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Sword"), 16),
            };
            Enemy madman = new Enemy("Madman", 800, new Tuple<int, int>(0, 130), -10,
                1400, new Tuple<int, int>(0, 100), madmanLoot);

            List<Tuple<Item, int>> cancerPatientLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Pak Choi"), 2),

                new Tuple<Item, int>(items.Find(x => x.Name == "Orange"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Grape"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Tofu"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Strawberry"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Raspberry"), 5),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Legs"), 11),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Armor"), 11),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Sword"), 15),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Boots"), 20),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Helmet"), 25)
            };
            Enemy cancerPatient = new Enemy("Cancer Patient", 2000, new Tuple<int, int>(40, 60), 20,
                2000, new Tuple<int, int>(30, 70), cancerPatientLoot);

            List<Tuple<Item, int>> butcherLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Sauce"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Sesame Oil"), 3),

                new Tuple<Item, int>(items.Find(x => x.Name == "Tofu"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Strawberry"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Raspberry"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Blueberry"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Smoked Paprika"), 6),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cruelty-Free Leather Armor"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Boots"), 9),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Helmet"), 12),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Legs"), 15),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Armor"), 20),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Axe"), 30)
            };
            Enemy butcher = new Enemy("Butcher", 1500, new Tuple<int, int>(30, 60), 0,
                1300, new Tuple<int, int>(40, 90), butcherLoot);

            List<Tuple<Item, int>> fishermanLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Sauce"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Sesame Oil"), 3),

                new Tuple<Item, int>(items.Find(x => x.Name == "Strawberry"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Raspberry"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Blueberry"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Smoked Paprika"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Milk"), 7),
                new Tuple<Item, int>(items.Find(x => x.Name == "Rice Milk"), 7),

                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Boots"), 8),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Helmet"), 11),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Legs"), 14),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Armor"), 18),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Axe"), 25)
            };
            Enemy fisherman = new Enemy("Fisherman", 2000, new Tuple<int, int>(35, 65), 0,
                1800, new Tuple<int, int>(30, 100), fishermanLoot);

            List<Tuple<Item, int>> bullfighterLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Sauce"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Sesame Oil"), 3),

                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Rice Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Oat Milk"), 4),

                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Boots"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Helmet"), 8),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Legs"), 8),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Armor"), 11),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Axe"), 16)
            };
            Enemy bullfighter = new Enemy("Bullfighter", 1600, new Tuple<int, int>(40, 85), 10,
                2400, new Tuple<int, int>(20, 120), bullfighterLoot);

            List<Tuple<Item, int>> cowInseminatorLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather"), 4),

                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Milk"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Rice Milk"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Oat Milk"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cashew Milk"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "Almond Milk"), 6),

                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Boots"), 10),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Helmet"), 10),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Legs"), 17),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Armor"), 21),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Axe"), 20)
            };
            Enemy cowInseminator = new Enemy("Cow Inseminator", 1100, new Tuple<int, int>(110, 140), 0,
                2300, new Tuple<int, int>(40, 60), cowInseminatorLoot);

            List<Tuple<Item, int>> beekeeperLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather"), 3),

                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Milk"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Rice Milk"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Oat Milk"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cashew Milk"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Almond Milk"), 5),

                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Legs"), 9),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Armor"), 9),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Axe"), 9),
                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Boots"), 18),
            };
            Enemy beekeeper = new Enemy("Beekeeper", 1500, new Tuple<int, int>(80, 140), 25,
                2700, new Tuple<int, int>(50, 100), beekeeperLoot);

            List<Tuple<Item, int>> factoryFarmerLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather"), 3),

                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Rice Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Oat Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Cashew Milk"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Almond Milk"), 5),

                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Legs"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Armor"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Axe"), 9),
                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Boots"), 18),
            };
            Enemy factoryFarmer = new Enemy("Factory Farmer", 2500, new Tuple<int, int>(50, 100), 75,
                3500, new Tuple<int, int>(30, 150), factoryFarmerLoot);

            List<Tuple<Item, int>> zooWorkerLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather"), 3),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cashew Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Almond Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Seitan"), 4),

                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Legs"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Leather Armor"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Wooden Axe"), 9),
                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Boots"), 10),
                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Helmet"), 10),
            };
            Enemy zooWorker = new Enemy("Zoo Worker", 2000, new Tuple<int, int>(110, 170), 50,
                4500, new Tuple<int, int>(0, 50), beekeeperLoot);

            Enemy hunter = new Enemy("Hunter", 4000, new Tuple<int, int>(100, 200), 75,
                7000, new Tuple<int, int>(0, 0), new List<Tuple<Item, int>>());

            Enemy poacher = new Enemy("Poacher", 6000, new Tuple<int, int>(100, 125), 125,
                8000, new Tuple<int, int>(0, 0), new List<Tuple<Item, int>>());

            Enemy slaughterhouseOwner = new Enemy("Slaughterhouse Owner", 7000, new Tuple<int, int>(100, 200), 75,
                10000, new Tuple<int, int>(0, 0), new List<Tuple<Item, int>>());

            List<Tuple<Item, int>> angryMeatLoverLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Fragment of Recipe"), 2),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cashew Milk"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Almond Milk"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Seitan"), 5),
                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Protein"), 5),

                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Armor"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Legs"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Boots of Flowing Water"), 9),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Helmet of Flowing Water"), 10),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Legs of Flowing Water"), 12),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Armor of Flowing Water"), 15),
            };
            Enemy angryMeatLover = new Enemy("Angry Meat Lover", 2000, new Tuple<int, int>(150, 200), 100,
                6000, new Tuple<int, int>(50, 250), angryMeatLoverLoot);

            List<Tuple<Item, int>> foriousEggEaterLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Fragment of Recipe"), 2),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cashew Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Almond Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Seitan"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Protein"), 3),

                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Armor"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Legs"), 4),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Boots of Flowing Water"), 8),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Helmet of Flowing Water"), 9),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Legs of Flowing Water"), 11),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Armor of Flowing Water"), 13),
            };
            Enemy foriousEggEater = new Enemy("Forious Egg Eater", 2000, new Tuple<int, int>(200, 250), 125,
                8000, new Tuple<int, int>(50, 250), foriousEggEaterLoot);

            List<Tuple<Item, int>> desperatedBaconLoverLoot = new List<Tuple<Item, int>>()
            {
                new Tuple<Item, int>(items.Find(x => x.Name == "Fragment of Recipe"), 2),

                new Tuple<Item, int>(items.Find(x => x.Name == "Cashew Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Almond Milk"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Seitan"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Soy Protein"), 3),

                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Armor"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "Empathy Legs"), 3),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Boots of Flowing Water"), 6),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Helmet of Flowing Water"), 7),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Legs of Flowing Water"), 8),
                new Tuple<Item, int>(items.Find(x => x.Name == "BIO Armor of Flowing Water"), 9),
            };
            Enemy desperatedBaconLover = new Enemy("Desperated Bacon Lover", 2500, new Tuple<int, int>(200, 300), 125,
                8000, new Tuple<int, int>(50, 250), desperatedBaconLoverLoot);

            Enemy ruinedKing = new Enemy("Ruined King", 50000, new Tuple<int, int>(500, 1000), 250,
                50000, new Tuple<int, int>(0, 0), new List<Tuple<Item, int>>(), true);
            #endregion

            enemies = new List<Enemy>()
            {
                #region Farm
                ant,
                bug,
                spider,

                cockroach,

                mantis,
                frog,
                snake,

                blackWidow,

                bloodSpider,
                tarantula,
                bananaSpider,
                crabSpider,
                orangeSpider,

                squirrel,
                owl,
                hedgeHog,
                fox,
                wolf,

                witch,
                #endregion

                #region Amfurce
                baconTho,
                plantFeelings,
                proteinDeficiency,

                pastYou,

                viciousMeatEater,
                sharkFinLover,
                obeseHamburgerEater,

                patienWithHypertension,
                madman,
                cancerPatient,

                butcher,
                fisherman,
                bullfighter,

                cowInseminator,
                beekeeper,
                factoryFarmer,
                zooWorker,

                hunter,
                poacher,
                slaughterhouseOwner,

                angryMeatLover,
                foriousEggEater,
                desperatedBaconLover,

                ruinedKing
                #endregion
            };
        }

        void GenerateAbilities()
        {
            #region 0 - 11
            AbilityEffects luckyDayEffects = new AbilityEffects(0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 6, 0, 0, 0);
            Ability luckyDay = new Ability("Lucky Day", "@15|You can loot up to @6|6 @15|more @6|gold @15|from the @9|enemies",
                1, 3, 999, 2, luckyDayEffects);

            AbilityEffects strongHandEffects = new AbilityEffects(0, 0, 3, 5, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability strongHand = new Ability("Strong Hand", "@15|Widens your @13|damage @15|range by @13|1 @15|to @13|5 @15|for 2 turns",
                2, 6, 2, 2, strongHandEffects);

            AbilityEffects doubleShotEffects = new AbilityEffects(0, 0, 0, 0, 1,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability doubleShot = new Ability("Double Shot", "@15|Attack your @9|enemy @15|with @13|double @15|the power",
                4, 8, 1, 3, doubleShotEffects);

            AbilityEffects iKnowBetterEffects = new AbilityEffects(0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 2);
            Ability iKnowBetter = new Ability("I Know Better", "@15|Defeating an @9|enemy @15|gives @4|3 times @15|the @4|experience",
                4, 8, 999, 6, iKnowBetterEffects);

            AbilityEffects crippleEffects = new AbilityEffects(0, 0, 0, 0, 0,
                0, 0, -12, -24, 0, 0, 0, 0, 0, 0);
            Ability cripple = new Ability("Cripple", "@15|Narrow your @9|enemy's @13|damage range @15|by @13|12 @15|to @13|24 @15|for 2 turns",
                5, 11, 2, 6, crippleEffects);

            AbilityEffects aegisEffects = new AbilityEffects(200, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability aegis = new Ability("Aegis", "@15|Summon a magical shield, giving yourself @5|200 defense @15|for 5 turns",
                7, 13, 5, 6, aegisEffects);

            AbilityEffects bowEffects = new AbilityEffects(0, 0, 0, 100, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability bow = new Ability("Bow", "@15|Shoot an @9|enemy @15|using a bow, dealing up to @13|100 damage",
                8, 13, 1, 10, bowEffects);

            AbilityEffects breakTheirMindEffects = new AbilityEffects(0, 0, 0, 0, 0,
                -40, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability breakTheirMind = new Ability("Break Their Minds", "@15|Make your @9|enemy @15|mad, lowering their @5|defense @15|by @5|40 @15|for 6 turns",
                8, 13, 6, 12, breakTheirMindEffects);

            AbilityEffects thunderLordEffects = new AbilityEffects(0, 0, 100, 100, 0,
               0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability thunderLord = new Ability("Thunder Lord", "@15|Smite your @9|enemy@15|, dealing @13|100 damage",
                11, 14, 1, 15, thunderLordEffects);

            AbilityEffects rainEffects = new AbilityEffects(0, 0, 0, 0, 0,
               0, 0, 0, 0, 0, 0, 0, 4, 0, 0);
            Ability rain = new Ability("Rain", "@15| Loot up @6|5 times @15|more @6|gold @15|from an @9|enemy",
                11, 15, 999, 15, rainEffects);

            AbilityEffects newToTheGameEffects = new AbilityEffects(0, 0, 0, 0, 0,
               0, 0, 0, 0, 0, 0, 0, 0, 500, 0);
            Ability newToTheGame = new Ability("New To The Game", "@15|Defeating an @9|enemy @15|gives you @4|500 @15|more @4|experience",
                11, 15, 999, 15, newToTheGameEffects);
            #endregion

            #region 13 - 19
            AbilityEffects godBlessingEffects = new AbilityEffects(0, 4, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability godBlessing = new Ability("God's Blessing", "@15|Pray to the God, increasing your @5|defense 5 times @15|for 7 turns",
                13, 20, 7, 20, godBlessingEffects);

            AbilityEffects hitOrMissEffects = new AbilityEffects(0, 0, 0, 0, 0,
               0, 0, -50, -50, 0, 0, 0, 0, 0, 0);
            Ability hitOrMiss = new Ability("Hit or Miss", "@9|Enemy @15|does @13|50 @15|less @13|damage @15|for 5 turns",
                15, 21, 5, 20, hitOrMissEffects);

            AbilityEffects learningExperienceEffects = new AbilityEffects(0, 0, 0, 0, 0,
               0, 0, 0, 0, 0, 0, 0, 0, 0, 1);
            Ability learningExperience = new Ability("Learning Experience", "@15|Defeating an @9|enemy @15|gives @4|2 times @15|the @4|experience",
                15, 21, 999, 25, learningExperienceEffects);

            AbilityEffects defenseLessEffects = new AbilityEffects(0, 0, 0, 0, 0,
               -65, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability defenseLess = new Ability("Defense Less", "@15|Destroy @9|enemy @5|defense@15|, lowering it by @5|65 @15|for 4 turns",
                15, 21, 4, 30, defenseLessEffects);

            AbilityEffects squareEffects = new AbilityEffects(0, 0, 0, 0, 2,
               0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability square = new Ability("Square", "@15|Hit @9|enemy @13|3 times @15|in one turn",
                15, 25, 1, 30, squareEffects);

            AbilityEffects doubleEdgeSwordEffects = new AbilityEffects(0, 0, 0, 0, 3,
               0, 0, 0, 0, 3, 0, 0, 0, 0, 0);
            Ability doubleEdgeSword = new Ability("Double Edged Sword", "@15|Both @9|enemy @15|and you have @13|damage @15|multiplied by @13|4 @15|for 3 turns",
                19, 25, 3, 40, doubleEdgeSwordEffects);

            AbilityEffects berserkEffects = new AbilityEffects(-150, 0, 20, 200, 0,
               0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability berserk = new Ability("Berserk", "@15|Lower your @5|defense @15|by @5|-150 @15|and increase your @13|damage @15|by @13|20 @15|to @13|200 @15|for 4 turns",
                19, 25, 4, 40, berserkEffects);
            #endregion

            #region 22 - 50
            AbilityEffects tortoiseEffects = new AbilityEffects(0, 5, 0, 0, 0,
               50, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability tortoise = new Ability("Tortoise",
                "@15|Increases your @5|defense 6 times @15|and @9|enemy @5|defense @15|by @5|50 @15|for 10 turns",
                22, 29, 10, 50, tortoiseEffects);

            AbilityEffects betterVersionEffects = new AbilityEffects(0, 0, 0, 0, 0,
               0, 0, 0, 0, 0, 0, 0, 2, 0, 2);
            Ability betterVersion = new Ability("Better Version",
                "@15|Defeating an @9|enemy @15|gives @6|3 times @15|the @6|gold @15|and @4|experience",
                22, 29, 999, 75, betterVersionEffects);

            AbilityEffects fasterThanEverEffects = new AbilityEffects(0, 0, 0, 0, 11,
               0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability fasterThanEver = new Ability("Faster Than Ever",
                "@15|Hit an @9|enemy @13|12 times @15|in one turn",
                26, 50, 1, 80, fasterThanEverEffects);

            AbilityEffects blindEffects = new AbilityEffects(0, 0, 0, 0, 0,
               0, 0, -400, 0, 0, 0, 0, 0, 0, 0);
            Ability blind = new Ability("Blind",
                "@15|Blind an @9|enemy@15|, decreasing their @13|minimum damage @15|by @13|400 @15|for 4 turns",
                26, 50, 4, 80, blindEffects);

            AbilityEffects recoilEffects = new AbilityEffects(0, 0, -200, 400, 0,
                 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability recoil = new Ability("Recoil",
                "@15|Increase your @13|maximum damage @15|by @13|400@15|, but decrease @13|minimum @15|by @13|200 @15|for 3 turns",
                30, 50, 3, 100, recoilEffects);

            AbilityEffects strongerThanYouThinkEffects = new AbilityEffects(0, 0.5, 0, 0, 0,
               0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability strongerThanYouThink = new Ability("Stronger Than You Think",
                "@15|Increase your @5|defense @15|by @5|50% @15|till the end of the fight",
                32, 50, 999, 125, strongerThanYouThinkEffects);

            AbilityEffects littleBigDamageEffects = new AbilityEffects(0, 0, 0, 0, 0.3,
               0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Ability littleBigDamage = new Ability("Little Big Damage",
                "@15|Increase your @13|damage @15|by @13|30% @15|till the end of the fight",
                32, 50, 999, 125, littleBigDamageEffects);
            #endregion

            abilities = new List<Ability>()
            {
                #region 0 - 11         
                luckyDay,
                strongHand,
                doubleShot,
                iKnowBetter,
                cripple,

                aegis,
                bow,
                breakTheirMind,
                #endregion

                #region 13 - 19
                thunderLord,
                rain,
                newToTheGame,
                godBlessing,

                hitOrMiss,
                learningExperience,
                defenseLess,
                square,
                doubleEdgeSword,
                berserk,
                #endregion

                #region 22 - 50
                tortoise,
                betterVersion,

                fasterThanEver,
                blind,
                recoil,
                strongerThanYouThink,
                littleBigDamage,       
                #endregion
            };
        }

        void GenerateQuestItems()
        {
            #region Farm
            QuestItem spiderWeb = new QuestItem("Spider's Web");

            QuestItem snakeVenom = new QuestItem("Snake's Venom");
            QuestItem frogVenom = new QuestItem("Frog's Venom");

            QuestItem tarantulaEgg = new QuestItem("Tarantula's Egg");
            QuestItem crabSpiderEye = new QuestItem("Crab Spider's Eye");
            QuestItem orangeBlob = new QuestItem("Orange Blob");

            QuestItem spiderLeg = new QuestItem("Spider's Leg");
            QuestItem mantisAntennae = new QuestItem("Mantis' Antennae");
            QuestItem bloodSpiderBlood = new QuestItem("Blood Spider's Blood");
            QuestItem foxTail = new QuestItem("Fox's Tail");
            QuestItem wolfPaw = new QuestItem("Wolf's Paw");
            #endregion

            #region Amfurce
            QuestItem tempeh = new QuestItem("Tempeh");
            QuestItem pakChoi = new QuestItem("Pak Choi");
            QuestItem soySauce = new QuestItem("Soy Sauce");
            QuestItem sesameOil = new QuestItem("Sesame Oil");

            QuestItem bioLeather = new QuestItem("BIO Leather");
            QuestItem fragmentOfRecipe = new QuestItem("Fragment of Recipe");
            #endregion

            questItems = new List<QuestItem>()
            {
                #region Farm
                spiderWeb,
                snakeVenom,
                frogVenom,

                tarantulaEgg,
                crabSpiderEye,
                orangeBlob,

                spiderLeg,
                mantisAntennae,
                bloodSpiderBlood,
                foxTail,
                wolfPaw,
                #endregion

                #region Amfurce
                tempeh,
                pakChoi,
                soySauce,
                sesameOil,

                bioLeather,
                fragmentOfRecipe
                #endregion
            };
        }

        void GenerateQuests()
        {
            #region Farm
            List<Tuple<Enemy, int>> emptyEnemies = new List<Tuple<Enemy, int>>();
            List<Tuple<QuestItem, int>> emptyQuestItems = new List<Tuple<QuestItem, int>>();
            List<Item> emptyRewards = new List<Item>();

            Quest peterProblem = new Quest("Peter's Problem",
                "@15|Ask @9|Peter @15|about the @10|place\n",
                emptyEnemies, emptyQuestItems, 0, 10, emptyRewards, true);

            List<Tuple<Enemy, int>> antVacuumEnemies = new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Ant"), 6)
            };
            Quest antVacuum = new Quest("Ant Vacuum",
                "@15|I would give you a vacuum cleaner, if I would have one\n",
                antVacuumEnemies, emptyQuestItems,
                10, 20, emptyRewards);

            List<Tuple<QuestItem, int>> inTheWebQuestItems = new List<Tuple<QuestItem, int>>()
            {
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name== "Spider's Web"), 4)
            };
            List<Item> inTheWebRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Worn Leather Helmet")
            };
            Quest inTheWeb = new Quest("In The Web",
                "@15|I can't see anything in my @2|basement\n",
                emptyEnemies, inTheWebQuestItems,
                20, 20, inTheWebRewards);

            List<Tuple<Enemy, int>> filthyCockroachesEnemies = new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Cockroach"), 7)
            };
            Quest filthyCockroaches = new Quest("Filthy Cockroaches",
                "@15|These stingy @9|insects @15|stole all of my @6|coins\n",
                filthyCockroachesEnemies, emptyQuestItems,
                40, 0, emptyRewards);

            List<Tuple<QuestItem, int>> venomousFarmItems = new List<Tuple<QuestItem, int>>()
            {
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Snake's Venom"), 4),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Frog's Venom"), 4)
            };
            List<Item> venomousFarmRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Branch"),
                items.Find(x => x.Name == "Tobacco Leaf"),
                items.Find(x => x.Name == "Rice")
            };
            Quest venomousFarm = new Quest("Venomous Farm",
                "@15|Something causes our @9|people @15|to vomit extremely often\n",
                emptyEnemies, venomousFarmItems,
                0, 100, venomousFarmRewards);

            List<Tuple<Enemy, int>> whiteWidowEnemies = new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Black Widow"), 1)
            };
            Quest whiteWidow = new Quest("White Widow",
                "@15|You have the best opportunity to stop this madness\n",
                whiteWidowEnemies, emptyQuestItems,
                50, 0, emptyRewards);

            Quest myBrotherHenry = new Quest("My Brother Henry",
                "@15|Please talk to @9|Henry@15|, when he arrives.\n",
                emptyEnemies, emptyQuestItems,
                0, 0, emptyRewards, true);

            List<Tuple<Enemy, int>> bloodyDenEnemies = new List<Tuple<Enemy, int>>()
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Blood Spider"), 7)
            };
            List<Item> bloodyDenRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Wooden Sword"),
            };
            Quest bloodyDen = new Quest("Bloody Den",
                "@15|You gonna give them a hell\n",
                bloodyDenEnemies, emptyQuestItems,
                50, 0, bloodyDenRewards);

            List<Tuple<QuestItem, int>> spiderKingItems = new List<Tuple<QuestItem, int>>()
            {
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Tarantula's Egg"), 4),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Crab Spider's Eye"), 4),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Orange Blob"), 4),
            };
            List<Item> spiderKingRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Quilted Armor"),
                items.Find(x => x.Name == "Bowl of Spider Soup")
            };
            Quest spiderKing = new Quest("Spider King",
                "@15|I'm going to prepare an amazing @14|soup\n",
                emptyEnemies, spiderKingItems,
                100, 0, spiderKingRewards);

            List<Tuple<Enemy, int>> backInTimeEnemies = new List<Tuple<Enemy, int>>()
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Ant"), 20),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Bug"), 8),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Spider"), 6),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Cockroach"), 5)
            };
            List<Item> backInTimeRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Worn Bronze Boots"),
                items.Find(x => x.Name == "Wooden Axe")
            };
            Quest backInTime = new Quest("Back In Time",
                "@15|Show some respect to the past\n",
                backInTimeEnemies, emptyQuestItems,
                0, 1000, backInTimeRewards);

            List<Tuple<Enemy, int>> laboursOfHerculesEnemies = new List<Tuple<Enemy, int>>()
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Mantis"), 12),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Frog"), 7),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Snake"), 3)
            };
            List<Item> laboursOfHerculesRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Vegan Cheese Slice"),
                items.Find(x => x.Name == "Worn Bronze Helmet"),
            };
            Quest laboursOfHercules = new Quest("Labours of Hercules",
                "@15|You'd need to clean the @2|shed properly\n",
                laboursOfHerculesEnemies, emptyQuestItems,
                150, 2000, laboursOfHerculesRewards);

            List<Tuple<QuestItem, int>> farmFaunaItems = new List<Tuple<QuestItem, int>>()
            {
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Spider's Leg"), 3),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Mantis' Antennae"), 4),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Blood Spider's Blood"), 5),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Fox's Tail"), 6),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Wolf's Paw"), 7),
            };
            List<Item> farmFaunaRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Farmenstein"),
                items.Find(x => x.Name == "Farmenstein"),
                items.Find(x => x.Name == "Farmenstein"),
            };
            Quest farmFauna = new Quest("Farm Fauna",
                "@15|I hope you recognize all of @12|them\n",
                emptyEnemies, farmFaunaItems,
                1500, 0, farmFaunaRewards);

            List<Tuple<Enemy, int>> witchHuntEnemies = new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Witch"), 1)
            };
            Quest witchHunt = new Quest("Witch Hunt",
                "@15|That's your way to go\n",
                witchHuntEnemies, emptyQuestItems,
                0, 0, emptyRewards);
            #endregion

            #region Amfurce
            List<Item> veganRevolutionRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Vegan Cheese Slice"),
                items.Find(x => x.Name == "Vegan Slice of Ham"),
                items.Find(x => x.Name == "Roll"),
                items.Find(x => x.Name == "Vegan Butter"),
                items.Find(x => x.Name == "Salt"),
                items.Find(x => x.Name == "Pepper"),
            };
            Quest veganRevolution = new Quest("Vegan Revolution",
                "@15|Ask @9|Sam @15|about the @10|place\n",
                emptyEnemies, emptyQuestItems, 0, 0, veganRevolutionRewards, true);

            List<Tuple<Enemy, int>> intrusiveThoughtsEnemies = new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Protein Deficiency"), 4),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Plant Feelings"), 6),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Bacon Tho"), 7),
            };
            List<Item> intrusiveThoughtsRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Vegan Sandwich"),
            };
            Quest intrusiveThoughts = new Quest("Intrusive Thoughts",
                "@15|First of all, you have to challenge and win against your former self\n",
                intrusiveThoughtsEnemies, emptyQuestItems, 0, 5000, emptyRewards);

            List<Tuple<Enemy, int>> pastYouEnemies = new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Past You"), 1),
            };
            List<Item> pastYouRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Artificial Leather Helmet"),
                items.Find(x => x.Name == "Artificial Leather Armor"),
                items.Find(x => x.Name == "Artificial Leather Legs"),
                items.Find(x => x.Name == "Artificial Leather Boots"),
                items.Find(x => x.Name == "BIO Wooden Stick"),
            };
            Quest pastYou = new Quest("Past You",
                "@15|Now is the time to truly win against yourself\n",
                pastYouEnemies, emptyQuestItems, 0, 0, pastYouRewards);

            List<Tuple<QuestItem, int>> exoticIngredientsItems = new List<Tuple<QuestItem, int>>()
            {
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Tempeh"), 12),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Pak Choi"), 12),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Soy Sauce"), 8),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Sesame Oil"), 8)
            };
            List<Item> exoticIngredientsRewards = new List<Item>()
            {
                items.Find(x => x.Name == "Tempeh Stir Fry"),
                items.Find(x => x.Name == "Tempeh Stir Fry"),
                items.Find(x => x.Name == "Tempeh Stir Fry"),
                items.Find(x => x.Name == "Tempeh Stir Fry"),
                items.Find(x => x.Name == "Tempeh Stir Fry"),
                items.Find(x => x.Name == "Empathy Sword"),
            };
            Quest exoticIngredients = new Quest("Exotic Ingredients",
                "@15|I'm gonna prepare something @14|special @15|for you\n",
                emptyEnemies, exoticIngredientsItems, 5000, 5000, exoticIngredientsRewards);

            List<Tuple<QuestItem, int>> stolenRecipeItems = new List<Tuple<QuestItem, int>>()
            {
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "BIO Leather"), 10),
                new Tuple<QuestItem, int>(questItems.Find(x => x.Name == "Fragment of Recipe"), 10),
            };
            List<Item> stolenRecipeRewards = new List<Item>()
            {
                items.Find(x => x.Name == "BIO Leather Ball"),
            };
            Quest stolenRecipe = new Quest("Stolen Recipe",
                "@9|They @15|think it's gonna stop us\n",
                emptyEnemies, stolenRecipeItems, 0, 100000, stolenRecipeRewards);

            List<Tuple<Enemy, int>> thisIsForbiddenEnemies = new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Slaughterhouse Owner"), 1),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Poacher"), 1),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Hunter"), 1),
            };
            List<Item> thisIsForbiddenRewards = new List<Item>()
            {
                items.Find(x => x.Name == "BIO Staff of Flowing Water"),
            };
            Quest thisIsForbidden = new Quest("This Is Forbidden",
                "@15|We don't go there\n",
                thisIsForbiddenEnemies, emptyQuestItems, 0, 0, thisIsForbiddenRewards);

            List<Tuple<Enemy, int>> theEndEnemies = new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Ruined King"), 1),
            };
            Quest theEnd = new Quest("The End",
                "@15|Your final task\n",
                theEndEnemies, emptyQuestItems, 0, 0, emptyRewards);
            #endregion

            quests = new List<Quest>()
            {
                #region Farm
                peterProblem,
                antVacuum,
                inTheWeb,

                filthyCockroaches,
                venomousFarm,
                whiteWidow,

                myBrotherHenry,
                bloodyDen,
                spiderKing,

                backInTime,
                laboursOfHercules,
                farmFauna,
                witchHunt,
                #endregion

                #region Amfurce
                veganRevolution,
                intrusiveThoughts,
                pastYou,

                exoticIngredients,

                stolenRecipe,
                thisIsForbidden,

                theEnd
                #endregion
            };
        }

        void GenerateAreas()
        {
            #region Farm
            Area basement = new Area("Basement", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Cockroach"), 8),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Spider"), 4),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Bug"), 3),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Ant"), 1)
            });

            Area shed = new Area("Shed", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Snake"), 9),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Frog"), 5),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Mantis"), 3),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Cockroach"), 1)
            });

            Area blackWidow = new Area("Black Widow", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Black Widow"), 1)
            });

            Area spiderDen = new Area("Spider Den", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Orange Spider"), 9),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Crab Spider"), 7),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Banana Spider"), 5),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Tarantula"), 4),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Blood Spider"), 1)
            });

            Area forest = new Area("Forest", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Wolf"), 7),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Fox"), 6),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Hedge Hog"), 6),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Owl"), 5),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Squirrel"), 1)
            });

            Area witchHut = new Area("Witch Hut", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Witch"), 1)
            });
            #endregion

            #region Amfurce
            Area mind = new Area("Mind", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Protein Deficiency"), 6),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Plant Feelings"), 3),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Bacon Tho"), 1)
            });

            Area shadowLand = new Area("Shadow Land", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Past You"), 1)
            });

            Area suburb = new Area("Suburb", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Obese Hamburger Eater"), 4),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Shark Fin Lover"), 2),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Vicious Meat Eater"), 1),
            });

            Area hospital = new Area("Hospital", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Cancer Patient"), 4),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Madman"), 2),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Patient with Hypertension"), 1),
            });

            Area complaintsRoom = new Area("Complaints Room", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Butcher"), 4),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Fisherman"), 2),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Bullfighter"), 1),
            });

            Area outsideTheCity = new Area("Outside the City", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Zoo Worker"), 7),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Factory Farmer"), 5),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Beekeeper"), 2),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Cow Inseminator"), 1)
            });

            Area forbiddenArea = new Area("Forbidden Area", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Slaughterhouse Owner"), 3),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Poacher"), 2),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Hunter"), 1),
            });

            Area cityHall = new Area("City Hall", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Desperated Bacon Lover"), 4),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Forious Egg Eater"), 2),
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Angry Meat Lover"), 1),
            });

            Area throneRoom = new Area("Throne Room", new List<Tuple<Enemy, int>>
            {
                new Tuple<Enemy, int>(enemies.Find(x => x.Name == "Ruined King"), 1),
            });
            #endregion

            areas = new List<Area>()
            {
                #region Farm
                basement,
                shed,
                blackWidow,

                spiderDen,
                forest,
                witchHut,
                #endregion

                #region Amfurce
                mind,
                shadowLand,

                suburb,
                hospital,
                complaintsRoom,

                outsideTheCity,
                forbiddenArea,

                cityHall,
                throneRoom
                #endregion
            };
        }

        void GenerateNpcs()
        {
            #region Farm
            string peterHello = "Be quick, I'm pretty busy";
            string peterWork = "@15|I @6|buy @15|many different things\n\n";
            string peterPlace = "@15|I love this @10|place@15|, but my @2|basement @15|got ruined, because of these @9|insects";
            List<Tuple<Quest, Quest>> peterQuests = new List<Tuple<Quest, Quest>>()
            {
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Ant Vacuum"), quests.Find(x => x.Name == "Peter's Problem")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "In The Web"), quests.Find(x => x.Name == "Ant Vacuum"))
            };
            Merchant peter = new Merchant("Peter", peterHello, peterWork, peterPlace,
                peterQuests, 1.0,
                null, quests.Find(x => x.Name == "Peter's Problem"));


            string adamHello = "@15|Hello, glad to see a new face on our @10|farm";
            string adamWork = "@15|I have a little @6|store @15|over there, take a look inside\n\n";
            string adamPlace = "@15|Life here was great up until the last year\n" +
                "Suddenly all these things started to come from the @2|forest";
            List<Tuple<Quest, Quest>> adamQuests = new List<Tuple<Quest, Quest>>()
            {
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Filthy Cockroaches"), quests.Find(x => x.Name == "In The Web")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Venomous Farm"), quests.Find(x => x.Name == "In The Web"))
            };
            List<Item> adamItems = new List<Item>()
            {
                items.Find(x => x.Name == "Leather Helmet"),
                items.Find(x => x.Name == "Worn Leather Armor"),
                items.Find(x => x.Name == "Worn Leather Legs"),
                items.Find(x => x.Name == "Worn Leather Boots"),
                items.Find(x => x.Name == "Leather Boots"),
                items.Find(x => x.Name == "Wooden Stick"),
                items.Find(x => x.Name == "Rock")
            };
            Shopkeeper adam = new Shopkeeper("Adam", adamHello, adamWork, adamPlace,
                adamQuests, 3.0, adamItems);


            string marcusHello = "Glad to see you";
            string marcusWork = "@15|I @6|work @15|on the field, I can sell you some @14|crops\n\n";
            string marcusPlace = "@15|Someone needs to finally get rid of these @9|insects";
            List<Tuple<Quest, Quest>> marcusQuests = new List<Tuple<Quest, Quest>>()
            {
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "White Widow"), quests.Find(x => x.Name == "Venomous Farm")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "My Brother Henry"), quests.Find(x => x.Name == "White Widow")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Bloody Den"), quests.Find(x => x.Name == "White Widow")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Spider King"), quests.Find(x => x.Name == "White Widow"))
            };
            List<Item> marcusItems = new List<Item>()
            {
                items.Find(x => x.Name == "Millet"),
                items.Find(x => x.Name == "Tobacco Leaf"),
                items.Find(x => x.Name == "Apple Juice"),
                items.Find(x => x.Name == "Kidney Beans"),
                items.Find(x => x.Name == "Aubergine"),
                items.Find(x => x.Name == "Courgette"),
                items.Find(x => x.Name == "Pear")
            };
            Shopkeeper marcus = new Shopkeeper("Marcus", marcusHello, marcusWork, marcusPlace,
                marcusQuests, 4.0, marcusItems,
                quests.Find(x => x.Name == "Venomous Farm"), null);


            string henryHello = "@15|Hello, my brother @9|Marcus @15|has told me about you";
            string henryWork = "@15|I sell beatufily crafted @8|bronze set @15|from the neighbour @10|city\n\n";
            string henryPlace = "@9|Marcus @15|said you are ready and willing to face the danger coming from the @2|forest\n" +
                "@15|I can prepare you for that fight, but beware there were many before you";
            List<Tuple<Quest, Quest>> henryQuests = new List<Tuple<Quest, Quest>>()
            {
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Back In Time"),
                    quests.Find(x => x.Name == "My Brother Henry")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Labours of Hercules"),
                    quests.Find(x => x.Name == "My Brother Henry")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Farm Fauna"),
                    quests.Find(x => x.Name == "Labours of Hercules")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Witch Hunt"),
                    quests.Find(x => x.Name == "Farm Fauna")),
            };
            List<Item> henryItems = new List<Item>()
            {
                items.Find(x => x.Name == "Bronze Helmet"),
                items.Find(x => x.Name == "Bronze Armor"),
                items.Find(x => x.Name == "Bronze Legs"),
                items.Find(x => x.Name == "Bronze Boots"),
                items.Find(x => x.Name == "Bronze Sword")
            };
            Shopkeeper henry = new Shopkeeper("Henry", henryHello, henryWork, henryPlace,
                henryQuests, 8.0, henryItems,
                quests.Find(x => x.Name == "Bloody Den"), quests.Find(x => x.Name == "My Brother Henry"));
            #endregion

            #region Amfurce
            string samHello = "@15|Welcome to our little big revolution";
            string samWork = "@15|Come on you need some @14|food\n\n";
            string samPlace = "@15|If you want to be respected in @10|Amfurce @15|\nyou have to show respect towards @9|animals";
            List<Tuple<Quest, Quest>> samQuests = new List<Tuple<Quest, Quest>>()
            {
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Intrusive Thoughts"),
                    quests.Find(x => x.Name == "Vegan Revolution")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Past You"),
                    quests.Find(x => x.Name == "Intrusive Thoughts")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Exotic Ingredients"),
                    quests.Find(x => x.Name == "Past You")),
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "The End"),
                    quests.Find(x => x.Name == "Stolen Recipe"))
            };
            List<Item> samItems = new List<Item>()
            {
                items.Find(x => x.Name == "Vegan Cheese Slice"),
                items.Find(x => x.Name == "Vegan Slice of Ham"),
                items.Find(x => x.Name == "Bread"),
                items.Find(x => x.Name == "Salt"),
                items.Find(x => x.Name == "Orange"),
                items.Find(x => x.Name == "Strawberry"),
                items.Find(x => x.Name == "Smoked Paprika"),
                items.Find(x => x.Name == "Soy Milk"),
                items.Find(x => x.Name == "Seitan")
            };
            Shopkeeper sam = new Shopkeeper("Sam", samHello, samWork, samPlace,
                samQuests, 2.0, samItems,
                null, quests.Find(x => x.Name == "Vegan Revolution"));

            string ericHello = "You proved us your value";
            string ericWork = "@15|Someone needs to keep all of this stuff\n\n";
            string ericPlace = "@15|Beatiful @10|city@15|, less beatiful @9|people";
            List<Tuple<Quest, Quest>> ericQuests = new List<Tuple<Quest, Quest>>()
            {
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "Stolen Recipe"),
                    quests.Find(x => x.Name == "Exotic Ingredients")),
            };
            Merchant eric = new Merchant("Eric", ericHello, ericWork, ericPlace,
                ericQuests, 1.0,
                quests.Find(x => x.Name == "Past You"), null);

            string danHello = "@15|Show some empathy to all living @9|things";
            string danWork = "I want to show you something beatiful\n\n";
            string danPlace = "@15|It's better than ever";
            List<Tuple<Quest, Quest>> danQuests = new List<Tuple<Quest, Quest>>()
            {
                new Tuple<Quest, Quest>(quests.Find(x => x.Name == "This Is Forbidden"),
                    quests.Find(x => x.Name == "Exotic Ingredients")),
            };
            List<Item> danItems = new List<Item>()
            {
                items.Find(x => x.Name == "Empathy Helmet"),
                items.Find(x => x.Name == "Empathy Armor"),
                items.Find(x => x.Name == "Empathy Legs"),
                items.Find(x => x.Name == "Empathy Boots"),
                items.Find(x => x.Name == "BIO Tofu")
            };
            Shopkeeper dan = new Shopkeeper("Dan", danHello, danWork, danPlace,
                danQuests, 7.0, danItems,
                quests.Find(x => x.Name == "Exotic Ingredients"), null);
            #endregion

            npcs = new List<NPC>()
            {
                peter,
                adam,
                marcus,
                henry,

                sam,
                eric,
                dan
            };
        }

        void GenerateCities()
        {
            cities = new List<City>();

            #region Amfurce
            List<NPC> amfurceNpcs = new List<NPC>()
            {
                npcs.Find(x => x.Name == "Sam"),
                npcs.Find(x => x.Name == "Eric"),
                npcs.Find(x => x.Name == "Dan")
            };
            List<Tuple<Area, Quest>> amfurceAreas = new List<Tuple<Area, Quest>>()
            {
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Outside the City"), quests.Find(x => x.Name == "Exotic Ingredients")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "City Hall"), quests.Find(x => x.Name == "This Is Forbidden"))
            };
            List<Tuple<Area, Quest>> amfurceTemporaryAreas = new List<Tuple<Area, Quest>>()
            {
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Mind"), quests.Find(x => x.Name == "Intrusive Thoughts")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Shadow Land"), quests.Find(x => x.Name == "Past You")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Suburb"), quests.Find(x => x.Name == "Exotic Ingredients")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Hospital"), quests.Find(x => x.Name == "Exotic Ingredients")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Complaints Room"), quests.Find(x => x.Name == "Exotic Ingredients")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Forbidden Area"), quests.Find(x => x.Name == "This Is Forbidden")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Throne Room"), quests.Find(x => x.Name == "The End"))
            };

            City amfurce = amfurce = new City("Amfurce", quests.Find(x => x.Name == "Vegan Revolution"),
                null, null,
                amfurceNpcs, amfurceAreas, amfurceTemporaryAreas);
            #endregion

            #region Farm
            List<NPC> farmNpcs = new List<NPC>()
            {
                npcs.Find(x => x.Name == "Peter"),
                npcs.Find(x => x.Name == "Adam"),
                npcs.Find(x => x.Name == "Marcus"),
                npcs.Find(x => x.Name == "Henry"),
            };
            List<Tuple<Area, Quest>> farmAreas = new List<Tuple<Area, Quest>>()
            {
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Basement"), quests.Find(x => x.Name == "Peter's Problem")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Shed"), quests.Find(x => x.Name == "In The Web")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Spider Den"), quests.Find(x => x.Name == "White Widow")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Forest"), quests.Find(x => x.Name == "My Brother Henry")),
            };
            List<Tuple<Area, Quest>> temporaryFarmAreas = new List<Tuple<Area, Quest>>()
            {
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Black Widow"), quests.Find(x => x.Name == "White Widow")),
                new Tuple<Area, Quest>(areas.Find(x => x.Name == "Witch Hut"), quests.Find(x => x.Name == "Witch Hunt"))
            };

            City farm = new City("Farm", quests.Find(x => x.Name == "Peter's Problem"),
                quests.Find(x => x.Name == "Witch Hunt"), amfurce,
                farmNpcs, farmAreas, temporaryFarmAreas);
            #endregion

            cities.Add(farm);
            cities.Add(amfurce);
        }
    }
}
