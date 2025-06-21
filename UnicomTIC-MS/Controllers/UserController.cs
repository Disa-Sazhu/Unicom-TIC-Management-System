using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTIC_MS.Models;
using UnicomTIC_MS.Repositories;
using UnicomTIC_MS.Services;

namespace UnicomTIC_MS.Controllers
{
    public class UserController
    {
        private UserService _service = new UserService();

        // 🔐 LOGIN method
        public User Login(string username, string password)
        {
            try
            {
                return _service.Authenticate(username, password);
            }
            catch (Exception ex)
            {
                // You can choose to log or show this in the form
                throw new Exception("Login failed: " + ex.Message);
            }
        }

        // 📝 REGISTER method
        public void Register(User user)
        {
            try
            {
                _service.RegisterUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Registration failed: " + ex.Message);
            }
        }
    }
}