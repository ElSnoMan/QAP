using System;
using DevTo.Model;
using OpenQA.Selenium;

namespace DevTo.Helpers
{
    public static class ArticleHelper
    {
        public static Article GenerateArticle(IWebElement articleElement)
        {
            var article = new Article
            {
                Author = articleElement.FindElement(By.CssSelector("h4 > a")),
                Button = articleElement.FindElement(By.TagName("button")),
                Title = articleElement.FindElement(By.XPath(".//h3")),
                Tags = articleElement.FindElements(By.CssSelector(".tags > a"))
            };

            try
            {
                article.Label = article.Title.FindElement(By.TagName("span"));
                article.IsLabeled = true;
            }
            catch (NoSuchElementException)
            {
                article.IsLabeled = false;
            }

            return article;
        }
    }
}
