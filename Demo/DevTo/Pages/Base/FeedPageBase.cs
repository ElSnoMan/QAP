using System;
using System.Collections.Generic;
using DevTo.Helpers;
using DevTo.Model;
using OpenQA.Selenium;

namespace DevTo.Pages.Base
{
    public class FeedPageBase : PageBase
    {
        readonly IWebDriver _driver;

        public FeedPageBase(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public Article GetArticle(int index = 0)
        {
            var article = Articles[index];
            return ArticleHelper.GenerateArticle(article);
        }

        public IList<IWebElement> Articles => _driver.FindElements(By.CssSelector("[class*='single-article']"));
    }
}
