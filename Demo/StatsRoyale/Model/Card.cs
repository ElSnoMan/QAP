using StatsRoyale.Constant;

namespace StatsRoyale.Model
{
    public class Card
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int ElixirCost { get; set; }

        public string Category { get; set; }

        public string Arena { get; set; }

        public Rarity Rarity { get; set; }

        public int CardLevel { get; set; }
    }
}
