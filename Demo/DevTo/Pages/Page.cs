using System;
using OpenQA.Selenium;

namespace DevTo.Pages
{
    public static class Page
    {
        [ThreadStatic]
        public static Home Home;

        [ThreadStatic]
        public static Search Search;

        public static void Init(IWebDriver driver)
        {
            Home = new Home(driver);
            Search = new Search(driver);
        }
    }
}
