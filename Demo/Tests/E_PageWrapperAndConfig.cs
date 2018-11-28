using DevTo.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Framework;
using Tests.Framework.Selenium;

namespace Tests
{
    [TestFixture]
    public class E_PageWrapperAndConfig
    {
        /*CNOTE:
         * =====
         * using config.json with IConfiguration for a more global settings file
         * 
         * DriverFactory now just reads from the FW.Config
         * 
         * Page Wrapper centralizes all pages
         * 
         * Problems:
         * - These SetUp and TearDown methods are only usable by this Test File
         * 
         * - No control of Test Data, so we still use if/else
         * 
         * - Still no Parallelization support :(
        */

        IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            FW.Init();
            Driver = DriverFactory.Build();
            Page.Init(Driver);
        }

        [TearDown]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        [Test, Category("e")]
        public void Search_invalid_query_displays_no_results()
        {
            Page.Home.Nav.Search("$ym$0!s");
            Assert.True(Page.Search.NoResults());
        }

        [Test, Category("e")]
        [TestCase("asdf")]
        [TestCase("foo")]
        [TestCase("boopity")]
        [TestCase("qa at the point")]
        public void Search_valid_query_displays_results(string query)
        {
            Page.Home.Nav.Search(query);

            var article = Page.Search.GetArticle();

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
