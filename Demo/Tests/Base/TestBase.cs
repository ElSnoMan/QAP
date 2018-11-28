using System;
using DevTo.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Framework;
using Tests.Framework.Selenium;

namespace Tests.Base
{
    public abstract class TestBase
    {
        /*
         * Used for the F Test Suite
         */

        [ThreadStatic]
        static IWebDriver Driver;

        [OneTimeSetUp]
        public void SuiteSetup()
        {
            FW.Init();
        }

        [SetUp]
        public void Setup()
        {
            Driver = DriverFactory.Build();
            Page.Init(Driver);
        }

        [TearDown]
        public void Cleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
    }
}
