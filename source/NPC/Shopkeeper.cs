using System;
using System.Collections.Generic;
using System.Linq;

namespace VeganRPG
{
    class Shopkeeper : NPC
    {
        internal List<Item> Items {  get; set; }
        public double ValueMultiplier { get; set; }

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
                WorkDisplayMenu();
                if (WorkHandleInput(player)) break;        
            }
        }

        private void WorkDisplayMenu()
        {
            Console.Clear();

            Util.WriteColorString(WorkMessage);

            Util.WriteLine("1. Buy");
            Util.WriteLine("\n0. Exit");
        }

        private bool WorkHandleInput(Player player)
        {
            var decision = Util.KeyboardKeyToInt(Console.ReadKey());

            if (decision == 0)      return true;
            else if (decision == 1) BuyItems(player);

            return false;
        }

        void BuyItems(Player player)
        {
            while (true)
            {
                BuyItemsDisplayMenu(player);
                if (BuyItemsHandleInput(player)) break;         
            }
        }

        private void BuyItemsDisplayMenu(Player player)
        {
            Console.Clear();

            Util.WriteColorString("@4|Level@15|: @4|" + player.Level + "\n");
            Util.WriteColorString("@6|Gold@15|: @6|" + player.Gold + "\n");
            Util.WriteLine("Things to buy: ");

            for (int i = 0; i < Items.Count; ++i)
            {
                Util.Write(i + 1 + ". ");
                Items[i].Info(false);

                Util.WriteColorString("@15| - @6|" + (Items[i].Value() * ValueMultiplier) + "G\n");
            }

            Util.WriteLine("\n0. Exit");
        }

        private bool BuyItemsHandleInput(Player player)
        {
            int decision = Util.KeyboardKeyToInt(Console.ReadKey());

            Console.Clear();

            if (decision == 0) return true;
            else if (decision > 0) BuyItemsHandleTransaction(player, decision);

            return false;
        }

        private void BuyItemsHandleTransaction(Player player, int decision)
        {
            if (decision < Items.Count + 1)
            {
                if (player.Gold < Items[decision - 1].Value() * ValueMultiplier)
                    BuyItemsDisplayNoMoneyForItemInfo(decision);   
                else if (decision > 0) 
                    BuyItemsFinishTransaction(player, decision);
            }
        }

        private void BuyItemsFinishTransaction(Player player, int decision)
        {
            player.Gold -= Convert.ToInt32(Items[decision - 1].Value() * ValueMultiplier);

            BuyItemsFinishTransactionDisplayInfo(decision);
            BuyItemsAddItemToInventory(player, decision);     
        }

        void BuyItemsDisplayNoMoneyForItemInfo(int decision)
        {
            Util.WriteColorString("@15|You don't have enough @6|gold @15|to buy ");

            if (Items[decision - 1] is Consumable)  Util.WriteColorString("@6|" + Items[decision - 1].Name + "\n");
            else                                    Util.WriteColorString("@8|" + Items[decision - 1].Name + "\n");

            Console.ReadKey();
        }

        void BuyItemsFinishTransactionDisplayInfo(int decision)
        {
            Util.Write("You bought ");
            if (Items[decision - 1] is Consumable) Util.WriteColorString("@6|" + Items[decision - 1].Name + " ");
            else Util.WriteColorString("@8|" + Items[decision - 1].Name + " ");

            Util.WriteColorString("@15|for @6|" + Items[decision - 1].Value() * ValueMultiplier + " G\n");

            Console.ReadKey();
        }

        void BuyItemsAddItemToInventory(Player player, int decision)
        {
            if (Items[decision - 1] is not Consumable) player.ItemStash.Add(Items[decision - 1]);
            else
            {
                if (player.Consumables.Contains(Items[decision - 1]))
                    player.Consumables.Find(x => x == Items[decision - 1]).Count += 1;
                else
                    player.Consumables.Add((Consumable)Items[decision - 1]);
            }
        }
    }
}
