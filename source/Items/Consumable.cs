namespace VeganRPG
{
    class Consumable : Item
    {
        public int Count { get; set; }
        public int Ap { get; set; }

        public int OnlyHpValue { get => Health - (Ap * 10); }

        public Consumable() : base()
        {
            Count = 1;
        }

        public Consumable(int level, string name, int health, int ap)
        {
            Level = level;
            Name = name;
            Health = health;
            Ap = ap;
            Count = 1;
        }

        public override int Value()
        {
            return (Health / 10) + Ap;
        }

        public override void Info(bool newLine = true)
        {
            Util.WriteColorString("@14|" + Name + " @4|Level " + Level + " @12|Health " + Health + " ");

            if (!newLine) Util.WriteColorString("@11|Ability points " + Ap);
            else Util.WriteColorString("@11|Ability points " + Ap + "\n");
        }
    }
}
