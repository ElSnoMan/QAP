using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsRoyale.Constant;
using StatsRoyale.Data;
using StatsRoyale.Model;

namespace Tests
{
    [TestClass]
    public class Challenges
    {
        [TestMethod]
        public void Challenge_01()
        {
            var iceSpirit = new Card
            {
                Name = "Ice Spirit",
                Description = "Spawns one lively little Ice Spirit to freeze a group of enemies. Stay frosty.",
                ElixirCost = 1,
                Category = "Troop",
                Arena = "Arena 8",
                Rarity = Rarity.Common,
                CardLevel = 9
            };

            // Assert that iceSpirit's Rarity is Common
        }

        [TestMethod]
        public void Challenge_02()
        {
            var iceSpirit = new Card
            {
                Name = "Ice Spirit",
                Description = "Spawns one lively little Ice Spirit to freeze a group of enemies. Stay frosty.",
                ElixirCost = 1,
                Category = "Troop",
                Arena = "Arena 8",
                Rarity = Rarity.Common,
                CardLevel = 9
            };

            var mirror = new Card
            {
                Name = "Mirror",
                Description = "Mirrors your last card played for +1 Elixir.",
                Category = "Spell",
                Arena = "Arena 11",
                Rarity = Rarity.Epic,
                CardLevel = 4
            };

            // Assert that iceSpirit's Elixir Cost is equal to mirror's Elixir Cost
        }

        [TestMethod]
        public void Challenge_03()
        {
            var iceSpirit = new Card
            {
                Name = "Ice Spirit",
                Description = "Spawns one lively little Ice Spirit to freeze a group of enemies. Stay frosty.",
                ElixirCost = 1,
                Category = "Troop",
                Arena = "Arena 8",
                Rarity = Rarity.Common,
                CardLevel = 9
            };

            // Assert that iceSpirit's Range is 2.5
        }

        [TestMethod]
        public void Challenge_04()
        {
            var database = new DataBase();
            var cards = database.Cards;

            // Assert that each card has an Elixir Cost greater than zero
        }

        [TestMethod]
        public void Challenge_05()
        {
            // Connect to Database

            // Add the Three Musketeers Card to the Database
                // go to statsroyale.com, then go to Cards

            // Assert that Cards has been incremented by 1

            // Assert that Three Musketeers' Speed is Medium
        }
    }
}
