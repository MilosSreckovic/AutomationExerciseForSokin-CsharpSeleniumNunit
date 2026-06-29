using AutomationExercise.Utilities;
using OpenQA.Selenium;

namespace AutomationExercise.Pages
{
    public class ProductsPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;
        private readonly WaitHelper waitHelper = new(driver);

        private static By BrandsTitle => By.XPath("//h2[text()='Brands']");
        private static By PoloBrandLink => By.XPath("//a[@href='/brand_products/Polo']");
        private static By HmBrandLink => By.XPath("//a[@href='/brand_products/H&M']");
        private static By BrandProductsTitle => By.XPath("//h2[contains(text(),'Brand -')]");
        private static By SearchInput => By.Id("search_product");
        private static By SearchButton => By.Id("submit_search");
        private static By SearchedProductsTitle => By.XPath("//h2[text()='Searched Products']");
        private static By FirstProductAddToCartButton => By.XPath("(//a[contains(@class,'add-to-cart') and contains(text(),'Add to cart')])[1]");
        private static By ViewCartButton => By.XPath("//u[text()='View Cart']");

        public bool AreBrandsVisible()
        {
            return waitHelper.WaitForElement(BrandsTitle).Displayed;
        }

        public void ClickPoloBrand()
        {
            waitHelper.ClickElement(PoloBrandLink);
        }

        public void ClickHmBrand()
        {
            waitHelper.ClickElement(HmBrandLink);
        }

        public bool IsBrandProductsTitleVisible()
        {
            return waitHelper.WaitForElement(BrandProductsTitle).Displayed;
        }

        public bool IsCurrentUrlForBrand(string brandName)
        {
            return driver.Url.Contains($"/brand_products/{brandName}");
        }

        public void SearchProduct(string productName)
        {
            waitHelper.WaitForElement(SearchInput).SendKeys(productName);
            waitHelper.ClickElement(SearchButton);
        }

        public bool AreSearchedProductsVisible()
        {
            return waitHelper.WaitForElement(SearchedProductsTitle).Displayed;
        }

        public void AddFirstProductToCart()
        {
            waitHelper.ClickElement(FirstProductAddToCartButton);
        }

        public void ClickViewCart()
        {
            waitHelper.ClickElement(ViewCartButton);
        }
    }
}