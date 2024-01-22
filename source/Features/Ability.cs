using System;

namespace VeganRPG
{
    class Ability
    {
        public int Level { get; set; }
        public int MaxLevel { get; set; }

        // Fight uses variable turns to manipulate in-place how many turns are left till ability effects stop
        // TurnsConst is variable that's needed to restore old value after fight
        public int Turns { get; set; }
        public int TurnsConst { get; set; }

        public int Cost { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
            
        internal AbilityEffects AbilityEffects;

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
            string info = "@11|" + Name + ", " + Cost + " Ap @15|- ";

            Util.WriteColorString(info);
  
            Util.WriteColorString(Description);
        }
    }
}
