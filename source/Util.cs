using System;
using System.Collections.Generic;
using System.Linq;

// List of colors to use:
// 2 DARKGREEN - Stats, Areas
// 4 DARKRED - Save, Load, Experience, Level
// 5 DARKMAGENTA - Defense
// 6 DARKYELLOW - Gold
// 8 DARKGRAY - Items
// 9 BLUE - NPC, Enemy
// 10 GREEN - Cities
// 11 CYAN - Abilities, AP
// 12 RED - Quest, Health
// 13 MAGENTA - Damage
// 14 YELLOW - Consumables
// 15 WHITE - Text

namespace VeganRPG
{
    class Util
    { 
        /// <summary>
        /// Writes text in a given color.
        /// </summary>
        public static void Write(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            Console.Write(text);

            Console.ResetColor();
        }

        /// <summary>
        /// Writes line of text in a given color.
        /// </summary>
        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(text);

            Console.ResetColor();
        }

        /// <summary>
        /// Writes a text where every letter has a different color.
        /// </summary>
        public static void WriteMulticolor(string text)
        {
            ConsoleColor color;
            for (int i = 0; i < text.Length; ++i)
            {
                if ((i % 16) != 0)
                color = (ConsoleColor)(i % 16);
                else
                {
                    color = (ConsoleColor)((i + 1) % 16);
                }

                Util.Write(text[i].ToString(), color);
            }
        }

        /// <summary>
        /// Writes a color text.
        /// Text has to properly formatted before passing to the function.
        /// Add @COLOR_NUMBER| to colorize a text.
        /// Text must start with a color.
        /// </summary>
        /// <param name="text">Formatted string</param>

        public static void WriteColorString(string text)
        {
            List<Tuple<string, int>> coloredStringList = new List<Tuple<string, int>>();
            List<string> stringList;

            if (!text.Contains('@'))
            Write(text);
            else
            {
                stringList = text.Split('@').ToList();
                stringList.RemoveAll(x => x == "");

                string colorString;
                string coloredString;

                foreach (var str in stringList)
                {
                    colorString = str[..str.IndexOf('|')];
                    coloredString = str.Substring(str.IndexOf('|') + 1, str.Length - colorString.Length - 1);

                    coloredStringList.Add(new Tuple<string, int>(coloredString, Convert.ToInt32(colorString)));
                }

                foreach (var str in coloredStringList)
                {
                    if (str.Item2 == 15)
                        Write(str.Item1);
                    else
                        Write(str.Item1, (ConsoleColor)str.Item2);
                }
            }
        }

        public static int KeyboardKeyToInt(ConsoleKeyInfo key)
        {
            return key.Key switch
            {
                ConsoleKey.NumPad0 => 0,
                ConsoleKey.NumPad1 => 1,
                ConsoleKey.NumPad2 => 2,
                ConsoleKey.NumPad3 => 3,
                ConsoleKey.NumPad4 => 4,
                ConsoleKey.NumPad5 => 5,
                ConsoleKey.NumPad6 => 6,
                ConsoleKey.NumPad7 => 7,
                ConsoleKey.NumPad8 => 8,
                ConsoleKey.NumPad9 => 9,
                ConsoleKey.D0 => 0,
                ConsoleKey.D1 => 1,
                ConsoleKey.D2 => 2,
                ConsoleKey.D3 => 3,
                ConsoleKey.D4 => 4,
                ConsoleKey.D5 => 5,
                ConsoleKey.D6 => 6,
                ConsoleKey.D7 => 7,
                ConsoleKey.D8 => 8,
                ConsoleKey.D9 => 9,
                ConsoleKey.E => -2,
                _ => -1
            };
        }
    }
}
