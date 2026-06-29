using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class LoginPage(IWebDriver driver)
    {
        private readonly WaitHelper waitHelper = new(driver);

        private static By LoginToYourAccountTitle => By.XPath("//h2[text()='Login to your account']");
        private static By EmailInput => By.XPath("//input[@data-qa='login-email']");
        private static By PasswordInput => By.XPath("//input[@data-qa='login-password']");
        private static By LoginButton => By.XPath("//button[@data-qa='login-button']");

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
