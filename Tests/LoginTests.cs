using AutomationExercise.Base;
using AutomationExercise.Pages;
using AutomationExercise.Utilities;

namespace AutomationExercise.Tests
{
    public class LoginTests : BaseTest
    {
        private string email = string.Empty;
        private string password = string.Empty;
        private readonly ApiHelper apiHelper = new ApiHelper();

        [SetUp]
        public async Task TestSetup()
        {
            email = $"test{Guid.NewGuid():N}@mailinator.com";
            password = "Test123!";

            await apiHelper.CreateUser(
                "Test User",
                email,
                password);
        }

        [Test]
        public void LoginUserWithCorrectEmailAndPassword()
        {
            HomePage homePage = new(driver!);
            LoginPage loginPage = new(driver!);
            AccountDeletedPage accountDeletedPage = new(driver!);

            homePage.OpenHomePage();
            Assert.That(homePage.IsHomePageVisible(), Is.True, "Home page is not visible.");

            homePage.ClickSignupLogin();
            Assert.That(loginPage.IsLoginToYourAccountVisible(), Is.True, "'Login to your account' is not visible.");

            loginPage.Login(email, password);
            Assert.That(homePage.IsLoggedInAsUserVisible(), Is.True, "'Logged in as username' is not visible.");

            homePage.ClickDeleteAccount();
            Assert.That(accountDeletedPage.IsAccountDeletedVisible(), Is.True, "'ACCOUNT DELETED!' is not visible.");
        }
    }
}