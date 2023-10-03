using System;

namespace Currency
{
    // TODO: Whoever edit this please split this into multiple files.
    [Serializable]
    public class BaseCurrency
    {
        public string ID;
        public string Name;
        public string Description;
        public int Value;

        public BaseCurrency()
        {
            ID = "";
            Name = "";
            Value = 0;
        }

        public BaseCurrency(string id, string name, string description, int value)
        {
            ID = id;
            Name = name;
            Description = description;
            Value = value;
        }

        public int Add(int value)
        {
            Value += value;
            return Value;
        }

        public int Subtract(int value)
        {
            Value -= value;
            return Value;
        }

        public bool IsEnough(int value)
        {
            return Value >= value;
        }

        public override string ToString()
        {
            return $"{Name}: {Value}";
        }
    }

    public class Gold : BaseCurrency
    {
        public Gold()
        {
            ID = "gold";
            Name = "Gold";
            Description = "Gold is the main currency in the game.";
            Value = 0;
        }
    }

    public class Gem : BaseCurrency
    {
        public Gem()
        {
            ID = "gem";
            Name = "Gem";
            Description = "Gem is the premium currency in the game.";
            Value = 0;
        }
    }

    public class PaidGem : BaseCurrency
    {
        public PaidGem()
        {
            ID = "paid_gem";
            Name = "Paid Gem";
            Description = "Paid Gem is the premium currency in the game.";
            Value = 0;
        }
    }
}