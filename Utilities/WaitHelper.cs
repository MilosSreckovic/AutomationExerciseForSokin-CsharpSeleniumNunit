
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Utilities
{
    public class WaitHelper(IWebDriver driver)
    {
        private readonly WebDriverWait wait =
            new(driver, TimeSpan.FromSeconds(10));

        public IWebElement WaitForElement(By locator)
        {
            return wait.Until(d =>
            {
                try
                {
                    IWebElement element = d.FindElement(locator);

                    return element.Displayed ? element : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            })!;
        }

        public IWebElement WaitForClickableElement(By locator)
        {
            return wait.Until(d =>
            {
                try
                {
                    IWebElement element = d.FindElement(locator);

                    return element.Displayed && element.Enabled
                        ? element
                        : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            })!;
        }

        public void ClickElement(By locator)
        {
            WaitForClickableElement(locator).Click();
        }
    }
}
