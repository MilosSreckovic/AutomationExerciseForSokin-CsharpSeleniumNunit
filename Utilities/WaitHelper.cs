using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Utilities
{
    public class WaitHelper
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public WaitHelper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement WaitForElement(By locator)
        {
            return wait.Until(d =>
            {
                IWebElement element = d.FindElement(locator);
                return element.Displayed && element.Enabled ? element : null;
            });
        }

        public void ClickElement(By locator)
        {
            WaitForElement(locator).Click();
        }

        public void WaitForUrlContains(string text)
        {
            wait.Until(d => d.Url.Contains(text));
        }
    }
}
