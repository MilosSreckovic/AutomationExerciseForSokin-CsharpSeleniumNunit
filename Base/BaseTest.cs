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
            options.AddArgument("--disable-infobars");
            options.AddArgument("--host-resolver-rules=MAP googleads.g.doubleclick.net 127.0.0.1, MAP pagead2.googlesyndication.com 127.0.0.1");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
