using System.Collections.Generic;
using System.Linq;
using System;

namespace VeganRPG
{
    public partial class Game
    {
        int Consume(int lastSite = 0)
        {
            player.OrderConsumablesList();

            if (player.Consumables.Count == 0)
            {
                DisplayNoConsumableInfo();

                return -1;
            }

            int site = lastSite;
            int maxSite;

            while (true)
            {
                maxSite = (player.Consumables.Count - 1) / 7;
                if (site > maxSite)
                {
                    site = maxSite;
                }

                DisplayConsumeMenu(site, maxSite);

                int decision = Util.KeyboardKeyToInt(Console.ReadKey());

                Console.Clear();

                if (decision == 0) break;
                else if (site > 0 && decision == 8) site -= 1;
                else if (site < maxSite && decision == 9) site += 1;
                else if (decision > 0 && decision < 8)
                {
                    var result = TryConsumeConsumable(decision, site);
                    if (result == -2) continue;
                    else if (result == -1) break;
                    else return result;
                }
            }

            return -1;
        }

        void DisplayNoConsumableInfo()
        {
            Console.Clear();

            Util.WriteColorString("@15|You don't have anything to @14|consume\n");

            Console.ReadKey();
        }

        void DisplayConsumeMenu(int site, int maxSite)
        {
            Console.Clear();

            DisplayConsumeMenuPlayerStats(site, maxSite);

            for (int i = 0; i < 7; ++i)
            {
                if (player.Consumables.Count <= i + (site * 7))
                    break;

                Util.Write(i + 1 + ". ");
                player.Consumables[i + (site * 7)].Info(false);
                Util.Write(" - " + player.Consumables[i + (site * 7)].Count + "\n");
            }

            if (site > 0) Util.WriteLine("8. Previous site");
            if (site < maxSite) Util.WriteLine("9. Next site");
            Util.WriteLine("\n0. Exit");
        }

        void DisplayConsumeMenuPlayerStats(int site, int maxSite)
        {
            Util.WriteLine("You");
            Util.WriteColorString("@4|Level@15|: @4|" + player.Level + "\n");
            Util.WriteColorString("@12|Health@15|: @12|" + player.Health + "@15| / @12|" +
                                  player.MaxHealth + "\n");
            Util.WriteColorString("@11|Ability points@15|: @11|" + player.Ap + "@15| / @11|" +
                                  (player.Level * player.ApPerLevel) + "\n\n");
            Util.WriteColorString("@14|Consumables@15|: " + (site + 1) + " / " + (maxSite + 1) + "\n");
        }

        int TryConsumeConsumable(int decision, int site)
        {
            if (decision + (site * 7) < player.Consumables.Count + 1)
            {
                if (player.Level < player.Consumables[decision - 1 + (site * 7)].Level)
                {
                    DisplayPlayerLevelTooLowToConsumeInfo();
                }
                else
                {
                    return FinallyConsumeConsumable(decision, site);
                }
            }

            return -2;
        }

        void DisplayPlayerLevelTooLowToConsumeInfo()
        {
            Util.WriteColorString("@15|Your @4|level @15|is too low to @14|consume @15|this\n");

            Console.ReadKey();
        }

        void RemoveConsumedConsumableFromInventory(int decision, int site)
        {
            if (player.Consumables[decision - 1 + (site * 7)].Count == 1)
                player.Consumables.Remove(player.Consumables[decision - 1 + (site * 7)]);
            else
                player.Consumables[decision - 1 + (site * 7)].Count -= 1;
        }

        int FinallyConsumeConsumable(int decision, int site)
        {
            int addedHealth = 0;
            int addedAp = 0;

            CalculateConsumeGain(ref addedHealth, ref addedAp, decision, site);

            if (addedHealth == 0 && addedAp == 0)
            {
                DisplayNoConsumeNeededInfo();

                return -1;
            }
            else AddConsumeGainToPlayer(addedHealth, addedAp);

            DisplayConsumeGainInfo(addedHealth, addedAp, decision, site);
            RemoveConsumedConsumableFromInventory(decision, site);

            return site;
        }

        void CalculateConsumeGain(ref int addedHealth, ref int addedAp, int decision, int site)
        {
            if (player.Health + player.Consumables[decision - 1 + (site * 7)].Health > player.MaxHealth)
                addedHealth = player.MaxHealth - player.Health;
            else
                addedHealth = player.Consumables[decision - 1 + (site * 7)].Health;

            if (player.Ap + player.Consumables[decision - 1 + (site * 7)].Ap > player.Level * player.ApPerLevel)
                addedAp = (player.Level * player.ApPerLevel) - player.Ap;
            else
                addedAp = player.Consumables[decision - 1 + (site * 7)].Ap;
        }

        void DisplayNoConsumeNeededInfo()
        {
            Util.WriteColorString("@15|You don't need to @14|consume anything\n");

            Console.ReadKey();
        }

        void AddConsumeGainToPlayer(int addedHealth, int addedAp)
        {
            player.Health += addedHealth;
            player.Ap += addedAp;
        }

        void DisplayConsumeGainInfo(int addedHealth, int addedAp, int decision, int site)
        {
            Util.WriteColorString("@15|You consumed @14|" + player.Consumables[decision - 1 + (site * 7)].Name + "\n");

            if (addedHealth > 0) Util.WriteColorString("@15|You restored @12|" + addedHealth + " Health\n");
            if (addedAp > 0) Util.WriteColorString("@15|You restored @11|" + addedAp + " AP\n");

            Console.ReadKey();
        }

        void AutoConsume()
        {
            List<Consumable> possibleConsumables = player.Consumables.Where(y => y.Health > 0).Where(z => player.Level >= z.Level).
                OrderByDescending(x => x.OnlyHpValue).ToList();

            int itemsConsumed = 0;
            int healthAtStart = player.Health;
            int apAtStart = player.Ap;

            if (possibleConsumables.Count == 0)
            {
                DisplayNoConsumableInfo();

                return;
            }

            if (player.Health == player.MaxHealth && player.Ap == player.Level * player.ApPerLevel)
            {
                Console.Clear();

                DisplayNoConsumeNeededInfo();

                return;
            }

            ConsumeUntilFull(possibleConsumables, ref itemsConsumed);

            DisplayAutoConsumedInfo(itemsConsumed, healthAtStart, apAtStart);
        }

        private void ConsumeUntilFull(List<Consumable> possibleConsumables, ref int itemsConsumed)
        {
            int consumableIndex = 0;

            while (consumableIndex < possibleConsumables.Count && player.Health < player.MaxHealth)
            {
                if (possibleConsumables[consumableIndex].Count > 0) possibleConsumables[consumableIndex].Count -= 1;
                else
                {
                    consumableIndex += 1;
                    continue;
                }

                if (player.Health + possibleConsumables[consumableIndex].Health > player.MaxHealth)
                    player.Health = player.MaxHealth;
                else
                    player.Health += possibleConsumables[consumableIndex].Health;

                if (player.Ap + possibleConsumables[consumableIndex].Ap > player.Level * player.ApPerLevel)
                    player.Ap = player.Level * player.ApPerLevel;
                else
                    player.Ap += possibleConsumables[consumableIndex].Ap;

                itemsConsumed += 1;
            }

            RemoveAutoConsumedConsumables(possibleConsumables);
        }

        private void RemoveAutoConsumedConsumables(List<Consumable> possibleConsumables)
        {
            foreach (var consumable in possibleConsumables)
            {
                if (consumable.Count == 0) player.Consumables.RemoveAll(x => x == consumable);
                else player.Consumables.Find(x => x == consumable).Count = consumable.Count;
            }
        }

        private void DisplayAutoConsumedInfo(int itemsConsumed, int healthAtStart, int apAtStart)
        {
            Console.Clear();
            Util.WriteColorString("@14|Consumed " + itemsConsumed + " @15|items\n");
            Util.WriteColorString("@15|Restored @12|" + (player.Health - healthAtStart) + " health @15|" +
                                  "and @11|" + (player.Ap - apAtStart) + " ability points\n");

            Console.ReadKey();
        }
    }
}
