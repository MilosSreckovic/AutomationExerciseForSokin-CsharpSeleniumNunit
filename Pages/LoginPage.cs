using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class LoginPage
    {
        private readonly WaitHelper waitHelper;

        public LoginPage(IWebDriver driver)
        {
            waitHelper = new WaitHelper(driver);
        }

        private By LoginToYourAccountTitle => By.XPath("//h2[text()='Login to your account']");
        private By EmailInput => By.XPath("//input[@data-qa='login-email']");
        private By PasswordInput => By.XPath("//input[@data-qa='login-password']");
        private By LoginButton => By.XPath("//button[@data-qa='login-button']");

        public bool IsLoginToYourAccountVisible()
        {
            return waitHelper.WaitForElement(LoginToYourAccountTitle).Displayed;
        }

        public void Login(string email, string password)
        {
            waitHelper.WaitForElement(EmailInput).SendKeys(email);
            waitHelper.WaitForElement(PasswordInput).SendKeys(password);
            waitHelper.ClickElement(LoginButton);
        }
    }
}
