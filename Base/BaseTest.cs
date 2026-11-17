
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationExercise.Base
{
    public class BaseTest
    {
        protected IWebDriver? driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new();

            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-extensions");

            // Enable headless execution in CI
            if (Environment.GetEnvironmentVariable("CI") == "true")
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--window-size=1920,1080");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
            }

            driver = new ChromeDriver(options);

            if (Environment.GetEnvironmentVariable("CI") != "true")
            {
                driver.Manage().Window.Maximize();
            }
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                driver?.Quit();
            }
            finally
            {
                driver?.Dispose();
                driver = null;
            }
        }
    }
}
