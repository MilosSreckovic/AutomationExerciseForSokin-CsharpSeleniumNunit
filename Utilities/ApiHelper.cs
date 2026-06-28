namespace AutomationExercise.Utilities
{
    public class ApiHelper
    {
        private readonly HttpClient client;

        public ApiHelper()
        {
            client = new HttpClient();
        }

        public async Task CreateUser(string name, string email, string password)
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

            var content = new FormUrlEncodedContent(formData);

            await client.PostAsync("https://automationexercise.com/api/createAccount", content);
        }
    }
}
