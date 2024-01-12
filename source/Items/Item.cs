using System;
using System.Collections.Generic;
using System.Text;

namespace VeganRPG
{
    abstract class Item
    {
        string name;
        int health;
        Tuple<int, int> damage;
        int defense;

        int level;

        // Base items disappear after beign replaced
        bool isBase;

        public Item()
        {
            Name = "";
            Health = 0;
            Damage = new Tuple<int, int>(0, 0);
            Defense = 0;

            Level = 0;

            isBase = false;
        }

        public virtual int Value()
        {
            return Health + (Damage.Item1 + Damage.Item2) * 4 + Defense * 4;
        }

        public virtual void Info(bool newLine = true)
        {
            Util.WriteColorString("@8|" + Name + " @4|Level " + Level + " " +
                                  "@12|Health " + Health);

            /*Util.Write(Name + " ", ConsoleColor.DarkGray);
            Util.Write("Level " + Level + " ", ConsoleColor.DarkRed);
            Util.Write("Health " + Health + " ", ConsoleColor.Red);*/

            if (!newLine)
            {
                Util.WriteColorString("@5|Defense " + Defense);

                /*Util.Write("Defense " + Defense, ConsoleColor.DarkMagenta);*/
            }
            else
            {
                Util.WriteColorString("@5|Defense " + Defense + "\n");

                /*Util.WriteLine("Defense " + Defense, ConsoleColor.DarkMagenta);*/
            }
        }

        public string Name { get => name; set => name = value; }
        public int Health { get => health; set => health = value; }
        public Tuple<int, int> Damage { get => damage; set => damage = value; }
        public int Defense { get => defense; set => defense = value; }
        public bool IsBase { get => isBase; set => isBase = value; }
        public int Level { get => level; set => level = value; }
    }
}
