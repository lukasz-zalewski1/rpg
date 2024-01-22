using System;
using System.Collections.Generic;

namespace VeganRPG
{
    abstract class NPC
    {
        public string Name { get; set; }
       
        public string HelloMessage { get; set; }
        public string WorkMessage { get; set; }
        public string PlaceMessage { get; set; }

        internal List<Tuple<Quest, Quest>> Quests { get; set; }

        // Quest that finishes after talking with NPC about place
        internal Quest PlaceQuest { get; set; }
        // Quest that has to be finished, before NPC shows up
        internal Quest QuestToActivate { get; set; }


        public NPC(string name, string helloMessage, string workMessage, string placeMessage, List<Tuple<Quest, Quest>> quests,
            Quest questToActivate = null, Quest placeQuest = null)
        {
            Name = name;

            HelloMessage = helloMessage;
            WorkMessage = workMessage;
            PlaceMessage = placeMessage;

            Quests = quests;

            QuestToActivate = questToActivate;
            PlaceQuest = placeQuest;
        }

        public void Talk(Player player, List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            while (true)
            {
                TalkDisplayMenu();
                if (TalkHandleInput(player, activeQuests, enemyTracker)) break;         
            }
        }

        private void TalkDisplayMenu()
        {
            Console.Clear();

            Util.WriteColorString("@15|Hello, I'm @9|" + Name + "\n");

            Util.WriteLine("\nSay: ");
            Util.WriteLine("1. Hello");
            Util.WriteColorString("@15|2. Ask about his @6|work\n");
            Util.WriteColorString("@15|3. Ask about the @10|place\n");

            if (Quests.Count > 0)
            {
                Util.WriteColorString("@15|4. Ask if he has any @12|quest @15|for you\n");
                Util.WriteColorString("@15|5. Tell him about @12|quest @15|that you finished\n");
            }

            Util.WriteLine("\n0. Exit");
        }

        private bool TalkHandleInput(Player player, List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            var decision = Util.KeyboardKeyToInt(Console.ReadKey());

            if (decision == 0)                          return true;
            else if (decision == 1)                     Hello();
            else if (decision == 2)                     Work(player);
            else if (decision == 3)                     Place(player, activeQuests, enemyTracker);
            else if (decision == 4 && Quests.Count > 0) GiveQuests(player, activeQuests, enemyTracker);
            else if (decision == 5 && Quests.Count > 0) FinishQuests(player, activeQuests, enemyTracker);

            return false;
        }

        public void Hello()
        {
            Console.Clear();

            Util.WriteColorString(HelloMessage);

            Console.ReadKey();
        }

        public abstract void Work(Player player);

        public void Place(Player player, List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            Console.Clear();

            FinishPlaceQuest(player, activeQuests, enemyTracker);

            Util.WriteColorString(PlaceMessage);

            Console.ReadKey();
        }

        private void FinishPlaceQuest(Player player, List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            if (PlaceQuest != null && activeQuests.Find(x => x == PlaceQuest) != null)
            {
                PlaceQuest.Finish(player, enemyTracker);
                activeQuests.Remove(PlaceQuest);

                Console.Clear();
            }
        }

        private void GiveQuests(Player player, List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            Console.Clear();

            bool anyQuestGiven = false;

            foreach (var quest in Quests)
            {
                if (player.QuestsDone.Find(x => x == quest.Item1) == null && activeQuests.Find(x => x == quest.Item1) == null)
                {
                    if (quest.Item2 == null || player.QuestsDone.Find(x => x == quest.Item2) != null)
                    {
                        quest.Item1.Start(activeQuests, enemyTracker);
                        quest.Item1.Info(player, enemyTracker);

                        Util.Write("\n\n");

                        anyQuestGiven = true;
                    }
                }
            }

            if (!anyQuestGiven)
            {
                Util.WriteColorString("@15|I don't have any @12|quest @15|for you\n");
            }

            Console.ReadKey();
        }

        private void FinishQuests(Player player, List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            Console.Clear();
            List<Quest> completedQuests = new List<Quest>();

            foreach (var quest in Quests)
            {
                if (!quest.Item1.OutsideFinish)
                {
                    if (activeQuests.Find(x => x == quest.Item1) != null)
                    {
                        if (quest.Item1.CheckCompletion(player, enemyTracker))
                        {
                            quest.Item1.Finish(player, enemyTracker);
                            activeQuests.Remove(quest.Item1);

                            completedQuests.Add(quest.Item1);

                            Console.Clear();
                        }
                        else
                        {
                            quest.Item1.Info(player, enemyTracker);

                            Util.Write("\n");
                        }
                    }
                }
            }

            if (completedQuests.Count == 0)
            {
                Util.WriteColorString("@15|You didn't complete any @12|quest\n");

                Console.ReadKey();
            }
            else
            {
                foreach (var quest in completedQuests)
                {
                    Quests.RemoveAll(x => x.Item1 == quest);
                }
            }      
        }
    }
}
