using AutomationExercise.Base;
using AutomationExercise.Pages;

namespace AutomationExercise.Tests
{
    public class SearchAndCartTests : BaseTest
    {
        [Test]
        public void SearchProductsAndVerifyCartAfterLogin()
        {
            HomePage homePage = new(driver!);
            ProductsPage productsPage = new (driver!);
            CartPage cartPage = new (driver!);
            LoginPage loginPage = new (driver!);

            homePage.OpenHomePage();
            homePage.ClickProducts();

            productsPage.SearchProduct("Blue Top");
            Assert.That(productsPage.AreSearchedProductsVisible(), Is.True);

            productsPage.AddFirstProductToCart();
            productsPage.ClickViewCart();
            Assert.That(cartPage.IsProductVisibleInCart(), Is.True);

            cartPage.ClickSignupLogin();
            loginPage.Login("yourEmail", "yourPassword");

            homePage.ClickCart();
            Assert.That(cartPage.IsProductVisibleInCart(), Is.True);
        }
    }
}
