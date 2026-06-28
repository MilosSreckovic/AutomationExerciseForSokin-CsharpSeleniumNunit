using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class CartPage
    {
        private readonly WaitHelper waitHelper;
        private By SignupLoginButton => By.XPath("//a[contains(text(),'Signup / Login')]");

        public CartPage(IWebDriver driver)
        {
            waitHelper = new WaitHelper(driver);
        }

        private By CartProduct => By.XPath("//tr[contains(@id,'product')]");

        public bool IsProductVisibleInCart()
        {
            return waitHelper.WaitForElement(CartProduct).Displayed;
        }

        public void ClickSignupLogin()
        {
            waitHelper.ClickElement(SignupLoginButton);
        }
    }
}
