using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string password, string salt, string username)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetUserName(username);
            Password = password;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUserName(string username)
        {
            if (String.IsNullOrEmpty(username)) throw new Exception("Username can't be empty");
            //if (!NameRegex.IsMatch(username)) throw new Exception("Invalid username");
            if (UserName == username) return;
            UserName= username.ToLowerInvariant();
            SetUpdate();
        }

        public void SetEmail(string email)
        {
            if(String.IsNullOrEmpty(email)) throw new Exception("Email can't be empty");
            if (Email==email) return;

            Email=email.ToLowerInvariant();
            SetUpdate();
        }

        public void SetPassword(string password, string salt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            if (string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt can not be empty.");
            }
            if (password.Length < 4) 
            {
                throw new Exception("Password must contain at least 4 characters.");
            }
            if (password.Length > 100) 
            {
                throw new Exception("Password can not contain more than 100 characters.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            Salt = salt;
           SetUpdate();
        }

        private void SetUpdate()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}