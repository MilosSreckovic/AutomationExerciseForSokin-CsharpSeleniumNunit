using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class CartPage(IWebDriver driver)
    {
        private readonly WaitHelper waitHelper = new(driver);
        private static By SignupLoginButton => By.XPath("//a[contains(text(),'Signup / Login')]");
        private static By CartProduct => By.XPath("//tr[contains(@id,'product')]");

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
