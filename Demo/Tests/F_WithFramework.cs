using DevTo.Helpers;
using DevTo.Pages;
using NUnit.Framework;
using Tests.Base;
using Tests.Framework;

namespace Tests
{
    [TestFixture]
    public class F_WithFramework : TestBase
    {
        /*CNOTE:
         * =====
         * TestBase class is a reusable set of SetUp and TearDown methods
         * 
         * ThreadStatic Driver, just like Pages, enables us to have multiple instances,
         * so we now have Parallelization support!
         * 
         * Better understanding of data and behavior allows more concise, stable, and reliable Tests
         * 
         * Problems:
         * - No logging or screenshots..
         * 
         * - Some Assertions may not be needed or could be encapsulated (optional)
         * 
         * - You can get Test Data from any source rather than from [TestCase()] (Database, CSV, XLSX, etc.)
        */

        [Test, Category("f")]
        [TestCase("rhymes")]
        public void Search_person_with_username(string username)
        {
            Page.Home.Nav.Search(username);

            var article = Page.Search.GetArticle();

            Assert.True(article.IsLabeled);
            Assert.True(article.Button.Text.Contains("FOLLOW"));
            Assert.AreEqual("person", article.Label.Text);
            Assert.AreSame($"{FW.Config["test:url"]}/{username}", article.Author.GetAttribute("href"));
        }

        [Test, Category("f")]
        [TestCase("carlos")]
        public void Search_person_using_people_filter(string person)
        {
            Page.Home.Nav.Search(person);

            Page.Search.SelectFilter(Filter.PEOPLE);

            foreach (var _article in Page.Search.Articles)
            {
                var article = ArticleHelper.GenerateArticle(_article);

                Assert.True(article.Button.Text.Contains("FOLLOW"));
                Assert.AreEqual("person", article.Label.Text);
            }
        }
    }
}
