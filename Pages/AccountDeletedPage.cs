using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class AccountDeletedPage(IWebDriver driver)
    {
        private readonly WaitHelper waitHelper = new(driver);

        private static By AccountDeletedTitle => By.XPath("//b[text()='Account Deleted!']");

        public bool IsAccountDeletedVisible()
        {
            return waitHelper.WaitForElement(AccountDeletedTitle).Displayed;
        }
    }
}