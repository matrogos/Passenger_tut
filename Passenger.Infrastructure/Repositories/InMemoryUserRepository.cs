using System;
using System.Collections.Generic;
using System.Linq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("a1@a.com", "secret", "salt", "user 1"),
            new User("a2@a.com", "secret", "salt", "user 2"),
            new User("a3@a.com", "secret", "salt", "user 143")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
        {
            return _users.Single(p => p.Id == id);
        }

        public User Get(string email)
            => _users.Single(p => p.Email == email.ToLowerInvariant());

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}