using System.Collections.Generic;
using OpenQA.Selenium;

namespace DevTo.Model
{
    public class Article
    {
        public IWebElement Author { get; set; }

        public IWebElement Title { get; set; }

        public IWebElement Label { get; set; }

        public IWebElement Button { get; set; }

        public bool IsLabeled { get; set; }

        public IList<IWebElement> Tags { get; set; }
    }
}
