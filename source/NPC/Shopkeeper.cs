using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganRPG
{
    class Shopkeeper : NPC
    {
        double valueMultiplier;
        List<Item> items;

        public Shopkeeper(string name, string helloMessage, string workMessage, string placeMessage, 
            List<Tuple<Quest, Quest>> quests, double valueMultipler, List<Item> items, 
            Quest questToActivate = null, Quest placeQuest = null) : 
            base(name, helloMessage, workMessage, placeMessage, quests, questToActivate, placeQuest)
        {
            ValueMultiplier = valueMultipler;
            Items = items;
        }

        public override void Work(Player player)
        {
            while (true)
            {
                Console.Clear();

                Util.WriteColorString(WorkMessage);

                Util.WriteLine("1. Buy");

                Util.WriteLine("\n0. Exit");

                var decision = Console.ReadKey();

                if (decision.Key == ConsoleKey.NumPad0)
                {
                    break;
                }
                else if (decision.Key == ConsoleKey.NumPad1)
                {
                    BuyItems(player);
                }
            }
        }

        void BuyItems(Player player)
        {
            while (true)
            {
                Console.Clear();

                Util.WriteColorString("@4|Level@15|: @4|" + player.Level + "\n");

                /*Util.Write("Level", ConsoleColor.DarkRed);
                Util.Write(": ");
                Util.WriteLine(player.Level + "", ConsoleColor.DarkRed);*/

                Util.WriteColorString("@6|Gold@15|: @6|" + player.Gold + "\n");

                /*Util.Write("Gold", ConsoleColor.DarkYellow);
                Util.Write(": ");
                Util.WriteLine(player.Gold + "\n", ConsoleColor.DarkYellow);*/

                Util.WriteLine("Things to buy: ");

                for (int i = 0; i < items.Count; ++i)
                {
                    Util.Write(i + 1 + " ");
                    items[i].Info(false);

                    Util.WriteColorString("@15| - @6|" + (items[i].Value() * ValueMultiplier) + "G\n");

                    /*Util.Write(" - ");
                    Util.Write((items[i].Value() * ValueMultiplier) + "G\n", ConsoleColor.DarkYellow);*/
                }

                Util.WriteLine("\n0. Exit");

                int decision = Util.NumpadKeyToInt(Console.ReadKey());

                Console.Clear();

                if (decision == 0)
                {
                    break;
                }
                else if (decision > 0)
                {
                    if (decision < items.Count + 1)
                    {
                        if (player.Gold < items[decision - 1].Value() * ValueMultiplier)
                        {
                            Util.WriteColorString("@15|You don't have enough @6|gold @15|to buy ");

                            /*Util.Write("You don't have enough ");
                            Util.Write("gold ", ConsoleColor.DarkYellow);
                            Util.Write("to buy ");*/

                            if (items[decision - 1] is Consumable)
                            {
                                Util.WriteColorString("@6|" + items[decision - 1].Name + "\n");

                                /*Util.WriteLine(items[decision - 1].Name, ConsoleColor.Yellow);*/
                            }
                            else
                            {
                                Util.WriteColorString("@8|" + items[decision - 1].Name + "\n");

                                /*Util.WriteLine(items[decision - 1].Name, ConsoleColor.DarkGray);*/
                            }

                            Console.ReadKey();
                        }
                        else if (decision > 0)
                        {
                            player.Gold -= Convert.ToInt32(items[decision - 1].Value() * ValueMultiplier);

                            Util.Write("You bought ");
                            if (items[decision - 1] is Consumable)
                            {
                                Util.WriteColorString("@6|" + items[decision - 1].Name + " ");

                                /*Util.Write(items[decision - 1].Name + " ", ConsoleColor.DarkYellow);*/
                            }
                            else
                            {
                                Util.WriteColorString("@8|" + items[decision - 1].Name + " ");

                                /*Util.Write(items[decision - 1].Name + " ", ConsoleColor.DarkGray);*/
                            }

                            Util.WriteColorString("for @6|" + items[decision - 1].Value() * ValueMultiplier + " G\n");

                            /*Util.Write("for ");
                            Util.WriteLine(items[decision - 1].Value() * ValueMultiplier + " G", ConsoleColor.DarkYellow);*/

                            Console.ReadKey();

                            if (items[decision - 1] is not Consumable)
                            {
                                player.ItemStash.Add(items[decision - 1]);
                            }
                            else
                            {
                                if (player.Consumables.Contains(items[decision - 1]))
                                {
                                    player.Consumables.Find(x => x == items[decision - 1]).Count += 1;
                                }
                                else
                                {
                                    player.Consumables.Add((Consumable)items[decision - 1]);
                                }
                            }
                        }
                    }
                }
            }
        }

        internal List<Item> Items { get => items; set => items = value; }
        public double ValueMultiplier { get => valueMultiplier; set => valueMultiplier = value; }
    }
}
