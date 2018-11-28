using System.Threading;
using DevTo.Pages.Base;
using OpenQA.Selenium;

namespace DevTo.Pages
{
    public class Search : FeedPageBase
    {
        public readonly SearchMap Map;

        public Search(IWebDriver driver) : base(driver)
        {
            Map = new SearchMap(driver);
        }

        public void SelectFilter(Filter filter)
        {
            switch (filter)
            {
                case Filter.POSTS:
                    Map.PostsFilter.Click();
                    break;

                case Filter.ONLY_MY_POSTS:
                    Map.OnlyMyPostsFilter.Click();
                    break;

                case Filter.PEOPLE:
                    Map.PeopleFilter.Click();
                    break;

                case Filter.PODCASTS:
                    Map.PodcastsFilter.Click();
                    break;
            }

            // sleep for demo
            Thread.Sleep(2000);
        }

        public bool NoResults()
        {
            try
            {
                return Map.NoResultsMessage.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

    public class SearchMap
    {
        readonly IWebDriver _driver;

        public SearchMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement NoResultsMessage => _driver.FindElement(By.CssSelector(".query-results-nothing"));

        public IWebElement PostsFilter => _driver.FindElement(By.XPath("//a[text()='POSTS']"));

        public IWebElement PodcastsFilter => _driver.FindElement(By.XPath("//a[text()='PODCASTS']"));

        public IWebElement PeopleFilter => _driver.FindElement(By.XPath("//a[text()='PEOPLE']"));

        public IWebElement OnlyMyPostsFilter => _driver.FindElement(By.XPath("//a[text()='ONLY MY POSTS']"));
    }

    public enum Filter
    {
        POSTS,
        PODCASTS,
        PEOPLE,
        ONLY_MY_POSTS
    }
}
