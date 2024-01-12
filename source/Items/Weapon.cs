using System;
using System.Collections.Generic;
using System.Text;

namespace VeganRPG
{
    class Weapon : Item
    {
        public Weapon() : base()
        {

        }
        public Weapon(int level, string name, Tuple<int, int> damage, bool isBase = false)
        {
            this.Level = level;
            this.Name = name;
            this.Damage = damage;
            this.IsBase = isBase;
        }

        public override void Info(bool newLine = true)
        {
            Util.WriteColorString("@8|" + Name + " @4|Level " + Level + " @13|Damage " +
                                  Damage.Item1 + "@15| - ");

            /*Util.Write(Name + " ", ConsoleColor.DarkGray);
            Util.Write("Level " + Level + " ", ConsoleColor.DarkRed);
            Util.Write("Damage " + Damage.Item1, ConsoleColor.Magenta);
            Util.Write(" - ");*/

            if (!newLine)
            {
                Util.WriteColorString("@13|" + Damage.Item2);

                /*Util.Write(Damage.Item2 + "", ConsoleColor.Magenta);*/
            }
            else
            {
                Util.WriteColorString("@13|" + Damage.Item2 + "\n");

                /*Util.WriteLine(Damage.Item2 + "", ConsoleColor.Magenta);*/
            }
        }
    }
}
