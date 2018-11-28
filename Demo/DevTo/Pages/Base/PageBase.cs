using System.Threading;
using OpenQA.Selenium;

namespace DevTo.Pages.Base
{
    public class PageBase
    {
        public readonly Nav Nav;

        public PageBase(IWebDriver driver)
        {
            Nav = new Nav(driver);
        }
    }

    public class Nav
    {
        public readonly NavMap Map;

        public Nav(IWebDriver driver)
        {
            Map = new NavMap(driver);
        }

        public void Search(string query)
        {
            Map.SearchForm.FindElement(By.Name("q")).SendKeys(query);
            Map.SearchForm.Submit();
            Thread.Sleep(3000);
        }
    }

    public class NavMap
    {
        readonly IWebDriver _driver;

        public NavMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement LogoLink => _driver.FindElement(By.Id("logo-link"));

        public IWebElement SearchForm => _driver.FindElement(By.CssSelector("form[action='/search']"));

        public IWebElement WritePostButton => _driver.FindElement(By.Id("write-link"));
    }
}
