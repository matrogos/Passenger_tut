using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;

namespace Passenger.Test.Services
{
    public class UserServiceTest
    {
        [Test]
        public async Task RegisterTest()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.RegisterAsync("user@mail.com", "user", "secret");

            userRepositoryMock.Verify(x=>x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}