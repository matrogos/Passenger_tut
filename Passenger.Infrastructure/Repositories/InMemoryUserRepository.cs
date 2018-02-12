using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("a1@a.com", "secret","user", "salt", "user 1"),
            new User("a2@a.com", "secret","user", "salt", "user 2"),
            new User("a3@a.com", "secret","user", "salt", "user 143")
        };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(p => p.Id == id));
        }

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(p => p.Email == email.ToLowerInvariant()));

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}