using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Handlers.Users;

namespace Passenger.TestEndToEnd.Controlers
{
    public class AccountControllerTest : ControllerTestBase
    {
        public AccountControllerTest() : base()
        {
        }

        [Test]
        public async Task given_valid_current_and_new_password_it_should_be_changed()
        {
            var request = new ChangeUserPassword {
                CurrentPassword = "secret",
                NewPassword = "secret123"                
            };
            var payLoad = GetPayload(request);
            var response = await Client.PutAsync($"api/account/password", payLoad);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NoContent);

        }
    }
}