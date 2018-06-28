using System;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver Driver;

        [TestInitialize]
        public void Setup()
        {
            Driver = new ChromeDriver(Directory.GetCurrentDirectory());
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Quit();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Driver.Navigate().GoToUrl("https://statsroyale.com");
        }
    }
}
