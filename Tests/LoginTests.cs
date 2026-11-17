
using AutomationExercise.Base;
using AutomationExercise.Pages;
using AutomationExercise.Utilities;
using NUnit.Framework;

namespace AutomationExercise.Tests
{
    public class LoginTests : BaseTest
    {
        private string email = string.Empty;
        private string password = string.Empty;
        private bool userCreated;

        private readonly ApiHelper apiHelper = new();

        [SetUp]
        public async Task TestSetup()
        {
            userCreated = false;

            email = $"test{Guid.NewGuid():N}@mailinator.com";
            password = "Test123!";

            await apiHelper.CreateUser(
                "Test User",
                email,
                password
            );

            userCreated = true;
        }

        [Test]
        public void LoginUserWithCorrectEmailAndPassword()
        {
            HomePage homePage = new(driver!);
            LoginPage loginPage = new(driver!);

            homePage.OpenHomePage();

            Assert.That(
                homePage.IsHomePageVisible(),
                Is.True,
                "Home page is not visible."
            );

            homePage.ClickSignupLogin();

            Assert.That(
                loginPage.IsLoginToYourAccountVisible(),
                Is.True,
                "Login form is not visible."
            );

            loginPage.Login(email, password);

            Assert.That(
                homePage.IsLoggedInAsUserVisible(),
                Is.True,
                "User was not successfully logged in."
            );
        }

        [TearDown]
        public async Task TestCleanup()
        {
            if (userCreated)
            {
                await apiHelper.DeleteUser(email, password);
            }
        }
    }
}
