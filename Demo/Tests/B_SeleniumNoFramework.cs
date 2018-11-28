using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.Framework;

namespace Tests
{
    [TestFixture]
    public class B_SeleniumNoFramework
    {
        /*CNOTE:
         * =====
         * Driver path now works for any user.
         * 
         * SetUp and TearDown methods are run before each and after each Test Method.
         * 
         * Problems:
         * - No longer works for Parallelization because IWebDriver is shared between every Test Method.
         * 
         * - Only works for Chrome
         * 
         * - URL is hard-coded in Test
         * 
         * - Element locators are hard-coded in Test
         * 
         * - Search query is hard-coded in Test
         * 
         * - Keys.Enter does not work for geckodriver
        */

        IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(FW.DRIVER_PATH, options);
        }

        [TearDown]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        [Test, Category("b")]
        public void Search_fun_returns_articles()
        {
            Driver.Navigate().GoToUrl("https://dev.to");
            Driver.FindElement(By.Name("q")).SendKeys("fun" + Keys.Enter);

            // sleep for demo
            Thread.Sleep(3000);

            var firstArticle = Driver.FindElement(By.XPath("(//*[@id='substories']//h3)[1]"));
            Assert.True(firstArticle.Text.Contains("fun"));
        }

        [Test, Category("b")]
        public void Search_javascript_returns_articles()
        {
            Driver.Navigate().GoToUrl("https://dev.to");
            Driver.FindElement(By.Name("q")).SendKeys("javascript" + Keys.Enter);

            // sleep for demo
            Thread.Sleep(3000);

            var firstArticle = Driver.FindElement(By.XPath("(//*[@id='substories']//h3)[1]"));
            Assert.True(firstArticle.Text.Contains("javascript"));
        }

        [Test, Category("b")]
        public void Search_python_returns_articles()
        {
            Driver.Navigate().GoToUrl("https://dev.to");
            Driver.FindElement(By.Name("q")).SendKeys("python" + Keys.Enter);

            // sleep for demo
            Thread.Sleep(3000);

            var firstArticle = Driver.FindElement(By.XPath("(//*[@id='substories']//h3)[1]"));
            Assert.True(firstArticle.Text.Contains("python"));
        }

        [Test, Category("b")]
        public void Search_ruby_returns_articles()
        {
            Driver.Navigate().GoToUrl("https://dev.to");
            Driver.FindElement(By.Name("q")).SendKeys("ruby" + Keys.Enter);

            // sleep for demo
            Thread.Sleep(3000);

            var firstArticle = Driver.FindElement(By.XPath("(//*[@id='substories']//h3)[1]"));
            Assert.True(firstArticle.Text.Contains("ruby"));
        }
    }
}
