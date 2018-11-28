using NUnit.Framework;
using OpenQA.Selenium;
using DevTo.Pages;
using Tests.Framework.Selenium;

namespace Tests
{
    [TestFixture]
    public class D_BasicPomAndTestContext
    {
        /*CNOTE:
         * =====
         * using .runsettings file to centralize settings
         * 
         * TestContext is a powerful class that lets us grab things from the Tests.
         * In this case, we are grabbing the Parameters we set in the .runsettings file
         * 
         * Driver Options and Driver instantiation are abstracted via the Factory Pattern
         * 
         * Locators are abstracted to Page Maps
         * 
         * Try/Catch and other complex code/logic abstracted to Page Objects
         * 
         * Article class represents an actual Article on the page
         * 
         * Problems:
         * - "new" keyword shouldn't be in our UI Test Methods
         * 
         * - lots of if/else logic
         * 
         * - TestContext is part of NUnit.Framework, but is XML and can also look funky in non-test files
        */

        string browser = TestContext.Parameters["browser"];
        string url = TestContext.Parameters["url"];

        IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.Build(browser);
            Driver.Url = url;
        }

        [TearDown]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        [Test, Category("d")]
        public void Search_invalid_query_displays_no_results()
        {
            var homepage = new Home(Driver);
            homepage.Nav.Search("$ym$0!s");

            var searchpage = new Search(Driver);
            Assert.True(searchpage.NoResults());
        }

        [Test, Category("d")]
        [TestCase("asdf")]
        [TestCase("foo")]
        [TestCase("boopity")]
        [TestCase("qa at the point")]
        public void Search_valid_query_displays_results(string query)
        {
            var homepage = new Home(Driver);
            homepage.Nav.Search(query);

            var searchpage = new Search(Driver);
            var article = searchpage.GetArticle();

            if (article.IsLabeled)
            {
                if (article.Label.Text == "person")
                {
                    Assert.True(article.Button.Text.Contains("FOLLOW"));
                }
                else
                {
                    Assert.False(string.IsNullOrEmpty(article.Label.Text));
                }
            }
            else
            {
                Assert.True(article.Title.Text.Contains(query));
            }
        }
    }
}
