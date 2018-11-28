using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Tests.Framework.Selenium
{
    public static class DriverFactory
    {
        /*
         * Uncomment FW fields to use IConfiguration
         */

        public static IWebDriver Build()
        {
            var driver = Build(FW.Config["driver:browser"]);
            driver.Url = FW.Config["test:url"];
            return driver;
        }

        public static IWebDriver Build(string browser)
        {
            switch (browser)
            {
                case "chrome":
                    return BuildChromeDriver();

                case "firefox":
                    return BuildFirefoxDriver();

                default:
                    throw new ArgumentException($"{browser} is an invalid browser name.");
            }
        }

        private static IWebDriver BuildChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(FW.DRIVER_PATH, options);
        }

        private static IWebDriver BuildFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            return new FirefoxDriver(FW.DRIVER_PATH, options);
        }
    }
}
