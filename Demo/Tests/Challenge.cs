using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.Settings;

namespace Tests
{
    [TestClass]
    public class Challenge
    {
        IWebDriver Driver;

        [TestInitialize]
        public void Setup()
        {
            Driver = new ChromeDriver(Config.DRIVERPATH);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (Driver != null)
                Driver.Quit();
        }

        [TestMethod]
        public void StatsRoyaleChallenge()
        {
            // AUTOMATE THE CHALLENGE
            // ======================
            // 1. Go to statsroyale.com
            // 2. Go to Popular Decks
            // 3. Sort by Tournaments
            // 4. Sort by Win Percentage
            // 5. Assert that win percentage is 91.05

            Driver.Navigate().GoToUrl("https://statsroyale.com");
        }
    }
}
