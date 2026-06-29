using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Utilities
{
    public class WaitHelper(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;
        private readonly WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

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

    }
}
