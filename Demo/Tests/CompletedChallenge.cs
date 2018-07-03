using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Tests.Settings;

namespace Tests
{
    [TestClass]
    public class CompletedChallenge
    {
        IWebDriver Driver;

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(Config.DRIVERPATH, options);
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

            // step 1
            Driver.Navigate().GoToUrl("https://statsroyale.com");

            // step 2
            // Decks is not a dropdown element even though it "looks" like one
            // Upon inspection, Decks is just an <a> (anchor) element
            // Click it to reveal its menu, then click Popular Decks
            Driver.FindElement(By.XPath("//a[contains(text(), 'Decks')]")).Click();
            Driver.FindElement(By.LinkText("Popular Decks")).Click();

            // step 3
            // The SelectElement class, from the OpenQA.Selenium.Support.UI module,
            // makes working with dropdowns very easy.
            var typeDropdown = new SelectElement(Driver.FindElement(By.Name("type")));
            typeDropdown.SelectByValue("tournament");

            // step 4
            // The SelectElement class is aptly named because the dropdowns are
            // <select> (Select) elements. Find the <select> element and pass it into
            // the SelectElement constructor
            var sortDropdown = new SelectElement(Driver.FindElements(By.XPath("//select"))[2]);
            sortDropdown.SelectByValue("winp");

            // step 5
            var deck = Driver.FindElement(By.CssSelector(".popularDecks__deck"));
            Assert.IsTrue(deck.Text.Contains("91.05%"));
        }
    }
}
