using System;
using System.Collections.Generic;

namespace VeganRPG
{
    class Merchant : NPC
    {
        public double ValueMultiplier { get; set; }

        public Merchant(string name, string helloMessage, string workMessage, string placeMessage, 
            List<Tuple<Quest, Quest>> quests, double valueMultipler, 
            Quest questToActivate = null, Quest placeQuest = null) : 
            base(name, helloMessage, workMessage, placeMessage, quests, questToActivate, placeQuest)
        {
            ValueMultiplier = valueMultipler;
        }

        public override void Work(Player player)
        {
            while (true)
            {
                WorkDisplayMenu();
                if (WorkHandleInput(player)) break;   
            }
        }

        private void WorkDisplayMenu()
        {
            Console.Clear();

            Util.WriteColorString(WorkMessage);
            Util.WriteColorString("@15|1. Sell @8|items\n");
            Util.WriteColorString("@15|2. Sell @14|consumables\n");

            Util.WriteLine("\n0. Exit");
        }

        private bool WorkHandleInput(Player player)
        {
            var decision = Util.KeyboardKeyToInt(Console.ReadKey());

            if (decision == 0) return true;
            else if (decision == 1) SellItems(player);
            else if (decision == 2) SellConsumables(player);

            return false;
        }

        private void SellItems(Player player)
        {
            if (player.ItemStash.Count == 0)
            {
                SellItemsDisplayNothingToSell();
                return;
            }

            int site = 0;
            int maxSite;

            while (true)
            {
                maxSite = (player.ItemStash.Count - 1) / 7;
                if (site > maxSite)
                    site = maxSite;

                SellItemsDisplayMenu(player, site, maxSite);
                if (SellItemsHandleInput(player, ref site, maxSite)) break;
            }
        }

        private void SellItemsDisplayNothingToSell()
        {
            Console.Clear();

            Util.WriteLine("You don't have anything to sell.");

            Console.ReadKey();
        }

        private void SellItemsDisplayMenu(Player player, int site, int maxSite)
        {
            Console.Clear();

            player.OrderItemStashList();

            Util.WriteColorString("@6|Gold@15|: @6|" + player.Gold + "\n\n");
            Util.WriteColorString("@8|Item @15|stash: " + (site + 1) + " / " + (maxSite + 1) + "\n");

            for (int i = 0; i < 7; ++i)
            {
                if (player.ItemStash.Count <= i + (site * 7))
                    break;

                Util.Write(i + 1 + ". ");
                player.ItemStash[i + (site * 7)].Info(false);
                Util.Write(" - ");

                Util.WriteColorString("@6|" + Convert.ToInt32((player.ItemStash[i + (site * 7)].Value() *
                    ValueMultiplier)) + "G\n");
            }

            if (site > 0) Util.WriteLine("8. Previous site");
            if (site < maxSite) Util.WriteLine("9. Next site");
            Util.WriteLine("\n0. Exit");
        }

        private bool SellItemsHandleInput(Player player, ref int site, int maxSite)
        {
            int decision = Util.KeyboardKeyToInt(Console.ReadKey());

            if (decision == 0)                          return true;
            else if (site > 0 && decision == 8)         site -= 1;
            else if (site < maxSite && decision == 9)   site += 1;
            else if (decision > 0 && decision < 8)      SellItemsHandleTransaction(player, decision, site);

            return false;
        }

        private void SellItemsHandleTransaction(Player player, int decision, int site)
        {
            if (decision + (site * 7) < player.ItemStash.Count + 1)
            {
                player.Gold += Convert.ToInt32(player.ItemStash[decision - 1 + (site * 7)].Value() * ValueMultiplier);

                Util.WriteColorString("@15|\nYou sold @8|" + player.ItemStash[decision - 1 + (site * 7)].Name +
                                      " for @6|" + Convert.ToInt32(
                                      player.ItemStash[decision - 1 + (site * 7)].Value() * ValueMultiplier) + " G\n");

                Console.ReadKey();

                player.ItemStash.RemoveAt(decision - 1 + (site * 7));
            }
        }

        private void SellConsumables(Player player)
        {
            if (player.Consumables.Count == 0)
            {
                SellItemsDisplayNothingToSell();
                return;
            }

            int site = 0;
            int maxSite;

            while (true)
            {
                maxSite = (player.Consumables.Count - 1) / 7;
                if (site > maxSite)
                {
                    site = maxSite;
                }


                SellConsumablesDisplayMenu(player, site, maxSite);
                if (SellConsumablesHandleInput(player, ref site, maxSite)) break;
            }
        }

        private void SellConsumablesDisplayMenu(Player player, int site, int maxSite)
        {
            Console.Clear();

            player.OrderConsumablesList();

            Util.Write("Gold", ConsoleColor.DarkYellow);
            Util.Write(": ");
            Util.WriteLine(player.Gold + "\n", ConsoleColor.DarkYellow);

            Util.Write("Consumables", ConsoleColor.Yellow);
            Util.WriteLine(": " + (site + 1) + " / " + (maxSite + 1));
            for (int i = 0; i < 7; ++i)
            {
                if (player.Consumables.Count <= i + (site * 7)) break;

                Util.Write(i + 1 + " ");
                player.Consumables[i + (site * 7)].Info(false);
                Util.Write(" - " + player.Consumables[i].Count + ", ");
                Util.Write(Convert.ToInt32(player.Consumables[i + (site * 7)].Value() * ValueMultiplier)
                    + "G\n", ConsoleColor.DarkYellow);
            }

            if (site > 0)       Util.WriteLine("8. Previous site");
            if (site < maxSite) Util.WriteLine("9. Next site");
            Util.WriteLine("\n0. Exit");
        }

        private bool SellConsumablesHandleInput(Player player, ref int site, int maxSite)
        {
            int decision = Util.KeyboardKeyToInt(Console.ReadKey());

            if (decision == 0)                          return true;
            else if (site > 0 && decision == 8)         site -= 1;
            else if (site < maxSite && decision == 9)   site += 1;
            else if (decision > 0 && decision < 8)      SellConsumablesHandleTransaction(player, decision, site);

            return false;
        }

        private void SellConsumablesHandleTransaction(Player player, int decision, int site)
        {
            if (decision + (site * 7) < player.Consumables.Count + 1)
            {
                player.Gold += Convert.ToInt32(player.Consumables[decision - 1 + (site * 7)].Value() * ValueMultiplier);

                Util.Write("\nYou sold ");
                Util.Write(player.Consumables[decision - 1 + (site * 7)].Name);
                Util.Write(" for ");
                Util.WriteLine(Convert.ToInt32(player.Consumables[decision - 1 + (site * 7)].Value() * ValueMultiplier)
                    + " G", ConsoleColor.DarkYellow);

                Console.ReadKey();

                if (player.Consumables[decision - 1 + (site * 7)].Count == 1)   player.Consumables.RemoveAt(decision - 1 + (site * 7));
                else                                                            player.Consumables[decision - 1 + (site * 7)].Count -= 1;
            }
        } 
    }
}
