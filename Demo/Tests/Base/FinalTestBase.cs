using System;
using System.IO;
using DevTo.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Tests.Framework;
using Tests.Framework.Selenium;

namespace Tests.Base
{
    public abstract class FinalTestBase
    {
        /*
         * Used for the G Test Suite
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
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (outcome == TestStatus.Failed)
            {
                var imageName = TestContext.CurrentContext.Test.MethodName;
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var ssFileName = $"{Directory.GetCurrentDirectory()}/{imageName}";
                screenshot.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
            }

            Driver.Quit();
        }
    }
}
