using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;
        private readonly WaitHelper waitHelper;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            waitHelper = new WaitHelper(driver);
        }

        private By SignupLoginButton => By.XPath("//a[contains(text(),'Signup / Login')]");
        private By HomePageSlider => By.Id("slider");
        private By LoggedInAsUserText => By.XPath("//a[contains(text(),'Logged in as')]");
        private By DeleteAccountButton => By.XPath("//a[contains(text(),'Delete Account')]");

        private By ProductsButton => By.XPath("//a[contains(text(),'Products')]");
        private By CartButton => By.XPath("//a[contains(text(),'Cart')]");

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