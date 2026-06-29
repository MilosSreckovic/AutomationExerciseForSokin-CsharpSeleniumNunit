using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class HomePage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;
        private readonly WaitHelper waitHelper = new(driver);

        private static By SignupLoginButton => By.XPath("//a[contains(text(),'Signup / Login')]");
        private static By HomePageSlider => By.Id("slider");
        private static By LoggedInAsUserText => By.XPath("//a[contains(text(),'Logged in as')]");
        private static By DeleteAccountButton => By.XPath("//a[contains(text(),'Delete Account')]");
        private static By ProductsButton => By.XPath("//a[contains(text(),'Products')]");
        private static By CartButton => By.XPath("//a[contains(text(),'Cart')]");

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://automationexercise.com");
        }

        public bool IsHomePageVisible()
        {
            return waitHelper.WaitForElement(HomePageSlider).Displayed;
        }

        public void ClickSignupLogin()
        {
            waitHelper.ClickElement(SignupLoginButton);
        }

        public bool IsLoggedInAsUserVisible()
        {
            return waitHelper.WaitForElement(LoggedInAsUserText).Displayed;
        }

        public void ClickDeleteAccount()
        {
            waitHelper.ClickElement(DeleteAccountButton);
        }

        public void ClickProducts()
        {
            waitHelper.ClickElement(ProductsButton);
        }

        public void ClickCart()
        {
            waitHelper.ClickElement(CartButton);
        }
    }
}