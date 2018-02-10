using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IUserService
    {
         Task RegisterAsync(string email, string username, string password);

         Task<UserDto> GetAsync(string email);


    }
}