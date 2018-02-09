using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User Get(Guid id);
        User Get(string email);
        void Add(User user);
        void Remove(Guid id);
        void Update(User user);

    }
}