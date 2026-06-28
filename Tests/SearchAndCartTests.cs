using AutomationExercise.Base;
using AutomationExercise.Pages;

namespace AutomationExercise.Tests
{
    public class SearchAndCartTests : BaseTest
    {
        [Test]
        public void SearchProductsAndVerifyCartAfterLogin()
        {
            HomePage homePage = new HomePage(driver!);
            ProductsPage productsPage = new ProductsPage(driver!);
            CartPage cartPage = new CartPage(driver!);
            LoginPage loginPage = new LoginPage(driver!);

            homePage.OpenHomePage();
            homePage.ClickProducts();

            productsPage.SearchProduct("Blue Top");

            Assert.That(productsPage.AreSearchedProductsVisible(), Is.True);

            productsPage.AddFirstProductToCart();
            productsPage.ClickViewCart();

            Assert.That(cartPage.IsProductVisibleInCart(), Is.True);

            cartPage.ClickSignupLogin();

            loginPage.Login("tvojEmail", "tvojPassword");

            homePage.ClickCart();

            Assert.That(cartPage.IsProductVisibleInCart(), Is.True);
        }
    }
}
