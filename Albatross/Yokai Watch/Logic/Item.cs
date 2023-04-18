using System.Drawing;

namespace Albatross.Yokai_Watch.Logic
{
    public interface Item
    {
        string Name { get; set; }

        string Description { get; set; }

        uint ID { get; set; }

        int MaxQuantity { get; set; }

        bool CanBeBuy { get; set; }

        bool CanBeSell { get; set; }

        double SellPrize { get; set; }

        string ItemIcon { get; set; }
    }

    public class Equipment : Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public uint ID { get; set; }

        public int MaxQuantity { get; set; }

        public bool CanBeBuy { get; set; }

        public bool CanBeSell { get; set; }

        public double SellPrize { get; set; }

        public string ItemIcon { get; set; }

        public Effect Effect1;

        public Effect Effect2;

        public int[] Stat = new int[4];

        public int CharaConditionID;

        public Equipment()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Consumable : Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public uint ID { get; set; }

        public int MaxQuantity { get; set; }

        public bool CanBeBuy { get; set; }

        public bool CanBeSell { get; set; }

        public double SellPrize { get; set; }

        public string ItemIcon { get; set; }

        public uint Effect1ID;

        public uint Effect2ID;

        public Consumable()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class KeyItem : Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public uint ID { get; set; }

        public int MaxQuantity { get; set; }

        public bool CanBeBuy { get; set; }

        public bool CanBeSell { get; set; }

        public double SellPrize { get; set; }

        public string ItemIcon { get; set; }

        public KeyItem()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class CreatureItem : Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public uint ID { get; set; }

        public int MaxQuantity { get; set; }

        public bool CanBeBuy { get; set; }

        public bool CanBeSell { get; set; }

        public double SellPrize { get; set; }

        public string ItemIcon { get; set; }

        public CreatureItem()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class SoulItem : Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public uint ID { get; set; }

        public int MaxQuantity { get; set; }

        public bool CanBeBuy { get; set; }

        public bool CanBeSell { get; set; }

        public double SellPrize { get; set; }

        public string ItemIcon { get; set; }

        public SoulItem()
        {

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
