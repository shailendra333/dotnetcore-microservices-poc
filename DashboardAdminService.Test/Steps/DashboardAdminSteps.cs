using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using Xunit;

namespace DashboardAdminService.Test.Steps
{
    [Binding]
    public class DashboardAdminSteps
    {
        private readonly ScenarioContext _context;
        private HttpResponseMessage _response;
        private string _jwtToken = "valid-admin-jwt-token"; // Replace with actual token logic
        private HttpClient _client;

        public DashboardAdminSteps(ScenarioContext context)
        {
            _context = context;
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri("http://localhost:5000"); // Adjust as needed
        }

        [Given("an authenticated admin user with a valid JWT token")]
        public void GivenAnAuthenticatedAdminUserWithAValidJWTToken()
        {
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _jwtToken);
        }

        [When(@"the admin requests GET (.*) for the last month")]
        public async Task WhenTheAdminRequestsGetForTheLastMonth(string endpoint)
        {
            _response = await _client.GetAsync(endpoint + "?from=2025-08-25&to=2025-09-25");
        }

        [Then(@"the response status should be (.*)")]
        public void ThenTheResponseStatusShouldBe(string status)
        {
            var expected = status == "200 OK" ? HttpStatusCode.OK : HttpStatusCode.Forbidden;
            _response.StatusCode.Should().Be(expected);
        }

        // Add more step definitions for other scenarios as needed
    }
}
