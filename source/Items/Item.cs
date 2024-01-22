using System;

namespace VeganRPG
{
    abstract class Item
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Tuple<int, int> Damage { get; set; }
        public int Defense { get; set; }

        // Base items disappear after being replaced
        public bool IsBase { get; set; }
        public int Level { get; set; }


        public Item()
        {
            Name = "";
            Health = 0;
            Damage = new Tuple<int, int>(0, 0);
            Defense = 0;

            Level = 0;

            IsBase = false;
        }

        public virtual int Value()
        {
            return Health + (Damage.Item1 + Damage.Item2) * 4 + Defense * 4;
        }

        public virtual void Info(bool newLine = true)
        {
            Util.WriteColorString("@8|" + Name + " @4|Level " + Level + " " +
                                  "@12|Health " + Health + " ");

            if (!newLine)   Util.WriteColorString("@5|Defense " + Defense);
            else            Util.WriteColorString("@5|Defense " + Defense + "\n");
        } 
    }
}
