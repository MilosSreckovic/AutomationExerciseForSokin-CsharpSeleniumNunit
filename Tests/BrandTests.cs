using AutomationExercise.Base;
using AutomationExercise.Pages;

namespace AutomationExercise.Tests
{
    public class BrandTests : BaseTest
    {
        [Test]
        public void ViewAndCartBrandProducts()
        {
            HomePage homePage = new HomePage(driver!);
            ProductsPage productsPage = new ProductsPage(driver!);

            homePage.OpenHomePage();

            Assert.That(homePage.IsHomePageVisible(), Is.True, "Home page is not visible.");

            homePage.ClickProducts();

            Assert.That(productsPage.AreBrandsVisible(), Is.True, "Brands section is not visible.");

            productsPage.ClickPoloBrand();

            Assert.That(productsPage.IsBrandProductsTitleVisible(), Is.True, "Brand products title is not visible.");
            Assert.That(productsPage.IsCurrentUrlForBrand("Polo"), Is.True, "Polo brand page is not opened.");

            productsPage.ClickHmBrand();

            Assert.That(productsPage.IsBrandProductsTitleVisible(), Is.True, "Brand products title is not visible.");
            Assert.That(productsPage.IsCurrentUrlForBrand("H&M"), Is.True, "H&M brand page is not opened.");
        }
    }
}
