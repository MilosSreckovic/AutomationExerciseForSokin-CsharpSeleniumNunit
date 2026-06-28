using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class AccountDeletedPage
    {
        private readonly WaitHelper waitHelper;

        public AccountDeletedPage(IWebDriver driver)
        {
            waitHelper = new WaitHelper(driver);
        }

        private By AccountDeletedTitle => By.XPath("//b[text()='Account Deleted!']");

        public bool IsAccountDeletedVisible()
        {
            return waitHelper.WaitForElement(AccountDeletedTitle).Displayed;
        }
    }
}