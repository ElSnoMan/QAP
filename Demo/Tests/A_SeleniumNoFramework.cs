using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestFixture]
    public class A_SeleniumNoFramework
    {
        /*CNOTE:
         * =====
         * Problems:
         * - Only works for Chrome
         * 
         * - ChromeOptions and Driver instantiation are verbose and hard-coded
         * 
         * - Driver path is hard-coded in Test
         * 
         * - URL is hard-coded in Test
         * 
         * - Element locators are hard-coded in Test
         * 
         * - Search query is hard-coded in Test
         * 
         * - Driver.Quit() is only called if Assert passes
        */

        [Test, Category("a")]
        public void DevTo_Test_One()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver Driver = new ChromeDriver("/users/carlos/projects/qap/demo/tests/drivers/", options);
            Driver.Navigate().GoToUrl("https://dev.to");
            Driver.FindElement(By.Name("q")).SendKeys("fun" + Keys.Enter);

            // sleep for demo
            Thread.Sleep(3000);

            IWebElement firstArticle = Driver.FindElement(By.XPath("(//*[@id='substories']//h3)[1]"));
            Assert.True(firstArticle.Text.Contains("fun"));

            Driver.Quit();
        }

        [Test, Category("a")]
        public void DevTo_Test_Two()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver Driver = new ChromeDriver("/users/carlos/projects/qap/demo/tests/drivers/", options);
            Driver.Navigate().GoToUrl("https://dev.to");
            Driver.FindElement(By.Name("q")).SendKeys("js" + Keys.Enter);

            // sleep for demo
            Thread.Sleep(3000);

            IWebElement firstArticle = Driver.FindElement(By.XPath("(//*[@id='substories']//h3)[1]"));
            Assert.True(firstArticle.Text.Contains("js"));

            Driver.Quit();
        }
    }
}
