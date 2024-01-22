using System;
using System.Collections.Generic;
using System.Linq;

namespace VeganRPG
{
    class City
    {
        internal List<NPC> Npcs { get; set; }
        public string Name { get; set; }

        // Tuple with Area and Quest that enables it
        internal List<Tuple<Area, Quest>> Areas{ get; set; }
        // Tuple with Area and Quest during which Area is enabled
        internal List<Tuple<Area, Quest>> TemporaryAreas{ get; set; }

        internal Quest StartingQuest{ get; set; }
        internal Quest EndQuest{ get; set; }
        internal City NextCity{ get; set; }


        public City(string name, Quest startingQuest, Quest endQuest, City nextCity, 
            List<NPC> npcs, List<Tuple<Area, Quest>> areas,
            List<Tuple<Area, Quest>> temporaryAreas)
        {
            Name = name;

            StartingQuest = startingQuest;
            EndQuest = endQuest;
            NextCity = nextCity;

            Npcs = npcs;
            Areas = areas;
            TemporaryAreas = temporaryAreas;
        }

        public void People(Player player, List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            CheckForStartingQuest(player, activeQuests, enemyTracker); 

            while (true)
            {
                PeopleDisplayMenu(player);
                if (PeopleHandleInput(player, activeQuests, enemyTracker)) break;           
            }
        }

        private void CheckForStartingQuest(Player player, List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            if (player.QuestsDone.Find(x => x == StartingQuest) == null && activeQuests.Find(x => x == StartingQuest) == null)
            {
                Console.Clear();

                StartingQuest.Start(activeQuests, enemyTracker);

                Console.ReadKey();
            }
        }

        private void PeopleDisplayMenu(Player player)
        {
            Console.Clear();

            Util.WriteLine("You see: ");

            for (int i = 0; i < Npcs.Count; ++i)
            {
                if (Npcs[i].QuestToActivate == null || player.QuestsDone.Find(x => x == Npcs[i].QuestToActivate) != null)
                    Util.WriteColorString("@15|" + (i + 1) + ". @2|" + Npcs[i].Name + "\n");
            }

            Util.WriteLine("\n0. Exit");
        }

        private bool PeopleHandleInput(Player player, List<Quest> activeQuests, List<Tuple<Enemy, int>> enemyTracker)
        {
            var decision = Util.KeyboardKeyToInt(Console.ReadKey());

            if (decision == 0) return true;
            if (decision > 0 && decision - 1 < Npcs.Count)
            {
                if (Npcs[decision - 1].QuestToActivate == null || player.QuestsDone.Find(x => x == Npcs[decision - 1].QuestToActivate) != null)
                    Npcs[decision - 1].Talk(player, activeQuests, enemyTracker);
            }

            return false;
        }

#pragma warning disable CS8632
        public Enemy? Outside(Player player, List<Quest> activeQuests)
#pragma warning restore CS8632
        {
            Enemy enemy = null;

            while (true)
            {
                Console.Clear();

                List<Tuple<Area, Quest>> possibleAreas = Areas.Where(x => player.QuestsDone.Find(y => y == x.Item2) != null).ToList();
                
                OutsideCheckPossibleTemporaryAreas(activeQuests, possibleAreas);
                
                if (possibleAreas.Count > 0)
                {
                    OutsideDisplayMenu(possibleAreas);
                    var result = OutsideHandleInput(possibleAreas, ref enemy);
                    if (result == 1) break;
                    else if (result == -1) continue;
                    else return null;
                }
                else
                {
                    Util.WriteLine("You can't go anywhere");
                    Console.ReadKey();

                    break;
                }
            }

            return enemy;
        }    

        private void OutsideCheckPossibleTemporaryAreas(List<Quest> activeQuests, List<Tuple<Area, Quest>> possibleAreas)
        {
            foreach (var area in TemporaryAreas)
            {
                if (activeQuests.Contains(area.Item2)) possibleAreas.Add(area);
            }
        }

        private void OutsideDisplayMenu(List<Tuple<Area, Quest>> possibleAreas)
        {
            Util.WriteLine("Go to: ");

            for (int i = 0; i < possibleAreas.Count; ++i)
            {
                Util.WriteColorString("@15|" + (i + 1) + ". @2|" + possibleAreas[i].Item1.Name + "\n");
            }

            Util.WriteLine("\n0. Exit");
        }

        private int OutsideHandleInput(List<Tuple<Area, Quest>> possibleAreas, ref Enemy enemy)
        {
            while (true)
            {
                int decision = Util.KeyboardKeyToInt(Console.ReadKey());

                if (decision > 0 && decision - 1 < possibleAreas.Count)
                {
                    enemy = possibleAreas[decision - 1].Item1.LookForEnemy();

                    Console.Clear();

                    Util.WriteColorString("@15|You met @9|" + enemy.Name + "\n");

                    Console.ReadKey();

                    return 1;
                }
                else if (decision == 0) return 0;
                else return -1;
            }
        }
    }
}
