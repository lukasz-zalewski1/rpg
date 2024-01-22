using System;

namespace VeganRPG
{
    class Weapon : Item
    {
        public Weapon() : base()
        {

        }

        public Weapon(int level, string name, Tuple<int, int> damage, bool isBase = false)
        {
            Level = level;
            Name = name;
            Damage = damage;
            IsBase = isBase;
        }

        public override void Info(bool newLine = true)
        {
            Util.WriteColorString("@8|" + Name + " @4|Level " + Level + " @13|Damage " +
                                  Damage.Item1 + "@15| - ");

            if (!newLine)   Util.WriteColorString("@13|" + Damage.Item2);
            else            Util.WriteColorString("@13|" + Damage.Item2 + "\n");
        }
    }
}
