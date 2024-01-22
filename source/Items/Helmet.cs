namespace VeganRPG
{
    class Helmet : Item
    { 
        public Helmet() : base()
        {

        }

        public Helmet(int level, string name, int health, int defense, bool isBase = false)
        {
            Level = level;
            Name = name;
            Health = health;
            Defense = defense;
            IsBase = isBase;
        }
    }
}
