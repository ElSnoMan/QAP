using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Tests.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class C_SeleniumNoFramework
    {
        /*CNOTE:
         * =====
         * using the Form element allows us to .Submit() our search, so it works for any browser.
         * 
         * Problems:
         * - string browser can be set to "chrome" or "firefox", but only in this Test file
         * 
         * - Still doesn't work for Parallelization because IWebDriver is shared between every Test Method.
         * 
         * - Locators are still hard-coded
         * 
         * - Try/Catch in Test to allow Assertions
         * 
         * - However, trying to create logic for any user path in Test can get VERY verbose and ugly
        */

        string browser = "chrome";
        IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            if (browser == "chrome")
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                Driver = new ChromeDriver(FW.DRIVER_PATH, options);
            }
            else if (browser == "firefox")
            {
                var options = new FirefoxOptions();
                options.AddArgument("--start-maximized");
                Driver = new FirefoxDriver(FW.DRIVER_PATH, options);
            }
        }

        [TearDown]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        [Test, Category("c")]
        public void Search_symbols_returns_no_results()
        {
            Driver.Navigate().GoToUrl("https://dev.to");
            var form = Driver.FindElement(By.CssSelector("form[action='/search']"));
            form.FindElement(By.Name("q")).SendKeys("$ym&0!s");
            form.Submit();

            // sleep for demo
            Thread.Sleep(3000);

            IWebElement noResultsMessage = null;

            try
            {
                noResultsMessage = Driver.FindElement(By.CssSelector(".query-results-nothing"));
            }
            catch (NoSuchElementException)
            {
                // do nothing since results loaded
            }

            Assert.IsNotNull(noResultsMessage);
        }

        [Test, Category("c")]
        [TestCase("asdf")]
        [TestCase("foo")]
        [TestCase("boopity")]
        [TestCase("qa at the point")]
        public void Search_other_queries_return_results(string query)
        {
            Driver.Navigate().GoToUrl("https://dev.to");
            var form = Driver.FindElement(By.CssSelector("form[action='/search']"));
            form.FindElement(By.Name("q")).SendKeys(query);
            form.Submit();

            // sleep for demo
            Thread.Sleep(3000);

            IList<IWebElement> articles = Driver.FindElements(By.CssSelector("[class*='single-article']"));

            if (articles.Count == 0)
            {
                Assert.True(Driver.FindElement(By.CssSelector(".query-results-nothing")).Displayed);
            }
            else
            {
                var article = articles.First();
                var title = article.FindElement(By.XPath(".//h3"));
                IWebElement label = null;

                try
                {
                    label = title.FindElement(By.TagName("span"));
                }
                catch (NoSuchElementException)
                {
                    // do nothing since Person label is not displayed
                }

                if (label != null)
                {
                    if (label.Text == "person")
                    {
                        Assert.True(article.FindElement(By.TagName("button")).Text.Contains("FOLLOW"));
                    }
                    else
                    {
                        Assert.False(string.IsNullOrEmpty(label.Text));
                    }
                }
                else
                {
                    Assert.True(title.Text.Contains(query));
                }
            }
        }
    }
}
