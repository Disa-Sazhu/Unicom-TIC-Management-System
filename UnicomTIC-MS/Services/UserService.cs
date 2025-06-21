using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Enums;
using UnicomTIC_MS.Models;
using UnicomTIC_MS.Repositories;

namespace UnicomTIC_MS.Services
{
    public class UserService
    {
        private UserRepository _repo = new UserRepository();

        // 🔐 LOGIN
        public User Authenticate(string username, string password)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Username cannot be empty.");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password cannot be empty.");

            // Call repository
            User user = _repo.GetUser(username, password);

            if (user == null)
                throw new Exception("Invalid username or password.");

            return user;
        }

        // 📝 REGISTER
        public void RegisterUser(User user)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new Exception("Username is required.");
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new Exception("Password is required.");
            if (!Enum.IsDefined(typeof(UserRole), user.Role))
                throw new Exception("Invalid role selected.");

            // Save to DB
            _repo.AddUser(user);
        }
    }
}
