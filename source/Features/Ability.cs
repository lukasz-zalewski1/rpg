using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace VeganRPG
{
    class Ability
    {
        string name;
        string description;

        int level;
        int maxLevel;

        // Fight uses variable turns to manipulate in-place how many turns are left till ability effects stop
        // TurnsConst is variable that's needed to restore old value after fight
        int turns;
        int turnsConst;

        int cost;

        AbilityEffects abilityEffects;

        
        /// <summary>
        /// Constructs Ability object
        /// </summary>
        /// <param name="name">Name of ability</param>
        /// <param name="description">Description of ability</param>
        /// <param name="level">Level needed to unlock ability</param>
        /// <param name="maxLevel">Maximum level that you can use ability on</param>
        /// <param name="turns">For how many turns ability works</param>
        /// <param name="cost">Ability points cost</param>
        /// <param name="abilityEffects">Ability effects</param>
        public Ability(string name, string description, int level, int maxLevel, int turns, int cost, AbilityEffects abilityEffects)
        {
            Name = name;
            Description = description;

            Level = level;
            MaxLevel = maxLevel;
            Turns = turns;
            TurnsConst = turns;
            Cost = cost;

            AbilityEffects = abilityEffects;
        }

        
        /// <summary>
        /// Adds every effect of ability to effects combined, it sums 
        /// all effects and stores all of them in reference named <paramref name="effectsCombined"/>
        /// </summary>
        /// <param name="effectsCombined">Combined ability effects</param>
        public void Use(ref AbilityEffects effectsCombined)
        {
            var properties = effectsCombined.GetType().GetProperties();

            foreach (var prop in properties)
            {
                prop.SetValue(effectsCombined, Convert.ToDouble(prop.GetValue(effectsCombined))
                    + Convert.ToDouble(prop.GetValue(AbilityEffects)));
            }
        }

        public void Stop(ref AbilityEffects effectsCombined)
        {
            var properties = effectsCombined.GetType().GetProperties();

            foreach (var prop in properties)
            {
                prop.SetValue(effectsCombined, Convert.ToDouble(prop.GetValue(effectsCombined))
                    - Convert.ToDouble(prop.GetValue(AbilityEffects)));
            }
        }

        public virtual void Info()
        {
            string info = "@11|" + Cost + " " + Name + " @15|- ";

            Util.WriteColorString(info);
  
            Util.WriteColorString(description);
        }

        public int Level { get => level; set => level = value; }
        public int Turns { get => turns; set => turns = value; }
        public int Cost { get => cost; set => cost = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int MaxLevel { get => maxLevel; set => maxLevel = value; }
        public int TurnsConst { get => turnsConst; set => turnsConst = value; }
        internal AbilityEffects AbilityEffects { get => abilityEffects; set => abilityEffects = value; }
    }
}
