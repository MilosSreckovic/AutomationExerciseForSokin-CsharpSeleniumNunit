
using System.Net.Http;
using System.Text.Json;

namespace AutomationExercise.Utilities
{
    public class ApiHelper
    {
        private static readonly HttpClient client = new()
        {
            BaseAddress = new Uri("https://automationexercise.com/api/")
        };

        public async Task CreateUser(
            string name,
            string email,
            string password)
        {
            var formData = new Dictionary<string, string>
            {
                { "name", name },
                { "email", email },
                { "password", password },
                { "title", "Mr" },
                { "birth_date", "10" },
                { "birth_month", "5" },
                { "birth_year", "1990" },
                { "firstname", "Test" },
                { "lastname", "User" },
                { "company", "QA Company" },
                { "address1", "Test Address 1" },
                { "address2", "Test Address 2" },
                { "country", "Canada" },
                { "zipcode", "12345" },
                { "state", "Ontario" },
                { "city", "Toronto" },
                { "mobile_number", "1234567890" }
            };

            using var content = new FormUrlEncodedContent(formData);

            using var response = await client.PostAsync(
                "createAccount",
                content
            );

            await ValidateResponse(
                response,
                201,
                "User created!"
            );
        }

        public async Task DeleteUser(
            string email,
            string password)
        {
            var formData = new Dictionary<string, string>
            {
                { "email", email },
                { "password", password }
            };

            using var content = new FormUrlEncodedContent(formData);

            using var request = new HttpRequestMessage(
                HttpMethod.Delete,
                "deleteAccount"
            )
            {
                Content = content
            };

            using var response = await client.SendAsync(request);

            await ValidateResponse(
                response,
                200,
                "Account deleted!"
            );
        }

        private static async Task ValidateResponse(
            HttpResponseMessage response,
            int expectedCode,
            string expectedMessage)
        {
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement root = document.RootElement;

            int actualCode = root
                .GetProperty("responseCode")
                .GetInt32();

            string? actualMessage = root
                .GetProperty("message")
                .GetString();

            if (actualCode != expectedCode ||
                actualMessage != expectedMessage)
            {
                throw new InvalidOperationException(
                    $"Unexpected API response. " +
                    $"Expected: {expectedCode} - {expectedMessage}. " +
                    $"Actual: {actualCode} - {actualMessage}"
                );
            }
        }
    }
}
