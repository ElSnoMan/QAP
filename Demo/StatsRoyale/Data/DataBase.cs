using System.Collections.Generic;
using StatsRoyale.Constant;
using StatsRoyale.Model;

namespace StatsRoyale.Data
{
    public class DataBase
    {
        public List<Card> Cards;

        public DataBase()
        {
            Cards = new List<Card>
            {
                new Card
                {
                    Name = "Ice Spirit",
                    Description = "Spawns one lively little Ice Spirit to freeze a group of enemies. Stay frosty.",
                    ElixirCost = 1,
                    Category = "Troop",
                    Arena = "Arena 8",
                    Rarity = Rarity.Common,
                    CardLevel = 9
                },
                new Card
                {
                    Name = "Mirror",
                    Description = "Mirrors your last card played for +1 Elixir.",
                    ElixirCost = 1,
                    Category = "Spell",
                    Arena = "Arena 11",
                    Rarity = Rarity.Epic,
                    CardLevel = 4
                },
                new Card
                {
                    Name = "Elixir Collector",
                    Description = "You gotta spend Elixir to make Elixir.",
                    ElixirCost = 6,
                    Category = "Building",
                    Arena = "Arena 8",
                    Rarity = Rarity.Rare,
                    CardLevel = 7
                }
            };
        }
    }
}
