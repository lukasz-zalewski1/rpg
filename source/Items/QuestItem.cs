namespace VeganRPG
{
    class QuestItem : Item
    {
        public int Count { get; set; }

        public QuestItem(string name)
        {
            Name = name;

            Count = 1;
        }

        public override void Info(bool newLine = true)
        {
            if (!newLine)   Util.WriteColorString("@12|" + Name);
            else            Util.WriteColorString("@12|" + Name + "\n");
        }

        public override int Value()
        {
            return 0;
        }     
    }
}
