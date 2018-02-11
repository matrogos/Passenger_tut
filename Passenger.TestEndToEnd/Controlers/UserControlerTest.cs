using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;

namespace Passenger.TestEndToEnd.Controlers
{
    public class UserControlerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public UserControlerTest()
        {
            _server = new TestServer(new WebHostBuilder()
                        .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public async Task given_valid_email_user_should_exist()
        {
            var email = @"a1@a.com";
            var response = await _client.GetAsync($"api/users/{email}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            Assert.AreEqual(email, user.Email);
        }

        [Test]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = @"a1000@invalid.com";
            var response = await _client.GetAsync($"api/users/{email}");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public async Task given_unique_email_user_should_be_created()
        {
            var request = new CreateUser
            {
                Email=@"a4@a.com",
                Password="secret",
                UserName="user4"
            };
            var payLoad = GetPayload(request);
            var response = await _client.PostAsync($"api/users", payLoad);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);

            Assert.AreEqual($"api/users/{request.Email}",response.Headers.Location.ToString());
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}