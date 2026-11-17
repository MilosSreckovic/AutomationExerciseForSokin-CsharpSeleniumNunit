
using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class LoginPage(IWebDriver driver)
    {
        private readonly WaitHelper waitHelper = new(driver);

        private static readonly By LoginTitle =
            By.XPath("//h2[normalize-space()='Login to your account']");

        private static readonly By EmailInput =
            By.CssSelector("[data-qa='login-email']");

        private static readonly By PasswordInput =
            By.CssSelector("[data-qa='login-password']");

        private static readonly By LoginButton =
            By.CssSelector("[data-qa='login-button']");

        public bool IsLoginToYourAccountVisible()
        {
            return waitHelper.WaitForElement(LoginTitle).Displayed;
        }

        public void EnterEmail(string email)
        {
            IWebElement emailField = waitHelper.WaitForElement(EmailInput);
            emailField.Clear();
            emailField.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            IWebElement passwordField = waitHelper.WaitForElement(PasswordInput);
            passwordField.Clear();
            passwordField.SendKeys(password);
        }

        public void ClickLogin()
        {
            waitHelper.ClickElement(LoginButton);
        }

        public void Login(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            ClickLogin();
        }
    }
}
